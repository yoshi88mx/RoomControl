using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RoomControl.Data.Model.ConfigurationSQL
{
    public class QueueImageConfiguration : IEntityTypeConfiguration<QueueImage>
    {
        public void Configure(EntityTypeBuilder<QueueImage> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(t => t.Id)
                .UseIdentityColumn();

            builder
              .HasOne(t => t.Queue)
              .WithMany(t => t.Images)
              .HasForeignKey(t => t.IdQueue)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
