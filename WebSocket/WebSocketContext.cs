﻿
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
        public DbSet<Gang> Gang { get; set; }
        public DbSet<MemberType> MemberType { get; set; }
        public DbSet<GangMember> GangMember { get; set; }
        public DbSet<ChatRoom> ChatRoom { get; set; }
        public DbSet<ChatRoomMember> ChatRoomMember { get; set; }
        public DbSet<ChatMessage> ChatMessage { get; set; }
        public DbSet<GangApplication> GangApplication { get; set; }
        public DbSet<DonationHistory> DonationHistory { get; set; }




        public DbSet<Log> Log { get; set; }
        public DbSet<LogAction> LogAction { get; set; }

        #region Model Creator

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        #endregion
    }
}
