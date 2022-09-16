using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlayerBaseApi.Entities;
using PlayerBaseApi.Interfaces;
using PlayerBaseApi.Models;
using SharedLibrary.Helpers;
using SharedLibrary.Models;

namespace PlayerBaseApi.Services
{
    public class HeroService : IHeroService
    {
        private readonly ILogger<HeroService> _logger;
        private readonly IMapper _mapper;
        private readonly PlayerBaseContext _context;
        private readonly IConfiguration _configuration;

        public HeroService(ILogger<HeroService> logger, PlayerBaseContext context, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<TDResponse<List<HeroDTO>>> GetHeroTypes(BaseRequest req, UserDto user)
        {
            TDResponse<List<HeroDTO>> response = new TDResponse<List<HeroDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetHeroTypes");
            try
            {
                var query = _context.Hero.Where(l => l.IsActive);
                var qlist = await _mapper.ProjectTo<HeroDTO>(query).ToListAsync();
                response.Data = qlist;
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

        public async Task<TDResponse<List<PlayerHeroDTO>>> GetPlayerHeroes(BaseRequest req, UserDto user)
        {
            TDResponse<List<PlayerHeroDTO>> response = new TDResponse<List<PlayerHeroDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetPlayerHeroes");
            try
            {
                var query = _context.PlayerHero.Include(l => l.Hero).Where(l => l.Hero.IsActive && l.UserId == user.Id);
                var qlist = await _mapper.ProjectTo<PlayerHeroDTO>(query).ToListAsync();
                response.Data = qlist;
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
