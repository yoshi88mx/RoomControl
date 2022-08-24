using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RoomControl.Data.Model.ConfigurationSQL
{
    internal class DisplayHistoryConfiguration : IEntityTypeConfiguration<DisplayHistory>
    {
        public void Configure(EntityTypeBuilder<DisplayHistory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Id)
                .UseIdentityColumn();

            builder
                .HasOne(t => t.Queue)
                .WithMany(r=> r.DisplayHistoryes)
                .HasForeignKey(t => t.IdQueue)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
            new DisplayHistory 
            { 
                Id = 1, 
                Date = new DateTime(2022,01,01), 
                Description = "Inicial", 
                IdQueue = 1
            }, new DisplayHistory 
            { 
                Id = 2, 
                Date = new DateTime(2022, 01, 01), 
                Description = "Incial", 
                IdQueue = 2 
            }, new DisplayHistory
            {
                Id = 3,
                Date = new DateTime(2022, 01, 01),
                Description = "Incial",
                IdQueue = 3
            });
        }
    }
}
