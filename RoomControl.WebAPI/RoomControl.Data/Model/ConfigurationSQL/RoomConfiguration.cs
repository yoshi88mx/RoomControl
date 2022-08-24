using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomControl.Data.Model;

namespace RoomControl.Data.Model.ConfigurationSQL
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .HasOne(y => y.RoomState)
                .WithMany(y => y.Rooms)
                .HasForeignKey(y => y.IdRoomState)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(t => t.RoomType)
                .WithMany(t => t.Rooms)
                .HasForeignKey(y => y.IdRoomType)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(y => y.Queue)
                .WithMany(y => y.Rooms)
                .HasForeignKey(y => y.IdQueue)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(y => y.RoomPrice)
                .WithMany(y => y.Rooms)
                .HasForeignKey(y => y.IdRoomPrice)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasData(new Room
                {
                    Id = 1,
                    Number = 1,
                    Description = "Suite Junior 1",
                    IdRoomType = 1,
                    IdRoomState = 1,
                    IdQueue = 1,
                    IdRoomPrice = 1,
                    Active = true
                }, new Room
                {
                    Id = 2,
                    Number = 2,
                    Description = "Suite Junior 2",
                    IdRoomType = 1,
                    IdRoomState = 1,
                    IdQueue = 1,
                    IdRoomPrice = 1,
                    Active = true
                }, new Room
                {
                    Id = 3,
                    Number = 1,
                    Description = "Master con jacuzzi 1",
                    IdRoomType = 2,
                    IdRoomState = 1,
                    IdQueue = 1,
                    IdRoomPrice = 1,
                    Active = true
                }, new Room
                {
                    Id = 4,
                    Number = 2,
                    Description = "Master con jacuzzi 2",
                    IdRoomType = 2,
                    IdRoomState = 1,
                    IdQueue = 2,
                    IdRoomPrice = 1,
                    Active = true
                });
        }
    }
}
