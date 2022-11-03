using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;
using WebSocket.Entities;
using WebSocket.Enums;
using WebSocket.Models;

namespace WebSocket.Socket
{
    public class DbService
    {
        public static async Task SetUserActivity(long UserId, DateTimeOffset LastConnection, bool IsConnectedNow)
        {
            try
            {
                using (var _context = new WebSocketContext())
                {
                    var q = await _context.UserActivity.Where(l => l.UserId == UserId).FirstOrDefaultAsync();
                    if (q != null)
                    {
                        q.LastConnection = LastConnection;
                        q.IsConnectedNow = IsConnectedNow;
                    }
                    else
                    {
                        await _context.AddAsync(new UserActivity()
                        {
                            UserId = UserId,
                            LastConnection = LastConnection,
                            IsConnectedNow = IsConnectedNow,
                            LastNewsCheck = new DateTimeOffset(1997, 4, 10, 10, 10, 0, TimeSpan.FromHours(0))
                        });
                    }
                    await _context.SaveChangesAsync();
                }
                SendSomethingInStart(UserId);
            }
            catch (Exception e)
            {

            }

        }

        private static async Task SendSomethingInStart(long userId)
        {
            try
            {
                using (var _context = new WebSocketContext())
                {
                    var userActivity = await _context.UserActivity.Where(l => l.UserId == userId).FirstOrDefaultAsync();
                    await SendNews(_context, userId, userActivity);
                }
            }
            catch (Exception e)
            {

            }
        }


        public static async Task SendNews(WebSocketContext? _context, long userId, UserActivity? userActivity)
        {
            try
            {
                var g = _context;
                if (_context==null)
                {
                    _context = new WebSocketContext();
                }
                if (userActivity==null)
                {
                    userActivity = await _context.UserActivity.Where(l => l.UserId == userId).FirstOrDefaultAsync();
                }
                var importantNews = await _context.ImportantNews.Where(l => l.IsActive && l.Date > userActivity.LastNewsCheck).OrderByDescending(l => l.Date).ThenBy(l => l.Title).ToListAsync();
                foreach (var item in importantNews)
                {
                    _context.News.Add(new News()
                    {
                        IsActive = true,
                        Title = item.Title,
                        Detail = item.Detail,
                        Date = item.Date,
                        Seen = false,
                        TypeId = (int)NewsType.ImportantNews,
                        UserId = userId

                    });
                }
                await _context.SaveChangesAsync();
                var newsQuery = await _context.News.Where(l => l.UserId == userId && l.IsActive && l.Date > userActivity.LastNewsCheck).OrderByDescending(l => l.Date)
                    .Select(l => new NewsDTO()
                    {
                        Casualities = l.Casualities,
                        Date=l.Date.ToString(),
                        Detail = l.Detail,
                        GainedResources = l.GainedResources,
                        LostResource = l.LostResource,
                        Prisoners = l.Prisoners,
                        Seen = l.Seen,
                        TypeId = l.TypeId,
                        Title = l.Title,
                        Wounded = l.Wounded
                    })
                    .ToListAsync();
                userActivity.LastNewsCheck = DateTimeOffset.Now;
                await _context.SaveChangesAsync();
                Player.SendNewNews(userId, newsQuery);
                if (g==null)
                {
                    _context.Dispose();
                }
            }
            catch (Exception e)
            {

            }
        }


    }
}
