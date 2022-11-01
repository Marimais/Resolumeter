using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Task = DataLayer.Models.Task;

namespace DataLayer.DataAccess
{
    public class ResolutionContext : DbContext
    {
        public ResolutionContext() : base()
        {

        }

        public DbSet<Task>? Tasks { get; set; }
        public DbSet<Goal>? Goals { get; set; }
        public DbSet<Dream>? Dreams { get; set; }
        public DbSet<Resolution>? Resolutions { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("ResolumeterContext");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
