﻿
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
        public DbSet<Tower> Tower { get; set; }
        public DbSet<Zombie> Zombie { get; set; }
        public DbSet<TowerProgress> TowerProgress { get; set; }
        public DbSet<ZombieKill> ZombieKill { get; set; }
        public DbSet<UserProgress> UserProgress { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<LogAction> LogAction { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Stage> stageList = new List<Stage>();
            for (int i = 11; i < 1000; i++)
            {
                var tmp = (float)i / (float)10;
                stageList.Add(new Stage() { Id = i, Name = (tmp < 10 ? "0" : "") + tmp.ToString(), Code = (tmp < 10 ? "0" : "") + tmp.ToString(), IsActive = true });
            }
            modelBuilder.Entity<Stage>().HasData(
                stageList.ToArray()
                );
            modelBuilder.Entity<Tower>().HasData(
                new Tower() { Id = 1, Name = "StandartTower", IsActive = true },
                new Tower() { Id = 2, Name = "ShortRangeAOETower", IsActive = true },
                new Tower() { Id = 3, Name = "MeleeTower", IsActive = true },
                new Tower() { Id = 4, Name = "SlowTower", IsActive = true },
                new Tower() { Id = 5, Name = "SniperTower", IsActive = true },
                new Tower() { Id = 6, Name = "LongRangeAOETower", IsActive = true },
                new Tower() { Id = 7, Name = "ShortRangeAOEStackingDamageTower", IsActive = true },
                new Tower() { Id = 8, Name = "PiercingMediumRangeTower", IsActive = true },
                new Tower() { Id = 9, Name = "CommandTower", IsActive = true }
            );

            modelBuilder.Entity<Zombie>().HasData(
                new Zombie() { Id = 1, Name = "z1", IsActive = true },
                new Zombie() { Id = 2, Name = "z2", IsActive = true },
                new Zombie() { Id = 3, Name = "z3", IsActive = true },
                new Zombie() { Id = 4, Name = "z4", IsActive = true },
                new Zombie() { Id = 5, Name = "z5", IsActive = true },
                new Zombie() { Id = 6, Name = "z6", IsActive = true },
                new Zombie() { Id = 7, Name = "z7", IsActive = true },
                new Zombie() { Id = 8, Name = "z8", IsActive = true },
                new Zombie() { Id = 9, Name = "z9", IsActive = true }
);

        }
    }
}
