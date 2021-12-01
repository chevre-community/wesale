using Core.Entities.District;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations.District
{
    public class SubDistrictConfiguration : IEntityTypeConfiguration<SubDistrict>
    {
        public void Configure(EntityTypeBuilder<SubDistrict> builder)
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

            #region NavigationProperties

            builder
             .HasOne(a => a.District)
             .WithMany(a => a.SubDistricts)
             .HasForeignKey(a => a.DistrictId)
             .OnDelete(DeleteBehavior.Cascade);

            #endregion

            builder
                .ToTable("SubDistricts");
        }
    }
}
