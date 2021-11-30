﻿using Core.Entities.Announcement.AnnouncementBuilding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations.AnnouncementBuilding
{
    public class AnnouncementNewBuildingConfiguration : IEntityTypeConfiguration<AnnouncementNewBuilding>
    {
        public void Configure(EntityTypeBuilder<AnnouncementNewBuilding> builder)
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
               .HasOne(a => a.AnnouncementBuilding)
               .WithOne(a => a.AnnouncementNewBuilding)
               .HasForeignKey<AnnouncementNewBuilding>(a => a.AnnouncementBuildingId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion

            builder
                .ToTable("AnnouncementNewBuildings");
        }
    }
}
