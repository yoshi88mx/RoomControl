using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RoomControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl.Data.DesignTime
{
    public class CHContextFactory : IDesignTimeDbContextFactory<CHContext>
    {
        public CHContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<CHContext>();
            options.UseSqlServer("Server=yoshi;Database=RoomsControl;User Id=sa;Password=1234;");
            return new CHContext(options.Options);
        }
    }
}
