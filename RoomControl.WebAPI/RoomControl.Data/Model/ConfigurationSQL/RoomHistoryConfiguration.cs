using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomControl.Data.Model;

namespace RoomControl.Data.Model.ConfigurationSQL
{
    public class RoomHistoryConfiguration : IEntityTypeConfiguration<RoomHistory>
    {
        public void Configure(EntityTypeBuilder<RoomHistory> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .HasOne(y => y.Room)
                .WithMany(y => y.RoomMovements)
                .HasForeignKey(y => y.IdRoom)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(t => t.RoomState)
                .WithMany(u => u.RoomMovements)
                .HasForeignKey(u => u.IdRoomState)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
