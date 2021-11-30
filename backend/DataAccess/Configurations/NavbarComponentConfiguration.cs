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
    public class NavbarComponentConfiguration : IEntityTypeConfiguration<NavbarComponent>
    {
        public void Configure(EntityTypeBuilder<NavbarComponent> builder)
        {
            #region Id

            builder
                .HasKey(n => n.Id);

            builder
                .Property(n => n.Id)
                .UseIdentityColumn();

            #endregion

            #region Title AZ

            builder
                .Property(nc => nc.Title_AZ)
                .IsRequired(true);

            #endregion 

            #region Title RU

            builder
                .Property(nc => nc.Title_RU)
                .HasDefaultValue(String.Empty)
                .IsRequired(false);

            #endregion 

            #region Title EN

            builder
                .Property(nc => nc.Title_EN)
                .HasDefaultValue(String.Empty)
                .IsRequired(false);

            #endregion

            #region Link

            builder
                .Property(nc => nc.Link)
                .HasDefaultValue(String.Empty)
                .IsRequired(true);

            #endregion 

            #region Order

            builder
                .Property(nc => nc.Order)
                .IsRequired(true);

            #endregion 

            #region RequireAuthorization

            builder
                .Property(nc => nc.RequireAuthorization)
                .IsRequired(true);

            #endregion 

            #region ShowOnHeader

            builder
                .Property(nc => nc.ShowOnHeader)
                .IsRequired(true);

            #endregion 

            #region ShowOnFooter

            builder
                .Property(nc => nc.ShowOnFooter)
                .IsRequired(true);

            #endregion 
        }
    }
}
