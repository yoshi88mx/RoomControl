using System.Collections.Generic;
using System.Threading.Tasks;
using RoomControl.Data.Model;

namespace RoomControl.Core.Contracts
{
    public interface IServiceRoomsTypes
    {
        Task<List<RoomType>> GetAllAsync();
        Task<RoomType> GetByIdAsync(int id);
        Task<bool> ExistByIdAsync(int id);
        Task<RoomType> AddAsync(RoomType entity);
        Task<RoomType> UpdateAsync(RoomType entity);
    }
}