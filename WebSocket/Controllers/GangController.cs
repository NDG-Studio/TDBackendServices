using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;
using WebSocket.Interfaces;
using WebSocket.Models;
using WebSocket.Socket;

[ApiController]
[Route("api/[controller]")]
public class GangController : ControllerBase
{

    private readonly ILogger<GangController> _logger;
    private readonly IGangService _gangService;

    public GangController(ILogger<GangController> logger, IGangService gangService)
    {
        _logger = logger;
        _gangService=gangService;
    }

    /// <summary>
    /// Gang olusturmak icin kullanilir
    /// </summary>
    /// <remarks>
    /// </remarks>
    [LoginRequired]
    [HttpPost("CreateGang")]
    public async Task<TDResponse> CreateGang([FromBody] BaseRequest<CreateGangRequest> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        var token = (HttpContext.Items["Token"] as string);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.CreateGang(req, user, token);
    }

 
    
}