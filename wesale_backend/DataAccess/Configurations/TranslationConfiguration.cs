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
    public class TranslationConfiguration : IEntityTypeConfiguration<Translation>
    {
        public void Configure(EntityTypeBuilder<Translation> builder)
        {
            #region Id

            builder
                .HasKey(n => n.Id);

            builder
                .Property(n => n.Id)
                .UseIdentityColumn();

            #endregion

            #region Related page

            builder
                .Property(lr => lr.RelatedPage)
                .HasDefaultValue("*")
                .IsRequired(false);

            #endregion

            #region Content key

            builder
                .Property(lr => lr.ContentKey)
                .IsRequired(true);

            builder
                .HasIndex(lr => lr.ContentKey)
                .IsUnique();

            #endregion 

            #region Content AZ

            builder
                .Property(lr => lr.Content_AZ)
                .IsRequired(true);

            #endregion 

            #region Content RU

            builder
                .Property(lr => lr.Content_RU)
                .HasDefaultValue(String.Empty)
                .IsRequired(false);

            #endregion 

            #region Content EN

            builder
                .Property(lr => lr.Content_EN)
                .HasDefaultValue(String.Empty)
                .IsRequired(false);

            #endregion 
        }
    }
}
