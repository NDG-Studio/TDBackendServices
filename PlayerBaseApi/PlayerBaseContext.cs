
using Microsoft.EntityFrameworkCore;
using PlayerBaseApi.Entities;
using SharedLibrary.Entities;

namespace PlayerBaseApi
{
    public class PlayerBaseContext : DbContext
    {
        public PlayerBaseContext(DbContextOptions<PlayerBaseContext> options) : base(options) { }

        public PlayerBaseContext()
        {
            Database.Migrate();
        }

        public DbSet<BuildingType> BuildingType { get; set; }
        public DbSet<PlayerBasePlacement> PlayerBasePlacement { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<LogAction> LogAction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuildingType>().HasData(
                new BuildingType() { Id = 1, Name = "Base", MaxLevel=1000, IsActive = true }
            );
            modelBuilder.Entity<PlayerBasePlacement>().HasData(
                new PlayerBasePlacement() { Id = 1,BuildingTypeId=1,BuildingLevel=1,CoordX=1,CoordY=1,UpdateEndDate=null,UserId=1 }
            );

        }
    }
}
