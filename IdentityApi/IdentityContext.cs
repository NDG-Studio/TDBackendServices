
using Microsoft.EntityFrameworkCore;
using IdentityApi.Entities;
using SharedLibrary.Entities;

namespace IdentityApi
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        public IdentityContext()
        {
            Database.Migrate();
        }


        public DbSet<User> User { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<LogAction> LogAction { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Username = "Ugur", Email = "ugurcan.bagriyanik@ndgstudio.com.tr", PasswordHash= "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",IsActive=true,IsAndroid=true,LastSeen=DateTime.Now,MobileUserId="dummyMobileUserId1",IsApe=true }
                );

        }
    }
}
