using Core.Entities;
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
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Core.Entities.Announcement.Announcement>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Announcement.Announcement> builder)
        {
            #region Id

            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Id)
                .UseIdentityColumn();

            #endregion

            #region InnerProperties

            builder
               .Property(a => a.Title)
               .IsRequired();

            #region Slug

            builder
               .Property(a => a.Slug)
               .IsRequired();

            builder
              .HasIndex(a => a.Slug)
              .IsUnique();

            #endregion

            builder
               .Property(a => a.Description)
               .HasMaxLength(150)
               .IsRequired();

            builder
                .Property(a => a.Status)
                .IsRequired();

            #endregion

            #region NavigationProperties

            builder
               .HasOne(a => a.User)
               .WithMany(a => a.Announcements)
               .HasForeignKey(a => a.UserId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
               .Property(a => a.UserId)
               .IsRequired();

            #endregion

            builder
                .ToTable("Announcements");
        }
    }
}
