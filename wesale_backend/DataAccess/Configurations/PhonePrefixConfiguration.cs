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
    public class PhonePrefixConfiguration : IEntityTypeConfiguration<PhonePrefix>
    {
        public void Configure(EntityTypeBuilder<PhonePrefix> builder)
        {
            #region Id

            builder
                .HasKey(n => n.Id);

            builder
                .Property(n => n.Id)
                .UseIdentityColumn();

            #endregion

            #region Prefix

            builder
                .Property(n => n.Prefix)
                .IsRequired();

            #endregion

            #region Country

            builder
                .Property(n => n.Country)
                .IsRequired();

            #endregion

            #region Order

            builder
                .Property(n => n.Order)
                .IsRequired();

            #endregion

            #region IsActive

            builder
                .Property(n => n.IsActive)
                .IsRequired();

            #endregion

            builder
                .ToTable("PhonePrefixes");
        }
    }
}
