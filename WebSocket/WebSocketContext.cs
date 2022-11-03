
using Microsoft.EntityFrameworkCore;
using WebSocket.Entities;
using SharedLibrary.Entities;
using System.Data.Common;

namespace WebSocket
{
    public class WebSocketContext : DbContext
    {
        public WebSocketContext(DbContextOptions<WebSocketContext> options) : base(options) { }

        public WebSocketContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionStrings__WebSocketContext"));
            }
        }



        public DbSet<News> News { get; set; }
        public DbSet<News> ImportantNews { get; set; }
        public DbSet<UserActivity> UserActivity { get; set; }




        public DbSet<Log> Log { get; set; }
        public DbSet<LogAction> LogAction { get; set; }

        #region Model Creator

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        #endregion
    }
}
