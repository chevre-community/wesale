using Core.Entities.Announcement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations.Announcement
{
    public class AnnouncementRentConfiguration : IEntityTypeConfiguration<AnnouncementRent>
    {
        public void Configure(EntityTypeBuilder<AnnouncementRent> builder)
        {
            #region Id

            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Id)
                .UseIdentityColumn();

            #endregion

            #region NavigationProperties

            builder
               .HasOne(a => a.AnnouncementDeal)
               .WithOne(a => a.AnnouncementRent)
               .HasForeignKey<AnnouncementRent>(a => a.AnnouncementDealId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion

            builder
                .ToTable("AnnouncementRents");
        }
    }
}
