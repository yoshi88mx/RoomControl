using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RoomControl.Core.Contracts;
using RoomControl.Data;
using RoomControl.Data.Model;
using RoomControl.Shared.Dtos;

namespace RoomControl.Bussines.Services
{
    public class ServiceQueues : IServiceQueues
    {
        private readonly CHContext _context;
        private readonly IServiceRooms _serviceRooms;
        private readonly IConfiguration _configuration;
        private readonly IServiceConfiguration _serviceConfiguration;
        private readonly IServiceDisplayHistorye _serviceDisplay;

        public ServiceQueues(CHContext context, IServiceRooms serviceRooms, IConfiguration configuration, IServiceConfiguration serviceConfiguration, IServiceDisplayHistorye serviceDisplay)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _serviceRooms = serviceRooms ?? throw new ArgumentNullException(nameof(serviceRooms));
            _configuration = configuration;
            _serviceConfiguration = serviceConfiguration;
            _serviceDisplay = serviceDisplay;
        }

        public async Task<Queue> AddAsync(Queue entity)
        {
            await _context.Queues.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            return await _context.Queues.AnyAsync(y => y.Id == id);
        }

        public async Task<List<Queue>> GetAllAsync()
        {
            return await _context.Queues.Include(t => t.Images).ToListAsync();
        }

        public async Task<Queue> GetByIdAsync(int id)
        {
            return await _context.Queues.Include(t => t.Images).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Room> GetRoomAvailableByQueueId(int idQueue)
        {
            var queue = await _context.Queues.Where(t => t.Id == idQueue).Include(t => t.Rooms).FirstOrDefaultAsync();
            var roomsAvailable = queue.Rooms.Where(y => y.IdRoomState == 1 & y.Active == true);
            if (roomsAvailable.Any())
            {
                var roomOrder = await _context.RoomHistory
                    .Where(t => t.Room.IdQueue == idQueue)
                    .Where(t => t.IdRoomState == 2)
                    .Where(t => t.Date > DateTime.Now.AddDays(Convert.ToInt16(_configuration.GetSection("RoomControl:DaysOfCriteriaForOrder")) * -1))
                    .GroupBy(j => j.IdRoom, q => q, (o, l) => new { idroom = o, timesOcupated = l.Count() })
                    .OrderBy(t => t.timesOcupated)
                    .ToListAsync();

                foreach (var roomO in roomOrder)
                {
                    var room = roomsAvailable.FirstOrDefault(t => t.Id == roomO.idroom);
                    if (room is not null)
                    {
                        return await _serviceRooms.GetByIdAsync(room.Id);
                    }
                }
            }
            var roomsSoonToBeAvailable = queue.Rooms.Where(y => y.IdRoomState == 3 & y.Active == true);
            if (roomsSoonToBeAvailable.Any())
            {
                return new Room();
            }
            return null;
        }

        public async Task<RoomAvailableByQueueDto> GetRoomAvailable(int idQueue)
        {
            var config = await _serviceConfiguration.Get();
            if (config.IsAutomaticAssignationOnDisplay)
            {
                var room = await GetRoomAvailableByQueueId(idQueue);
                if (room is not null)
                {
                    var roomDto = new RoomAvailableByQueueDto { Number = $"{room.Number}"};

                    if (room.IdRoomPrice != 0)
                    {
                        roomDto.IsAvailable = true;
                        roomDto.Description = $"${room.RoomPrice.Price}";
                    }
                    else
                    {
                        var queue = await GetByIdAsync(idQueue);
                        roomDto.Description = $"Available on {queue.MinutesSpentOnCleanUp} minutes";
                    }
                    return roomDto;
                }
                return new RoomAvailableByQueueDto() { Description = "Not available" };
            }
            var last = await _serviceDisplay.GetLastByQueueId(idQueue);
            if (last is not null)
            {
                return new RoomAvailableByQueueDto { Description = last.Description, IsAvailable = last.IsAvailable, Number = last.Number };
            }
            return new RoomAvailableByQueueDto() { Description = "Not available" };
        }

        public async Task<Queue> UpdateAsync(Queue entity)
        {
            _context.Queues.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}