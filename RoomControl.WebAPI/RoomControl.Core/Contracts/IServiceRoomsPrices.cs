using RoomControl.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl.Core.Contracts
{
    public interface IServiceRoomsPrices
    {
        Task<List<RoomPrice>> GetAllAsync();
        Task<RoomPrice> GetByIdAsync(int id);
        Task<bool> ExistByIdAsync(int id);
        Task<RoomPrice> AddAsync(RoomPrice entity);
        Task<RoomPrice> UpdateAsync(RoomPrice entity);
    }
}
