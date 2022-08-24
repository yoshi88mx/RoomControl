using RoomControl.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl.Core.Contracts
{
    public interface IServiceDisplayHistorye
    {
        Task<DisplayHistory> GetLastByQueueId(int id);
        Task<DisplayHistory> AddAsync(DisplayHistory display, int idPrice, int idQueue);
        
    }
}
