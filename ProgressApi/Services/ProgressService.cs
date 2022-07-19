using ProgressApi.Models;
using ProgressApi.Entities;
using ProgressApi.Interfaces;
using AutoMapper;
using SharedLibrary.Helpers;
using SharedLibrary.Models;

namespace ProgressApi.Services
{

    public class ProgressService : IProgressService
    {


        private readonly ILogger<ProgressService> _logger;
        private readonly IMapper _mapper;
        private readonly ProgressContext _context;
        private readonly IConfiguration _configuration;

        public ProgressService(ILogger<ProgressService> logger, ProgressContext context, IMapper mapper,IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _configuration=configuration;
        }


        public async Task<TDResponse> AddProgress(BaseRequest<ProgressDto> req,UserDto userDto)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "AddProgress");
            try
            {
                var pr = _mapper.Map<UserProgress>(req.Data);
                pr.Ip = req.Info.Ip;
                pr.UserId = userDto.Id;
                pr.Username = userDto.Username;
                pr.Email = userDto.Email;
                await _context.AddAsync(pr);
                await _context.SaveChangesAsync();
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