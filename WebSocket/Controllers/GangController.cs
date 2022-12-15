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


    /// <summary>
    /// Gang daveti yollamak icin kullanilir.
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// data = davet edilecek playerin idsi
    /// <br/>
    /// Input: BaseRequest &lt; long &gt;
    /// <br/>
    /// Output: TDResponse
    /// </remarks>
    [LoginRequired]
    [HttpPost("SendGangInvitation")]
    public async Task<TDResponse> SendGangInvitation([FromBody] BaseRequest<long> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.SendGangInvitation(req, user);
    }



    /// <summary>
    /// Verilen userId degeri ile Gang infoyu doner
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// data = gang uyesi olan herhangi bir user id  Not: Null ise kendi gang infosunu doner
    /// <br/>
    /// Input: BaseRequest &lt; long &gt;
    /// <br/>
    /// Output: TDResponse &lt; GangInfo &gt;
    /// </remarks>
    [LoginRequired]
    [HttpPost("GetGangInfo")]
    public async Task<TDResponse<GangInfo>> GetGangInfo([FromBody] BaseRequest<long?> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.GetGangInfo(req, user);
    }



    /// <summary>
    /// Verilen gangId degeri ile Gang memberlarini doner
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// data = uyeleri istenen gangin idsi
    /// <br/>
    /// Input: BaseRequest &lt; string &gt;
    /// <br/>
    /// Output: TDResponse &lt; List &lt; GangMemberInfo &gt; &gt;
    /// </remarks>
    [LoginRequired]
    [HttpPost("GetGangMembers")]
    public async Task<TDResponse<List<GangMemberInfo>>> GetGangMembers([FromBody] BaseRequest<string> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.GetGangMembers(req, user);
    }    
    
    /// <summary>
    /// Kullanicinin gangine ait GangMemberTypelarini doner
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// <br/>
    /// Input: BaseRequest
    /// <br/>
    /// Output: TDResponse &lt; List &lt; GetGangMemberTypes &gt; &gt;
    /// </remarks>
    [LoginRequired]
    [HttpPost("GetGangMemberTypes")]
    public async Task<TDResponse<List<MemberTypeDTO>>> GetGangMemberTypes([FromBody] BaseRequest req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.GetGangMemberTypes(req, user);
    }


    /// <summary>
    /// Gang invitationu kabul veya reddetmek icin kullanilir
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// <br/>
    /// Input: BaseRequest &lt; GangInvitationResponse &gt;
    /// <br/>
    /// Output: TDResponse
    /// </remarks>
    [LoginRequired]
    [HttpPost("AcceptGangInvitation")]
    public async Task<TDResponse> AcceptGangInvitation([FromBody] BaseRequest<GangInvitationResponse> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.AcceptGangInvitation(req, user);
    }


    /// <summary>
    /// Gang invitationu kabul veya reddetmek icin kullanilir
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// <br/>
    /// Input: BaseRequest &lt; GangInvitationResponse &gt;
    /// <br/>
    /// Output: TDResponse
    /// </remarks>
    [LoginRequired]
    [HttpPost("EditGang")]
    public async Task<TDResponse> EditGang([FromBody] BaseRequest<GangEditDTO> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.EditGang(req, user);
    }

 
    
}