using RoomControl.Core.Contracts;
using RoomControl.Data;
using RoomControl.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RoomControl.Bussines.Services
{
    public class ServiceRoomsStates : IServiceRoomsStates
    {
        private readonly CHContext context;

        public ServiceRoomsStates(CHContext context)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
        }
        public async Task<RoomState> AddAsync(RoomState entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            return await context.RoomStates.AnyAsync(t => t.Id == id);
        }

        public async Task<List<RoomState>> GetAllAsync()
        {
            return await context.RoomStates.ToListAsync();
        }

        public async Task<RoomState> GetByIdAsync(int id)
        {
            return await context.RoomStates.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<RoomState> UpdateAsync(RoomState entity)
        {
            context.RoomStates.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
