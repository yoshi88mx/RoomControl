using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomControl.Data.Model;

namespace RoomControl.Data.Model.ConfigurationSQL
{
    public class RoomStateConfiguration : IEntityTypeConfiguration<RoomState>
    {
        public void Configure(EntityTypeBuilder<RoomState> builder)
        {
            builder.HasKey(y => y.Id);

            builder.HasData(new RoomState
            {
                Id = 1,
                Description = "Disponible",
                Position = 1,
                Color = "bg-success"
            }, new RoomState
            {
                Id = 2,
                Description = "Ocupado",
                Position = 2,
                Color = "bg-danger"
            }, new RoomState
            {
                Id = 3,
                Description = "Sucia",
                Position = 3,
                Color = "bg-warning"
            }, new RoomState
            {
                Id = 4,
                Description = "Mantenimiento",
                Position = 0,
                Color = "bg-secondary"
            });
        }
    }
}
