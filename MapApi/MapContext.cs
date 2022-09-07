
using Microsoft.EntityFrameworkCore;
using MapApi.Entities;
using SharedLibrary.Entities;

namespace MapApi
{
    public class MapContext : DbContext
    {
        public MapContext(DbContextOptions<MapContext> options) : base(options) { }

        public MapContext()
        {
            Database.Migrate();
        }

        public DbSet<Zone> Zone { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<MapItemType> MapItemType { get; set; }
        public DbSet<MapItem> MapItem { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<LogAction> LogAction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MapItemType>().HasData(
                new MapItemType() { Id = 1, Name = "Player", IsActive = true },
                new MapItemType() { Id = 2, Name = "Gate", IsActive = true },
                new MapItemType() { Id = 3, Name = "UnAssignedCenter", IsActive = true }
            );
            //modelBuilder.Entity<MapPlacement>().HasData(
            //    new MapPlacement() { Id = 1, BuildingTypeId = 1, BuildingLevel = 1, CoordX = 1, CoordY = 1, UpdateEndDate = null, UserId = 1 }
            //);

        }
    }
}
