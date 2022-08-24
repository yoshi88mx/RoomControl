using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomControl.Data.Model;

namespace RoomControl.Data.Model.ConfigurationSQL
{
    public class RoomPriceConfiguration : IEntityTypeConfiguration<RoomPrice>
    {
        public void Configure(EntityTypeBuilder<RoomPrice> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasData(new RoomPrice
            {
                Id = 1,
                ByHours = 4,
                Price = 350
            }, new RoomPrice
            {
                Id = 2,
                ByHours = 12,
                Price = 750
            }, new RoomPrice
            {
                Id = 3,
                ByHours = 24,
                Price = 1200
            });
        }
    }
}
