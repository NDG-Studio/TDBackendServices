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
    /// Verilen userId degeri ile Gang infoyu doner
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// data = gang uyesi olan herhangi bir user id 
    /// <br/>
    /// Input: BaseRequest &lt; long &gt;
    /// <br/>
    /// Output: TDResponse &lt; GangInfo &gt;
    /// </remarks>
    //[OnlyApps]
    [HttpPost("GetGangInfoForRally")]
    public async Task<TDResponse<GangInfo>> GetGangInfoForRally([FromBody] BaseRequest<long> req)
    {

        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.GetGangInfoForRally(req);
    }    
    
    /// <summary>
    /// Gangin scrap pooluna ekleme yapmak icin kulllanilir
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// Input: BaseRequest &lt; AddGangPoolRequest &gt;
    /// <br/>
    /// Output: TDResponse
    /// </remarks>
    //[OnlyApps]
    [HttpPost("AddGangPool")]
    public async Task<TDResponse> AddGangPool([FromBody] BaseRequest<AddGangPoolRequest> req)
    {
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.AddGangPool(req);
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
    /// Gangin pooldaki parasini uyelere dagitir
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// Input: BaseRequest
    /// <br/>
    /// Output: TDResponse
    /// </remarks>
    [LoginRequired]
    [HttpPost("DistrubutePoolScraps")]
    public async Task<TDResponse> DistrubutePoolScraps([FromBody] BaseRequest req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.DistrubutePoolScraps(req, user);
    }
    
    /// <summary>
    /// gangin pooluna bagis yapmayi saglar
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// Input: BaseRequest &lt; int &gt; Not: bagislanacak miktar
    /// <br/>
    /// Output: TDResponse
    /// </remarks>
    [LoginRequired]
    [HttpPost("DonatePoolScrap")]
    public async Task<TDResponse> DonatePoolScrap([FromBody] BaseRequest<int> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.DonatePoolScrap(req, user);
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
    /// GangMemberTypei editlemek için kullanilir Owner disindakiler atilir
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// <br/>
    /// Input: BaseRequest &lt; MemberTypeDTO; &gt;
    /// <br/>
    /// Output: TDResponse
    /// </remarks>
    [LoginRequired]
    [HttpPost("SetGangMemberType")]
    public async Task<TDResponse> SetGangMemberType([FromBody] BaseRequest<List<MemberTypeDTO>> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.SetGangMemberType(req, user);
    }
    
    /// <summary>
    /// Kullanicinin gangine ait GangMemberType olusturur
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// <br/>
    /// Input: BaseRequest &lt; MemberTypeDTO; &gt;
    /// <br/>
    /// Output: TDResponse 
    /// </remarks>
    [LoginRequired]
    [HttpPost("AddGangMemberType")]
    public async Task<TDResponse> AddGangMemberType([FromBody] BaseRequest<MemberTypeDTO> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.AddGangMemberType(req, user);
    }    
    
    /// <summary>
    /// Gang owneri diger bir gang uyesinin membertypeini degistirmek icin kullanir
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// <br/>
    /// Input: BaseRequest &lt; List &lt; ChangeGangMemberTypeRequest &gt; &gt;
    /// <br/>
    /// Output: TDResponse
    /// </remarks>
    [LoginRequired]
    [HttpPost("ChangeGangMemberType")]
    public async Task<TDResponse> ChangeGangMemberType([FromBody] BaseRequest<List<ChangeGangMemberTypeRequest>> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.ChangeGangMemberType(req, user);
    }
    
    /// <summary>
    /// Yetkili gang uyesi diger membertypelarin pool dagitimini degistirmek icin kullanir
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// <br/>
    /// Input: BaseRequest &lt; List &lt; SetMemberTypePoolRequest &gt; &gt;
    /// <br/>
    /// Output: TDResponse
    /// </remarks>
    [LoginRequired]
    [HttpPost("SetMemberTypePool")]
    public async Task<TDResponse> SetMemberTypePool([FromBody] BaseRequest<List<SetMemberTypePoolRequest>> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.SetMemberTypePool(req, user);
    }

    
    /// <summary>
    /// Id si verilen gange basvuru yapmak icin kullanilir
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// <br/>
    /// Input: BaseRequest &lt; string &gt;
    /// <br/>
    /// Output: TDResponse
    /// </remarks>
    [LoginRequired]
    [HttpPost("SendGangApplication")]
    public async Task<TDResponse> SendGangApplication([FromBody] BaseRequest<string> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.SendGangApplication(req, user);
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
    /// Gangin bilgilerini degistirmek icin kullanilir
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

    
    /// <summary>
    /// Gang uyesini gangden atmak icin kullanilir
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// <br/>
    /// Input: BaseRequest &lt; long &gt; Not: long => Atilmak istenen userin idsi
    /// <br/>
    /// Output: TDResponse
    /// </remarks>
    [LoginRequired]
    [HttpPost("KickMember")]
    public async Task<TDResponse> KickMember([FromBody] BaseRequest<long> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.KickMember(req, user);
    }    
    
    /// <summary>
    /// Destroy yetkisi olan gangmemberin gangi yok etmesini icin kullanilir
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// <br/>
    /// Input: BaseRequest 
    /// <br/>
    /// Output: TDResponse
    /// </remarks>
    [LoginRequired]
    [HttpPost("DestroyGang")]
    public async Task<TDResponse> DestroyGang([FromBody] BaseRequest req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.DestroyGang(req, user);
    }
    
    
    /// <summary>
    /// Gang leri cekmek icin kullanilir
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// <br/>
    /// Input: BaseRequest &lt; int &gt; :Page size
    /// <br/>
    /// Output: TDResponse &lt; Paging &lt; GangInfo &gt; &gt;
    /// </remarks>
    [LoginRequired]
    [HttpPost("GetGangs")]
    public async Task<TDResponse<Paging<GangInfo>>> GetGangs([FromBody] BaseRequest<int> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.GetGangs(req, user);
    }       
    
    /// <summary>
    /// Userlarin gang avatarlarini cekmek icin kullanilir
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// <br/>
    /// Input: BaseRequest &lt; int &gt; :Page size
    /// <br/>
    /// Output: TDResponse &lt; List &lt; KeyValuePair -long,string- &gt; &gt;
    /// </remarks>
    //[OnlyApps]
    [HttpPost("GetGangAvatarsByUserIdList")]
    public async Task<TDResponse<List<KeyValuePair<long,string>>>> GetGangAvatarsByUserIdList([FromBody] BaseRequest<List<long>> req)
    {
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.GetGangAvatarsByUserIdList(req);
    }    
    
    /// <summary>
    /// Gang uyesini gangden atmak icin kullanilir
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// <br/>
    /// Input: BaseRequest &lt; int &gt; :Page size
    /// <br/>
    /// Output: TDResponse &lt; Paging &lt; GangApplicationDTO &gt; &gt;
    /// </remarks>
    [LoginRequired]
    [HttpPost("GetGangApplications")]
    public async Task<TDResponse<Paging<GangApplicationDTO>>> GetGangApplications([FromBody] BaseRequest<int> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.GetGangApplications(req, user);
    }    
    
    
    /// <summary>
    /// Gang applicationi kabul/red etmek icin kullanilir.
    /// </summary>
    /// <remarks>
    /// ### DETAILS ###
    /// <br/>
    /// <br/>
    /// <br/>
    /// Input: BaseRequest &lt; ApplicationAcceptRequest &gt;
    /// <br/>
    /// Output: TDResponse
    /// </remarks>
    [LoginRequired]
    [HttpPost("AcceptGangApplication")]
    public async Task<TDResponse> AcceptGangApplication([FromBody] BaseRequest<ApplicationAcceptRequest> req)
    {
        var user = (HttpContext.Items["User"] as UserDto);
        req.SetUser(user.Id);
        req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        return await _gangService.AcceptGangApplication(req, user);
    }

    
    
}