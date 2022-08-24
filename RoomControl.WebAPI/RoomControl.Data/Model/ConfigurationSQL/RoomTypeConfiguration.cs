using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomControl.Data.Model;

namespace RoomControl.Data.Model.ConfigurationSQL
{
    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasData(new RoomType
            {
                Id = 1,
                Description = "Sencilla"
            }, new RoomType
            {
                Id = 2,
                Description = "Completa"
            });
        }
    }
}
