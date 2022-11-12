using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Task = DataLayer.Models.Task;


namespace DataLayer.DataAccess
{
    public class ResolutionContext : IdentityDbContext
    {
        public ResolutionContext(DbContextOptions<ResolutionContext> dbContextOptions) : base(dbContextOptions)
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
