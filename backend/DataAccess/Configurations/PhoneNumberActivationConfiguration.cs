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
    public class PhoneNumberActivationConfiguration : IEntityTypeConfiguration<PhoneNumberActivation>
    {
        public void Configure(EntityTypeBuilder<PhoneNumberActivation> builder)
        {
            #region Id

            builder
                .HasKey(n => n.Id);

            builder
                .Property(n => n.Id)
                .UseIdentityColumn();

            #endregion

            #region SMSSent

            builder
                .Property(pna => pna.SMSSent)
                .IsRequired();

            #endregion

            #region OTP

            builder
                .Property(pna => pna.OTP)
                .IsRequired();

            #endregion

            #region Country

            builder
                .Property(pna => pna.ExpireDate)
                .IsRequired();

            #endregion

            #region SendAgainDate

            builder
                .Property(n => n.SendAgainDate)
                .IsRequired();

            #endregion

            #region User (one-to-one)

            builder
                .HasOne(pna => pna.User)
                .WithOne(u => u.PhoneNumberActivation)
                .HasForeignKey<PhoneNumberActivation>(pna => pna.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            builder
                .ToTable("PhoneNumberActivations");
        }
    }
}
