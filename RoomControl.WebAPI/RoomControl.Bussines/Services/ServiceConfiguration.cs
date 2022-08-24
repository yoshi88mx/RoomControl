using RoomControl.Core.Contracts;
using RoomControl.Data;
using RoomControl.Data.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RoomControl.Bussines.Services
{
    public class ServiceConfiguration : IServiceConfiguration
    {
        private readonly CHContext _context;

        public ServiceConfiguration(CHContext context)
        {
            _context = context;
        }
        public async Task<GeneralConfiguration> Get()
        {
            return await _context.GeneralConfiguration.OrderBy(t => t.Id).FirstOrDefaultAsync();
        }
    }
}
