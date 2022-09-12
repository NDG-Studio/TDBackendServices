
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
        public DbSet<PlayerBaseInfo> PlayerBaseInfo { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<LogAction> LogAction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuildingType>().HasData(
                new BuildingType() { Id = 1, Name = "Base", MaxLevel=1000, BuildUrl= "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-5.png", IsActive = true },
                new BuildingType() { Id = 2, Name = "Gang Tower", MaxLevel=1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true },
                new BuildingType() { Id = 3, Name = "Wall", MaxLevel=1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true },
                new BuildingType() { Id = 4, Name = "Hospital", MaxLevel=1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true },
                new BuildingType() { Id = 5, Name = "Prison", MaxLevel=1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true },
                new BuildingType() { Id = 6, Name = "Market", MaxLevel=1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png", IsActive = true },
                new BuildingType() { Id = 7, Name = "Altar", MaxLevel=1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true },
                new BuildingType() { Id = 8, Name = "Watch Tower", MaxLevel=1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true },
                new BuildingType() { Id = 9, Name = "Research Laboratory", MaxLevel=1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true }
            );
            modelBuilder.Entity<PlayerBasePlacement>().HasData(
                new PlayerBasePlacement() { Id = 1,BuildingTypeId=1,BuildingLevel=1,CoordX=1,CoordY=1,UpdateEndDate=null,UserId=1 }
            );

        }
    }
}
