using RoomControl.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomControl.Core.Contracts
{
    public interface IServiceRoomsStates
    {
        Task<List<RoomState>> GetAllAsync();
        Task<RoomState> GetByIdAsync(int id);
        Task<bool> ExistByIdAsync(int id);
        Task<RoomState> AddAsync(RoomState entity);
        Task<RoomState> UpdateAsync(RoomState entity);
    }
}
