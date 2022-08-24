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
    public class ConfigurationConfiguration : IEntityTypeConfiguration<GeneralConfiguration>
    {
        public void Configure(EntityTypeBuilder<GeneralConfiguration> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasData(new GeneralConfiguration
            {
                Id = 1,
                IdRoomStateOnQueue = 1,
                IsAutomaticAssignationOnDisplay = false
            });
        }
    }
}
