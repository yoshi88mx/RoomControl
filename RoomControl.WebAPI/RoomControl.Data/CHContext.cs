using Microsoft.EntityFrameworkCore;
using RoomControl.Data.Model;
using RoomControl.Data.Model.ConfigurationSQL;
using RoomControl.Data.Model.NotMapped;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomControl.Data
{
    public class CHContext : DbContext
    {
        public CHContext(DbContextOptions<CHContext> op) : base(op) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomState> RoomStates { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<RoomHistory> RoomHistory { get; set; }
        public DbSet<RoomPrice> RoomPrices { get; set; }
        public DbSet<GeneralConfiguration> GeneralConfiguration { get; set; }
        public DbSet<QueueImage> QueueImages { get; set; }
        public DbSet<QueueStack> QueueStacks { get; set; }
        public DbSet<DisplayHistory> DisplayHistoryes { get; set; }

        //No Mapeado
        public DbSet<RoomByQueue> RoomsAvalibablesByQueue { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoomConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
