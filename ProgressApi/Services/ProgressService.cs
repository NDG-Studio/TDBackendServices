using ProgressApi.Models;
using ProgressApi.Entities;
using ProgressApi.Interfaces;
using AutoMapper;
using SharedLibrary.Helpers;
using SharedLibrary.Models;
using Microsoft.EntityFrameworkCore;

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

                var qTowerProgress = _mapper.ProjectTo<TowerProgress>(req.Data!.TowerProgressList.AsQueryable()).ToList();
                qTowerProgress.ForEach((l) => { l.UserProgressId = pr.Id; });
                var qZombieKill = _mapper.ProjectTo<ZombieKill>(req.Data!.ZombieKillList.AsQueryable()).ToList();
                qZombieKill.ForEach((l) => { l.UserProgressId = pr.Id; });

                await _context.AddRangeAsync(qTowerProgress);
                await _context.AddRangeAsync(qZombieKill);
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


        public async Task<TDResponse<List<ZombieDto>>> GetZombies(BaseRequest req)
        {
            TDResponse<List<ZombieDto>> response = new TDResponse<List<ZombieDto>>();
            var info = InfoDetail.CreateInfo(req, "GetZombies");
            try
            {
                var d = _context.Zombie.Where(l => l.IsActive).OrderBy(l=>l.Id);
                response.Data = await _mapper.ProjectTo<ZombieDto>(d).ToListAsync();
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

        public async Task<TDResponse<List<TowerDto>>> GetTowers(BaseRequest req)
        {
            TDResponse<List<TowerDto>> response = new TDResponse<List<TowerDto>>();
            var info = InfoDetail.CreateInfo(req, "GetTowers");
            try
            {
                var d = _context.Tower.Where(l => l.IsActive).OrderBy(l => l.Id);
                response.Data = await _mapper.ProjectTo<TowerDto>(d).ToListAsync();
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

        public async Task<TDResponse<List<StageDto>>> GetStages(BaseRequest req)
        {
            TDResponse<List<StageDto>> response = new TDResponse<List<StageDto>>();
            var info = InfoDetail.CreateInfo(req, "GetStages");
            try
            {
                var d = _context.Stage.Where(l => l.IsActive).OrderBy(l => l.Id);
                response.Data = await _mapper.ProjectTo<StageDto>(d).ToListAsync();
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                var cc = info.ToString();
                _logger.LogError(cc);
            }

            return response;
        }

        public async Task<TDResponse<List<StageStatusDto>>> GetUserStageStatus(BaseRequest req, UserDto userDto)
        {
            TDResponse<List<StageStatusDto>> response = new TDResponse<List<StageStatusDto>>();
            var info = InfoDetail.CreateInfo(req, "GetUserStageStatus");
            try
            {
                var d = _context.UserProgress.Include(l => l.Stage).Where(l => l.UserId == userDto.Id && l.StageId != null).ToList();
                var ek = d.GroupBy(l => l.StageId).Select(l=> l.MaxBy(k=>k.Score));
                response.Data = _mapper.ProjectTo<StageStatusDto>(ek.AsQueryable()).ToList();
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                var cc = info.ToString();
                _logger.LogError(cc);
            }

            return response;
        }



    }
}