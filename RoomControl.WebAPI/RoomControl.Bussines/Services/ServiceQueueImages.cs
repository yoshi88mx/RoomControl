using RoomControl.Core.Contracts;
using RoomControl.Data;
using RoomControl.Data.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RoomControl.Bussines.Services
{
    public class ServiceQueueImages : IServiceQueueImages
    {
        private readonly CHContext _context;

        public ServiceQueueImages(CHContext context)
        {
            _context = context;
        }
        public async Task AddAsync(string path, int queueId)
        {
            await _context.AddAsync(new QueueImage { IdQueue = queueId, ImagePath = path });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var roomImage = await _context.QueueImages.FirstOrDefaultAsync(t => t.Id == id);
            _context.QueueImages.Remove(roomImage);
            await _context.SaveChangesAsync();
        }
    }
}
