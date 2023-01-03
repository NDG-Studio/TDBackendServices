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

    [OnlyAdmin]
    [HttpPost("SendAnnouncment")]
    public async Task<TDResponse> SendAnnouncment([FromBody] BaseRequest<ImportantNews> req)
    {
        return await _newsService.SendAnnouncment(req.Data);
    }
    //[OnlyApps]
    [HttpPost("SendScoutNews")]
    public async Task<TDResponse> SendScoutNews([FromBody] BaseRequest<ScoutInfoDTO> req)
    {
        return await _newsService.SendScoutNews(req.Data);
    }        
    
    //[OnlyApps]
    [HttpPost("SendAttackNews")]
    public async Task<TDResponse> SendAttackNews([FromBody] BaseRequest<AttackInfoDTO> req)
    {
        return await _newsService.SendAttackNews(req.Data);
    }
    
    //[OnlyApps]
    [HttpPost("SendRallyNews")]
    public async Task<TDResponse> SendRallyNews([FromBody] BaseRequest<RallyDTO> req)
    {
        return await _newsService.SendRallyNews(req.Data);
    }    
    
    //[OnlyApps]
    [HttpPost("SendSupportNews")]
    public async Task<TDResponse> SendSupportNews([FromBody] BaseRequest<SupportUnitDTO> req)
    {
        return await _newsService.SendSupportNews(req.Data);
    }
    
    [HttpPost("CollectLootRunByNewsId")]
    public async Task<TDResponse> CollectLootRunByNewsId([FromBody] BaseRequest<string> req)
    {
        return await _newsService.CollectLootRunByNewsId(req.Data);
    }



}