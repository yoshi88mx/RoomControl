using System.Collections.Generic;
using System.Threading.Tasks;
using RoomControl.Data.Model;
using RoomControl.Shared.Dtos;

namespace RoomControl.Core.Contracts
{
    public interface IServiceQueues
    {
        Task<List<Queue>> GetAllAsync();
        Task<Queue> GetByIdAsync(int id);
        Task<bool> ExistByIdAsync(int id);
        Task<Queue> AddAsync(Queue entity);
        Task<Queue> UpdateAsync(Queue entity);
        Task<Room> GetRoomAvailableByQueueId(int idQueue);
        Task<RoomAvailableByQueueDto> GetRoomAvailable(int idQueue);
    }
}