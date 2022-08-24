using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomControl.Data.Model;

namespace RoomControl.Data.Model.ConfigurationSQL
{
    public class QueueConfiguration : IEntityTypeConfiguration<Queue>
    {
        public void Configure(EntityTypeBuilder<Queue> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasData(new Queue
            {
                Id = 1,
                Name = "Cola Sencilla",
                Active = true,
                MinutesSpentOnCleanUp = 20
            }, new Queue
            {
                Id = 2,
                Name = "Cola Completa",
                Active = true,
                MinutesSpentOnCleanUp = 20
            }, new Queue
            {
                Id = 3,
                Name = "Cola VIP",
                Active = true,
                MinutesSpentOnCleanUp = 20
            });
        }
    }
}
