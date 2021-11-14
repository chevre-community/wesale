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
    public class NotifyEventConfiguration : IEntityTypeConfiguration<NotifyEvent>
    {
        public void Configure(EntityTypeBuilder<NotifyEvent> builder)
        {
            #region Id

            builder
                .HasKey(n => n.Id);

            builder
                .Property(n => n.Id)
                .UseIdentityColumn();

            #endregion

            #region Label

            builder
               .Property(n => n.Label)
               .IsRequired();

            #endregion

            #region NotifyFor

            builder
               .HasIndex(n => n.NotifyFor)
               .IsUnique();

            #endregion

            #region Email

            builder
              .Property(n => n.EmailSubject_EN)
              .IsRequired();

            builder
               .Property(n => n.EmailText_EN)
               .IsRequired();

            #endregion

            #region SMS

            builder
              .Property(n => n.SMSText_EN)
              .IsRequired();

            #endregion

            builder
                .ToTable("NotifyEvents");
        }
    }
}
