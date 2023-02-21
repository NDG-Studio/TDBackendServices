using Microsoft.AspNetCore.Mvc;
using ZTD.Interfaces;
using ZTD.Models;
using SharedLibrary.Models;

namespace ZTD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DialogController : ControllerBase
    {

        private readonly ILogger<DialogController> _logger;
        private readonly IDialogService _service;

        public DialogController(ILogger<DialogController> logger, IDialogService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// code degerine bagli olarak tum dialoglari doner
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse &lt; List &lt; DialogSceneDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetDialogScenes")]
        public async Task<TDResponse<List<DialogSceneDTO>>> GetDialogScenes([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.GetDialogScenes(req, user);
        }
        
    }
}