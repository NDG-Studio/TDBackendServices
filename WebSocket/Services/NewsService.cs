using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSocket.Entities;
using WebSocket.Enums;
using WebSocket.Interfaces;
using WebSocket.Models;
using SharedLibrary.Helpers;
using SharedLibrary.Models;
using WebSocket;
using WebSocket.Socket;

namespace PlayerBaseApi.Services
{
    public class NewsService : INewsService
    {
        private readonly ILogger<NewsService> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public NewsService(ILogger<NewsService> logger, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<TDResponse> SendImportantNews(ImportantNews req)
        {
            TDResponse response = new TDResponse();
            try
            {
                using (var _context = new WebSocketContext())
                {
                    var imN = new News()
                    {
                        Title = req.Title,
                        Detail = req.Detail,
                        Date = DateTimeOffset.Now,
                        UserId = null,
                        IsActive = true,
                        Seen = false,
                        TypeId = (int)NewsType.ImportantNews
                    };
                    await _context.ImportantNews.AddAsync(imN);
                    await _context.SaveChangesAsync();
                    response.SetSuccess();
                }
                Player.SendAllNewsRefreshNeeded();

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
            }
            return response;

        }

        public async Task<TDResponse> SendAnnouncment(ImportantNews req)
        {
            TDResponse response = new TDResponse();
            try
            {
                using (var _context = new WebSocketContext())
                {
                    var imN = new News()
                    {
                        Title = req.Title,
                        Detail = req.Detail,
                        Date = DateTimeOffset.Now,
                        UserId = null,
                        IsActive = true,
                        Seen = false,
                        TypeId = (int)NewsType.Announcment
                    };
                    await _context.ImportantNews.AddAsync(imN);
                    await _context.SaveChangesAsync();
                    response.SetSuccess();
                }
                Player.SendAllNewsRefreshNeeded();

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
            }
            return response;

        }




    }
}
