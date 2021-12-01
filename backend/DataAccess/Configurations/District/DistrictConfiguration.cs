using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations.District
{
    public class DistrictConfiguration : IEntityTypeConfiguration<Core.Entities.District.District>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.District.District> builder)
        {
            #region Id

            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Id)
                .UseIdentityColumn();

            #endregion

            #region Name

            builder
                .Property(d => d.Name_AZ)
                .IsRequired();

            builder
                .Property(d => d.Name_RU)
                .IsRequired();

            builder
                .Property(d => d.Name_EN)
                .IsRequired();

            #endregion

            #region Location

            builder
                .Property(d => d.X)
                .IsRequired();

            builder
               .Property(d => d.Y)
               .IsRequired();

            #endregion 

            builder
                .ToTable("Districts");
        }
    }
}
