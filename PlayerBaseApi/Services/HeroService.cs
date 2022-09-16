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

        public async Task<TDResponse<List<HeroLevelThresholdDTO>>> GetHeroesThresholds(BaseRequest req, UserDto user)
        {
            TDResponse<List<HeroLevelThresholdDTO>> response = new TDResponse<List<HeroLevelThresholdDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetHeroesThresholds");
            try
            {
                var query = _context.HeroLevelThreshold.Where(l => l.Hero.IsActive);
                var qlist = await _mapper.ProjectTo<HeroLevelThresholdDTO>(query).ToListAsync();
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


        public async Task<TDResponse<bool>> AddHeroExperience(BaseRequest<AddHeroExperienceRequest> req, UserDto user)
        {
            TDResponse<bool> response = new TDResponse<bool>();
            var info = InfoDetail.CreateInfo(req, "AddHeroExperience");
            try
            {
                var pH = await _context.PlayerHero.Include(l => l.Hero)
                    .Where(l => l.UserId == user.Id && l.HeroId == req.Data.HeroId && l.EndDate == null ).FirstOrDefaultAsync();
                if(pH == null)
                {
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    response.SetError(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (pH.CurrentLevel >= pH.Hero.MaxLevel)
                {
                    info.AddInfo(OperationMessages.HeroAllreadyMaxLevel);
                    response.SetError(OperationMessages.HeroAllreadyMaxLevel);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var threshold = await _context.HeroLevelThreshold
                    .Where(l => l.HeroId == req.Data.HeroId && l.Level == pH.CurrentLevel + 1)
                    .Select(l => l.Experience).FirstOrDefaultAsync();
                pH.Exp += req.Data.Experience;

                response.Data = false;
                if (pH.Exp >= threshold)
                {
                    pH.CurrentLevel = await _context.HeroLevelThreshold
                        .Where(l => l.HeroId == pH.HeroId && l.Experience <= pH.Exp)
                        .OrderByDescending(l => l.Level).Select(l => l.Level).FirstOrDefaultAsync();
                    response.Data = true;
                }
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
