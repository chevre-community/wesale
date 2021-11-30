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
    public class UserActivationConfiguration : IEntityTypeConfiguration<UserActivation>
    {
        public void Configure(EntityTypeBuilder<UserActivation> builder)
        {
            #region Id

            builder
                .HasKey(n => n.Id);

            builder
                .Property(n => n.Id)
                .UseIdentityColumn();

            #endregion

            #region NavigationProperties

            builder
                .HasOne(u => u.User)
                .WithOne(u => u.UserActivation)
                .HasForeignKey<UserActivation>(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            builder
                .ToTable("UserActivations");
        }
    }
}
