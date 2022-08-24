using RoomControl.Core.Contracts;
using RoomControl.Data;
using RoomControl.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RoomControl.Bussines.Services
{
    public class ServiceRoomHistory : IServiceRoomHistory
    {
        private readonly CHContext context;

        public ServiceRoomHistory(CHContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddAsync(int idRoom, int idState)
        {
            await context.RoomHistory.AddAsync(new RoomHistory { IdRoom = idRoom, IdRoomState = idState });
            await context.SaveChangesAsync();
        }

        public async Task<List<RoomHistory>> GetByDate(DateTime date)
        {
            return await context.RoomHistory
                .Include(t => t.Room)
                .Include(t => t.RoomState)
                .Where(t => t.Date.Date >= date.Date)
                .ToListAsync();
        }
    }
}
