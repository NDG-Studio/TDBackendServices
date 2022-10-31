using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;
using WebSocket;

[ApiController]
[Route("api/[controller]")]
public class SocketController : ControllerBase
{

    private readonly ILogger<SocketController> _logger;

    public SocketController(ILogger<SocketController> logger)
    {
        _logger = logger;
    }

    [HttpPost("DoCommand")]
    public async Task<List<string>> DoCommand([FromBody] BaseRequest<string> req)
    {
        return ServerProgram.DoCommand(req.Data);
    }

 
    
}