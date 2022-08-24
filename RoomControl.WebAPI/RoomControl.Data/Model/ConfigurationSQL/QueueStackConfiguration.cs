using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RoomControl.Data.Model.ConfigurationSQL
{
    public class QueueStackConfiguration : IEntityTypeConfiguration<QueueStack>
    {
        public void Configure(EntityTypeBuilder<QueueStack> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .Property(t => t.Id)
                .UseIdentityColumn();

            builder
                .HasOne(t => t.Queue)
                .WithOne(i => i.QueueStack)
                .HasForeignKey<QueueStack>(t => t.IdQueue)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(t => t.Room)
                .WithMany(y => y.QueueStacks)
                .HasForeignKey(r => r.IdRoom)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(t => t.RoomState)
                .WithMany(t => t.QueueStacks)
                .HasForeignKey(t => t.IdRoomState)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
