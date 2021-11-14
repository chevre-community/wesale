using Core.Entities;
using Core.Entities.Abstraction;
using Core.Entities.NotificationRelated;
using DataAccess.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class WeSaleContext : IdentityDbContext<User, Role, string>
    {
        public WeSaleContext(DbContextOptions<WeSaleContext> options)
        :base(options)
        {

        }

        public DbSet<NotifyEvent> NotifyEvents { get; set; }
        public DbSet<SmsOperationResult> SmsOperationResults { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserActivation> UserActivations { get; set; }
        public DbSet<UserRestore> UserRestores { get; set; }


        #region ConfigurationMethods

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new NotifyEventConfiguration());
            builder.ApplyConfiguration(new SmsOperationResultConfiguration());
            builder.ApplyConfiguration(new NotificationConfiguration());
            builder.ApplyConfiguration(new UserActivationConfiguration());
            builder.ApplyConfiguration(new UserRestoreConfiguration());
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // for entities that implements ICreateTiming,
                // set CreatedAt to current UTC 
                if (entry.Entity is ICreatedAt createdEntity && entry.State == EntityState.Added)
                {
                    createdEntity.CreatedAt = utcNow;
                }

                if (entry.Entity is IUpdatedAt updatedEntity && entry.State == EntityState.Modified)
                {
                    // set the updated date to "now"
                    updatedEntity.UpdatedAt = utcNow;

                    // mark property as "don't touch"
                    // we don't want to update on a Modify operation
                    entry.Property("CreatedAt").IsModified = false;
                }
            }
        }

        #endregion
    }
}
