using Microsoft.EntityFrameworkCore;
using RoomControl.Core.Contracts;
using RoomControl.Data;
using RoomControl.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomControl.Bussines.Services
{
    public class ServiceRoomType : IServiceRoomsTypes
    {
        private readonly CHContext context;
        public ServiceRoomType(CHContext context)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));

        }
        public async Task<RoomType> AddAsync(RoomType entity)
        {
            await context.RoomTypes.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            return await context.RoomTypes.AnyAsync(t => t.Id == id);
        }

        public async Task<List<RoomType>> GetAllAsync()
        {
            return await context.RoomTypes.ToListAsync();
        }

        public async Task<RoomType> GetByIdAsync(int id)
        {
            return await context.RoomTypes.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<RoomType> UpdateAsync(RoomType entity)
        {
            context.RoomTypes.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}