using Microsoft.EntityFrameworkCore;
using RoomControl.Core.Contracts;
using RoomControl.Data;
using RoomControl.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomControl.Bussines.Services
{
    public class ServiceRoomsPrices : IServiceRoomsPrices
    {
        private readonly CHContext context;

        public ServiceRoomsPrices(CHContext context)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
        }
        public async Task<RoomPrice> AddAsync(RoomPrice entity)
        {
            await context.RoomPrices.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            return await context.RoomPrices.AnyAsync();
        }

        public async Task<List<RoomPrice>> GetAllAsync()
        {
            return await context.RoomPrices.ToListAsync();
        }

        public async Task<RoomPrice> GetByIdAsync(int id)
        {
            return await context.RoomPrices.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<RoomPrice> UpdateAsync(RoomPrice entity)
        {
            context.RoomPrices.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
