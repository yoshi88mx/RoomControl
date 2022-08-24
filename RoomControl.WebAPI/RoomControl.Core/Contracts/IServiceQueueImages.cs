using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl.Core.Contracts
{
    public interface IServiceQueueImages
    {
        Task AddAsync(string path, int roomId);
        Task DeleteAsync(int id);
    }
}
