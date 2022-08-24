using Microsoft.EntityFrameworkCore;
using RoomControl.Core.Contracts;
using RoomControl.Data;
using RoomControl.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomControl.Bussines.Services
{
    public class ServiceRooms : IServiceRooms
    {
        private readonly CHContext context;
        private readonly IServiceRoomHistory serviceRoomHistory;

        public ServiceRooms(CHContext context, IServiceRoomHistory serviceRoomHistory)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
            this.serviceRoomHistory = serviceRoomHistory ?? throw new System.ArgumentNullException(nameof(serviceRoomHistory));
        }

        public async Task<Room> AddAsync(Room entity)
        {
            entity.IdRoomState = 1;
            entity.Active = true;
            await context.Rooms.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            return await context.Rooms.AnyAsync(t => t.Id == id);
        }

        public async Task<List<Room>> GetAllAsync()
        {
            return await context.Rooms.ToListAsync();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return await context.Rooms.Include(r => r.RoomPrice).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Room> NextState(string idRoom)
        {
            var states = await context.RoomStates.OrderBy(t => t.Position).ToListAsync();
            var room = await GetByIdAsync(int.Parse(idRoom));
            var currentState = room.RoomState.Id;
            var nextState = room.RoomState.Id + 1;
            if (states.Any(y => y.Position == nextState))
            {
                room.IdRoomState = nextState;
                await UpdateAsync(room);
            }
            else
            {
                room.IdRoomState = 1;
                await UpdateAsync(room);
            }
            await serviceRoomHistory.AddAsync(room.Id, room.IdRoomState);
            return room;
        }

        public async Task<Room> UpdateAsync(Room entity)
        {
            var prevoius = await GetByIdAsync(entity.Id);

            prevoius.Description = entity.Description;
            prevoius.Number = entity.Number;
            prevoius.IdQueue = entity.IdQueue;
            prevoius.IdRoomPrice = entity.IdRoomPrice;
            prevoius.IdRoomType = entity.IdRoomType;
            prevoius.Active = entity.Active;

            context.Rooms.Update(prevoius);

            await context.SaveChangesAsync();


            return prevoius;
        }
    }
}