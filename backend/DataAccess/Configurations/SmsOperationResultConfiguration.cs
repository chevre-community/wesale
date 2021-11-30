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
    public class SmsOperationResultConfiguration : IEntityTypeConfiguration<SmsOperationResult>
    {
        public void Configure(EntityTypeBuilder<SmsOperationResult> builder)
        {
            #region Id

            builder
                .HasKey(n => n.Id);

            builder
                .Property(n => n.Id)
                .UseIdentityColumn();

            #endregion

            builder
                .ToTable("SmsOperationResults");
        }
    }
}
