using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Core;
using Portal.Domain;
using Portal.Domain.Entities;
using Portal.Modules.Settings;
using Portal.Persistence.Configs;
using System;
using System.Linq;

namespace Portal.Persistence
{
    public class PortalDbContext : IdentityDbContext<ApplicationUser>
    {

        public PortalDbContext(DbContextOptions<PortalDbContext> options)
            : base(options)
        {
        }


        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker
                .Entries()
                .Where(e => e.Entity is ITimeCreated && e.State == EntityState.Added)
                .Select(e => e.Entity as ITimeCreated))
            {
                if (entry.TimeCreated <= DateTime.MinValue)
                {
                    entry.TimeCreated = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Doc> Docs { get; set; }
        public DbSet<WebPage> WebPages { get; set; }
        public DbSet<OptionHistory> OptionsHistory { get; set; }
        public DbSet<Menu> Menus { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");

            builder.ApplyConfiguration(new CategoryConfig());
            builder.ApplyConfiguration(new DocConfig());
            builder.ApplyConfiguration(new PanelConfig());

            base.OnModelCreating(builder);
        }

    }
}
