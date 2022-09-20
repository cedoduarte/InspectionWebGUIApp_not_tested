using Microsoft.EntityFrameworkCore;
using InspectionAPI.Models;
using System.Reflection;

namespace InspectionAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            // nothing to do here
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("name=DefaultConnection").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            }
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateTime>().HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            foreach (var modelType in builder.Model.GetEntityTypes())
            {
                foreach (var property in modelType.GetProperties())
                {
                    if (property.ClrType == typeof(string) && property.Name.Contains("URL", StringComparison.CurrentCultureIgnoreCase))
                    {
                        property.SetIsUnicode(false);
                        property.SetMaxLength(500);
                    }
                }
            }
        }

        public DbSet<Inspection> Inspection { get; set; }
        public DbSet<InspectionType> InspectionType { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
