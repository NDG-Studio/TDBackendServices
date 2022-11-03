using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;
using WebSocket.Socket;

[ApiController]
[Route("api/[controller]")]
public class SocketController : ControllerBase
{

    private readonly ILogger<SocketController> _logger;

    public SocketController(ILogger<SocketController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Socket Programa komut vermek icin kullanilir
    /// </summary>
    /// <remarks>
    /// ### COMMANDS ###
    /// <br/>
    /// <br/>
    /// - 'clients' :: Client Sayisini ve player listesini doner
    /// <br/>
    /// - 'stop' :: socketi durdurur
    /// <br/>
    /// - 'start' :: socketi baslatir
    /// <br/>
    /// - 'kick' :: oyuncuyu kickler (ex: 'kick 4')
    /// <br/>
    /// - 'sayto' :: oyuncuya test mesaji yollar (ex: 'sayto 4 blablabla')
    /// <br/>
    /// - 'sayall' :: tum oyunculara test mesaji yollar (ex: 'sayall blablabla')
    /// <br/>
    /// </remarks>
    [OnlyAdmin]
    [HttpPost("DoCommand")]
    public async Task<List<string>> DoCommand([FromBody] BaseRequest<string> req)
    {
        return ServerProgram.DoCommand(req.Data);
    }

 
    
}