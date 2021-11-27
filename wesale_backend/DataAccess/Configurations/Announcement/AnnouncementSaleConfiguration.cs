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
    public class AnnouncementSaleConfiguration : IEntityTypeConfiguration<AnnouncementSale>
    {
        public void Configure(EntityTypeBuilder<AnnouncementSale> builder)
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
               .WithOne(a => a.AnnouncementSale)
               .HasForeignKey<AnnouncementSale>(a => a.AnnouncementDealId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion

            builder
                .ToTable("AnnouncementSales");
        }
    }
}
