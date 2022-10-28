using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Task = DataLayer.Models.Task;

namespace DataLayer.DataAccess
{
    public class ResolutionContext : DbContext
    {
        public ResolutionContext(DbContextOptions<ResolutionContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Dream> Dreams { get; set; }
        public DbSet<Resolution> Resolutions { get; set; }
    }
}
