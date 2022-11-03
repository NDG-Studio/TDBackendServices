using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;
using WebSocket.Interfaces;
using WebSocket.Models;
using WebSocket.Socket;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{

    private readonly ILogger<NewsController> _logger;
    private readonly INewsService _newsService;

    public NewsController(ILogger<NewsController> logger, INewsService newsService)
    {
        _logger = logger;
        _newsService = newsService;
    }

    [OnlyAdmin]
    [HttpPost("SendImportantNews")]
    public async Task<TDResponse> SendImportantNews([FromBody] BaseRequest<ImportantNews> req)
    {
        return await _newsService.SendImportantNews(req.Data);
    }



}