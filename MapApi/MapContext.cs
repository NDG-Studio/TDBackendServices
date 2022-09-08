
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
            List<Area> areaList = new List<Area>();
            var c = 1;var ky = 0;
            var zId = 1;
            for (int i = 1; i < 6; i++)
            {
                var xc = 0;
                for (int z = 0; z < 3; z++)
                {
                    
                    var yc = 0 + ky;
                    for (int k = 1; k < 4; k++)
                    {
                        var xcc = 0;
                        for (int l = 1; l < 4; l++)
                        {
                            areaList.Add(new Area() { Id = c, XMin = xc+xcc, XMax = xc+xcc + 150, YMin = yc, YMax = yc + 150,ZoneId=zId});
                            xcc += 150;
                            c++;
                        }
                        yc += 150;
                        
                    }
                    
                    zId++;
                    xc += 450;
                    


                }
                ky += 450;
            }
            modelBuilder.Entity<MapItemType>().HasData(
                new MapItemType() { Id = 1, Name = "Player", IsActive = true },
                new MapItemType() { Id = 2, Name = "Gate", IsActive = true },
                new MapItemType() { Id = 3, Name = "UnAssignedCenter", IsActive = true }
            );

            modelBuilder.Entity<Zone>().HasData(
                new Zone() { Id = 1, XMin = 0, XMax = 450, YMin = 0, YMax = 450 },
                new Zone() { Id = 2, XMin = 450, XMax = 900, YMin = 0, YMax = 450 },
                new Zone() { Id = 3, XMin = 900, XMax = 1350, YMin = 0, YMax = 450 },
                new Zone() { Id = 4, XMin = 0, XMax = 450, YMin = 450, YMax = 900 },
                new Zone() { Id = 5, XMin = 450, XMax = 900, YMin = 450, YMax = 900 },
                new Zone() { Id = 6, XMin = 900, XMax = 1350, YMin = 450, YMax = 900 },
                new Zone() { Id = 7, XMin = 0, XMax = 450, YMin = 900, YMax = 1350 },
                new Zone() { Id = 8, XMin = 450, XMax = 900, YMin = 900, YMax = 1350 },
                new Zone() { Id = 9, XMin = 900, XMax = 1350, YMin = 900, YMax = 1350 },
                new Zone() { Id = 10, XMin = 0, XMax = 450, YMin = 1350, YMax = 1800 },
                new Zone() { Id = 11, XMin = 450, XMax = 900, YMin = 1350, YMax = 1800 },
                new Zone() { Id = 12, XMin = 900, XMax = 1350, YMin = 1350, YMax = 1800 },
                new Zone() { Id = 13, XMin = 0, XMax = 450, YMin = 1800, YMax = 2250 },
                new Zone() { Id = 14, XMin = 450, XMax = 900, YMin = 1800, YMax = 2250 },
                new Zone() { Id = 15, XMin = 900, XMax = 1350, YMin = 1800, YMax = 2250 }
            );

            modelBuilder.Entity<Area>().HasData(
                areaList
                //new Area() { Id = 1, XMin = 0, XMax = 150, YMin = 0, YMax = 150, ZoneId = 1 },
                //new Area() { Id = 2, XMin = 150, XMax = 300, YMin = 0, YMax = 150, ZoneId = 1 },
                //new Area() { Id = 3, XMin = 300, XMax = 450, YMin = 0, YMax = 150, ZoneId = 1 },
                //new Area() { Id = 4, XMin = 0, XMax = 150, YMin = 150, YMax = 300, ZoneId = 1 },
                //new Area() { Id = 5, XMin = 150, XMax = 300, YMin = 150, YMax = 300, ZoneId = 1 },
                //new Area() { Id = 6, XMin = 300, XMax = 450, YMin = 150, YMax = 300, ZoneId = 1 },
                //new Area() { Id = 7, XMin = 0, XMax = 150, YMin = 300, YMax = 450, ZoneId = 1 },
                //new Area() { Id = 8, XMin = 150, XMax = 300, YMin = 300, YMax = 450, ZoneId = 1 },
                //new Area() { Id = 9, XMin = 300, XMax = 450, YMin = 300, YMax = 450, ZoneId = 1 },

                //new Area() { Id = 10, XMin = 450, XMax = 600, YMin = 0, YMax = 150, ZoneId = 2 },
                //new Area() { Id = 11, XMin = 600, XMax = 750, YMin = 0, YMax = 150, ZoneId = 2 },
                //new Area() { Id = 12, XMin = 750, XMax = 900, YMin = 0, YMax = 150, ZoneId = 2 },
                //new Area() { Id = 13, XMin = 450, XMax = 600, YMin = 150, YMax = 300, ZoneId = 2 },
                //new Area() { Id = 14, XMin = 600, XMax = 750, YMin = 150, YMax = 300, ZoneId = 2 },
                //new Area() { Id = 15, XMin = 750, XMax = 900, YMin = 150, YMax = 300, ZoneId = 2 },
                //new Area() { Id = 16, XMin = 450, XMax = 600, YMin = 300, YMax = 450, ZoneId = 2 },
                //new Area() { Id = 17, XMin = 600, XMax = 750, YMin = 300, YMax = 450, ZoneId = 2 },
                //new Area() { Id = 18, XMin = 750, XMax = 900, YMin = 300, YMax = 450, ZoneId = 2 },

                //new Area() { Id = 19, XMin = 900, XMax = 1050, YMin = 0, YMax = 150, ZoneId = 3 },
                //new Area() { Id = 20, XMin = 1050, XMax = 1200, YMin = 0, YMax = 150, ZoneId = 3 },
                //new Area() { Id = 21, XMin = 1200, XMax = 1350, YMin = 0, YMax = 150, ZoneId = 3 },
                //new Area() { Id = 22, XMin = 1350, XMax = 1500, YMin = 150, YMax = 300, ZoneId = 3 },
                //new Area() { Id = 23, XMin = 1500, XMax = 1650, YMin = 150, YMax = 300, ZoneId = 3 },
                //new Area() { Id = 24, XMin = 1650, XMax = 1800, YMin = 150, YMax = 300, ZoneId = 3 },
            );

        }
    }
}
