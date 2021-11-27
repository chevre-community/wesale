using Core.Entities;
using Core.Entities.NotificationRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class PageSettingsConfiguration : IEntityTypeConfiguration<PageSetting>
    {
        public void Configure(EntityTypeBuilder<PageSetting> builder)
        {
            #region Id

            builder
                .HasKey(ps => ps.Id);

            builder
                .Property(ps => ps.Id)
                .UseIdentityColumn();

            #endregion

            #region LogoPhotoName

            builder
              .Property(ps => ps.LogoPhotoName)
              .IsRequired();

            #endregion

            #region FacebookLink

            builder
              .Property(ps => ps.FacebookLink)
              .IsRequired();

            #endregion

            #region InstagramLink

            builder
              .Property(ps => ps.InstagramLink)
              .IsRequired();

            #endregion

            #region InstagramLive

            builder
              .Property(ps => ps.InstagramLive)
              .IsRequired();

            #endregion

            #region InstagramPhotoName

            builder
              .Property(ps => ps.InstagramPhotoName)
              .IsRequired();

            #endregion
        }
    }
}
