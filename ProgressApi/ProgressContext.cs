
using Microsoft.EntityFrameworkCore;
using ProgressApi.Entities;
using SharedLibrary.Entities;

namespace ProgressApi
{
    public class ProgressContext : DbContext
    {
        public ProgressContext(DbContextOptions<ProgressContext> options) : base(options) { }

        public ProgressContext()
        {
            Database.Migrate();
        }


        public DbSet<Stage> Stage { get; set; }
        public DbSet<UserProgress> UserProcess { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<LogAction> LogAction { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stage>().HasData(
                new Stage() { Id = 1, Name = "FirstStage", IsActive=true}
                );

        }
    }
}
