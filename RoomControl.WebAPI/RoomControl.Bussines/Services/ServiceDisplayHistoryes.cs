using RoomControl.Core.Contracts;
using RoomControl.Data;
using RoomControl.Data.Model;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RoomControl.Bussines.Services
{
    public class ServiceDisplayHistoryes : IServiceDisplayHistorye
    {
        private readonly CHContext _context;
        private readonly IServiceRoomsPrices _serviceRoomsPrices;


        public ServiceDisplayHistoryes(CHContext context, IServiceRoomsPrices serviceRoomsPrices)
        {
            _context = context;
            _serviceRoomsPrices = serviceRoomsPrices;
        }
        public async Task<DisplayHistory> AddAsync(DisplayHistory display, int idPrice, int idQueue)
        {
            if (display.IsAvailable)
            {
                display.Description = "Not available";
            }
            else
            {
                if (idPrice != 0)
                {
                    var price = await _serviceRoomsPrices.GetByIdAsync(idPrice);
                    display.Description = $"${price.Price}";
                }
                else
                {
                    var queue = await _context.Queues.Include(t => t.Images).FirstOrDefaultAsync(t => t.Id == idQueue);
                    display.Description = $"Available on {queue.MinutesSpentOnCleanUp} minutes";
                    display.IsAvailable = false;
                }
            }
            await _context.DisplayHistoryes.AddAsync(display);
            await _context.SaveChangesAsync();
            return display;
        }

        public async Task<DisplayHistory> GetLastByQueueId(int id)
        {
            return await _context.DisplayHistoryes
                .Where(t => t.IdQueue == id)
                .OrderByDescending(t => t.Id)
                .FirstOrDefaultAsync();
        }
    }
}
