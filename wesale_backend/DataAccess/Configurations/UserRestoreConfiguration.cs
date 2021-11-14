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
    public class UserRestoreConfiguration : IEntityTypeConfiguration<UserRestore>
    {
        public void Configure(EntityTypeBuilder<UserRestore> builder)
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
                .WithMany(u => u.UserRestores)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            builder
                .ToTable("UserRestores");
        }
    }
}
