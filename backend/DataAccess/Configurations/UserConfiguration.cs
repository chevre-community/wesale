using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            #region FirstName

            builder
               .Property(u => u.FirstName)
               .HasMaxLength(35)
               .IsRequired();

            #endregion

            #region LastName

            builder
               .Property(u => u.LastName)
               .HasMaxLength(35)
               .IsRequired();

            #endregion

            #region Country

            builder
               .Property(u => u.Country)
               .HasMaxLength(60)
               .IsRequired(false);

            #endregion

            #region City

            builder
               .Property(u => u.City)
               .HasMaxLength(190)
               .IsRequired(false);

            #endregion

            #region BirthMonth

            builder
               .Property(u => u.BirthMonth)
               .IsRequired(false);

            #endregion

            #region BirthDay

            builder
               .Property(u => u.BirthDay)
               .IsRequired(false);

            #endregion

            #region BirthYear

            builder
               .Property(u => u.BirthYear)
               .IsRequired(false);

            #endregion

            #region Gender

            builder
               .Property(u => u.Gender)
               .HasMaxLength(6)
               .IsRequired(false);

            #endregion

            #region NewsNotificationEnabled

            builder
               .Property(u => u.NewsNotificationEnabled)
               .IsRequired(true);

            #endregion

            #region SmsNotificationEnabled

            builder
               .Property(u => u.SmsNotificationEnabled)
               .IsRequired(true);

            #endregion

            #region PhonePrefixId

            builder
              .Property(n => n.PhonePrefixId)
              .IsRequired(false);

            #endregion

            #region Relation with Phone prefix

            builder
               .HasOne(a => a.PhonePrefix)
               .WithMany(a => a.Users)
               .HasForeignKey(a => a.PhonePrefixId)
               .OnDelete(DeleteBehavior.SetNull);

            #endregion

            builder
                .ToTable("Users");
        }
    }
}
