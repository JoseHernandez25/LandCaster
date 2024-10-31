using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Configurations
{
    public class TimeStampConfiguration : IEntityTypeConfiguration<TimeStamp>
    {
        public void Configure(EntityTypeBuilder<TimeStamp> builder)
        {
           


        }
    }
}
