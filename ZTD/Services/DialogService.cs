using ZTD.Models;
using ZTD.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Helpers;
using SharedLibrary.Models;

namespace ZTD.Services
{

    public class DialogService : IDialogService
    {


        private readonly ILogger<DialogService> _logger;
        private readonly IMapper _mapper;
        private readonly ZTDContext _context;
        private readonly IConfiguration _configuration;

        public DialogService(ILogger<DialogService> logger, ZTDContext context, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        
        public async Task<TDResponse<List<DialogSceneDTO>>> GetDialogScenes(BaseRequest req, UserDto user)
        {
            TDResponse<List<DialogSceneDTO>> response = new TDResponse<List<DialogSceneDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetDialogScenes");
            try
            {
                var query = _context.DialogScene
                    .Include(l => l.Dialogs);
                var dialogSceneDtos = await _mapper.ProjectTo<DialogSceneDTO>(query).ToListAsync();
                
                response.Data = dialogSceneDtos;
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }




    }
}