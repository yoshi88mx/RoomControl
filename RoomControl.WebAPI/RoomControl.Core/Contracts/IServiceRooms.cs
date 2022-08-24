using System.Collections.Generic;
using System.Threading.Tasks;
using RoomControl.Data.Model;

namespace RoomControl.Core.Contracts
{
    public interface IServiceRooms
    {
        Task<List<Room>> GetAllAsync();
        Task<Room> GetByIdAsync(int id);
        Task<bool> ExistByIdAsync(int id);
        Task<Room> AddAsync(Room entity);
        Task<Room> UpdateAsync(Room entity);
        Task<Room> NextState(string idRoom);
    }
}