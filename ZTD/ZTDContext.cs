
using Microsoft.EntityFrameworkCore;
using ZTD.Entities;
using SharedLibrary.Entities;

namespace ZTD
{
    public class ZTDContext : DbContext
    {
        public ZTDContext(DbContextOptions<ZTDContext> options) : base(options) { }

        public ZTDContext()
        {
            Database.Migrate();
        }


        #region IDENTITY

            public DbSet<User> User { get; set; }
            public DbSet<UserToken> UserToken { get; set; }

        #endregion

        #region TOWER DEFENSE
            
            public DbSet<Chapter> Chapter { get; set; }
            public DbSet<Level> Level { get; set; }
            public DbSet<Wave> Wave { get; set; }
            public DbSet<WavePart> WavePart { get; set; }
            public DbSet<Tower> Tower { get; set; }
            public DbSet<TowerLevel> TowerLevel { get; set; }
            public DbSet<UserProgressHistory> UserProgressHistory { get; set; }
            public DbSet<UserTowerPlaceHistory> UserTowerPlaceHistory { get; set; }
            public DbSet<TowerProgress> TowerProgress { get; set; }
            public DbSet<Enemy> Enemy { get; set; }
            public DbSet<EnemyLevel> EnemyLevel { get; set; }
            public DbSet<EnemyKill> EnemyKill { get; set; }
            public DbSet<UserTdStatus> UserTdStatus { get; set; }
            public DbSet<TableChanges> TableChanges { get; set; }
            public DbSet<Item> Item { get; set; }
            public DbSet<PlayerItem> PlayerItem { get; set; }
            public DbSet<ChestType> ChestType { get; set; }
            public DbSet<Chest> Chest { get; set; }
            public DbSet<LevelChestChance> LevelChestChance { get; set; }
            public DbSet<LevelGift> LevelGift { get; set; }
            public DbSet<PlayerChest> PlayerChest { get; set; }
            public DbSet<PlayerVariable> PlayerVariable { get; set; }
            public DbSet<ResearchNode> ResearchNode { get; set; }
            public DbSet<ResearchNodeLevel> ResearchNodeLevel { get; set; }
            public DbSet<ResearchNodeUpgradeCondition> ResearchNodeUpgradeCondition { get; set; }
            public DbSet<PlayerResearchNodeLevel> PlayerResearchNodeLevel { get; set; }
            public DbSet<PlayerTableSync> PlayerTableSync { get; set; }
            public DbSet<DialogScene> DialogScene { get; set; }
            public DbSet<Dialog> Dialog { get; set; }
            

        #endregion
        
        public DbSet<Log> Log { get; set; }
        public DbSet<LogAction> LogAction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Username = "ugur", Email = "ugurcan.bagriyanik@ndgstudio.com.tr", PasswordHash= "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",IsActive=true,IsAndroid=true,LastSeen=DateTime.Now,MobileUserId="dummyMobileUserId1",IsApe=true }
                );

        }
    }
}
