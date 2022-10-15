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

        public ProgressService(ILogger<ProgressService> logger, ProgressContext context, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }


        public async Task<TDResponse> AddProgress(BaseRequest<ProgressDTO> req, UserDto UserDto)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "AddProgress");
            try
            {
                if (req.Data == null)
                {
                    info.AddInfo(OperationMessages.GeneralError);
                    response.SetError(OperationMessages.GeneralError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                UserProgressHistory userProgressHistory = new UserProgressHistory()
                {
                    UserId = UserDto.Id,
                    WaveId = req.Data.WaweId,
                    SpentCoin = req.Data.SpentCoin,
                    GainedCoin = req.Data.GainedCoin,
                    TotalCoin = req.Data.TotalCoin,
                    BarrierHealth = req.Data.BarrierHealth,
                    WaveStartTime = DateTimeOffset.Now - new TimeSpan(0, 0, (int)req.Data.Time),
                    WaveEndTime = DateTimeOffset.Now
                };

                await _context.AddAsync(userProgressHistory);
                await _context.SaveChangesAsync();

                List<TowerProgress> qTowerProgress = _mapper.ProjectTo<TowerProgress>(req.Data!.TowerProgressList.AsQueryable()).ToList();
                qTowerProgress.ForEach((l) => { l.UserProgressHistoryId = userProgressHistory.Id; });
                List<EnemyKill> enemyKill = _mapper.ProjectTo<EnemyKill>(req.Data!.EnemyKillList.AsQueryable()).ToList();
                enemyKill.ForEach((l) => { l.UserProgressHistoryId = userProgressHistory.Id; });
                List<UserTowerPlace> userTowerPlace = req.Data.TowerPlaceList.Select(l => new UserTowerPlace() //TODO: Bu kuleleri ekleyebilir mi kontrolü eklenecek
                {
                    PlaceId = l.PlaceId,
                    TowerLevelId = l.TowerLevelId,
                    UserId = UserDto.Id,
                    WaveId = req.Data.WaweId

                }).ToList();

                UserWave? query = await _context.UserWave.Where(l => l.UserId == UserDto.Id).FirstOrDefaultAsync();
                if (query == null)
                {
                    query = new UserWave()
                    {
                        UserId = UserDto.Id,
                        BarierHealth = (int)req.Data.BarrierHealth,
                        TotalCoin = req.Data.TotalCoin,
                        WaveId = req.Data.WaweId
                    };
                    await _context.AddAsync(query);
                }
                else
                {
                    query.BarierHealth = (int)req.Data.BarrierHealth;
                    query.TotalCoin = req.Data.TotalCoin;
                    query.WaveId = req.Data.WaweId;
                }

                await _context.AddRangeAsync(qTowerProgress);
                await _context.AddRangeAsync(enemyKill);
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


        public async Task<TDResponse<List<EnemyDTO>>> GetZombies(BaseRequest req)
        {
            TDResponse<List<EnemyDTO>> response = new TDResponse<List<EnemyDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetZombies");
            try
            {
                //var d = _context.Zombie.Where(l => l.IsActive).OrderBy(l=>l.Id);
                //response.Data = await _mapper.ProjectTo<EnemyDTO>(d).ToListAsync();
                //response.SetSuccess();
                //info.AddInfo(OperationMessages.Success);
                //_logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }

        public async Task<TDResponse<List<TowerDTO>>> GetTowers(BaseRequest req)
        {
            TDResponse<List<TowerDTO>> response = new TDResponse<List<TowerDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetTowers");
            try
            {
                //var d = _context.Tower.Where(l => l.IsActive).OrderBy(l => l.Id);
                //response.Data = await _mapper.ProjectTo<TowerDTO>(d).ToListAsync();
                //response.SetSuccess();
                //info.AddInfo(OperationMessages.Success);
                //_logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }

        public async Task<TDResponse<List<StageDTO>>> GetStages(BaseRequest req)
        {
            TDResponse<List<StageDTO>> response = new TDResponse<List<StageDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetStages");
            try
            {
                //var d = _context.Stage.Where(l => l.IsActive).OrderBy(l => l.Id);
                //response.Data = await _mapper.ProjectTo<StageDTO>(d).ToListAsync();
                //response.SetSuccess();
                //info.AddInfo(OperationMessages.Success);
                //_logger.LogInformation(info.ToString());
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

        public async Task<TDResponse<List<StageStatusDTO>>> GetUserStageStatus(BaseRequest req, UserDto UserDto)
        {
            TDResponse<List<StageStatusDTO>> response = new TDResponse<List<StageStatusDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetUserStageStatus");
            try
            {
                //var d = _context.UserProgress.Include(l => l.Wave).Where(l => l.UserId == UserDto.Id && l.Wave != null).ToList();
                //var ek = d.GroupBy(l => l.WaveId).Select(l=> l.MaxBy(k=>k.));
                //response.Data = _mapper.ProjectTo<StageStatusDTO>(ek.AsQueryable()).ToList();
                //response.SetSuccess();
                //info.AddInfo(OperationMessages.Success);
                //_logger.LogInformation(info.ToString());
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

        public async Task<TDResponse<UserTDInfoDTO>> GetNextWave(BaseRequest req, UserDto user)
        {
            TDResponse<UserTDInfoDTO> response = new TDResponse<UserTDInfoDTO>();
            var info = InfoDetail.CreateInfo(req, "GetNextWave");
            try
            {
                UserWave? userWave = await _context.UserWave.Include(l => l.Wave).Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                List<WaveDetail> waveDetail = new List<WaveDetail>();
                Wave? nextWave = null;
                if (userWave == null)
                {
                    waveDetail = await _context.WaveDetail.Include(l => l.Enemy).Include(l => l.Wave).ThenInclude(l => l.Stage)
                        .Where(l => l.Wave.Stage.Id == 11 && l.Wave.OrderId == 1).OrderBy(l => l.PlaceId)
                        .ToListAsync();
                    nextWave = waveDetail.FirstOrDefault()?.Wave;
                }
                else
                {
                    nextWave = await _context.Wave
                        .Where(l =>
                            (l.OrderId == userWave.Wave.OrderId + 1 && l.StageId == userWave.Wave.StageId)
                            ||
                            (l.OrderId == 1 && l.StageId == userWave.Wave.StageId + 1)
                        )
                        .OrderBy(l => l.StageId)
                        .FirstOrDefaultAsync();
                    if (nextWave == null)
                    {
                        info.AddInfo(OperationMessages.MaxLevel);
                        response.SetError(OperationMessages.MaxLevel);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                    waveDetail = await _context.WaveDetail.Include(l => l.Enemy).Include(l => l.Wave).ThenInclude(l => l.Stage)
                        .Where(l => l.WaveId == nextWave.Id).OrderBy(l => l.PlaceId)
                        .ToListAsync();
                }

                if (waveDetail.Count == 0)
                {
                    info.AddInfo(OperationMessages.GeneralError);
                    response.SetError(OperationMessages.GeneralError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var stageDto = _mapper.Map<StageDTO>(waveDetail[0].Wave.Stage);
                var quserTowerStatus =_context.UserTowerPlace.Include(l => l.TowerLevel).ThenInclude(l=>l.Tower)
                    .Where(l => l.UserId == user.Id && l.WaveId == userWave!.WaveId);
                var creatableTowers = new List<CreatableTowerDTO>();
                var qq= await _context.TowerLevel.Include(l => l.Tower).Where(l => l.Tower.IsActive).OrderBy(l=>l.TowerId).ThenBy(l=>l.Level).ToListAsync();

                var groupedLevels=qq.GroupBy(l => l.Tower);

                foreach (var tl in groupedLevels)
                {
                    creatableTowers.Add(new CreatableTowerDTO() {
                        
                        Tower=_mapper.Map<TowerDTO>(tl.Key),
                        TowerLevelList=_mapper.ProjectTo<TowerLevelDTO>(tl.ToList().AsQueryable()).ToList()
                    
                    });

                }
                var waveDetailList = new List<WaveDetailDTO>();
                foreach (var wd in waveDetail)
                {
                    var ed = await _context.EnemyLevel.Where(l => l.EnemyId == wd.EnemyId && l.Level == wd.EnemyLevel).FirstOrDefaultAsync();
                    waveDetailList.Add(new WaveDetailDTO() {
                    EnemyId=wd.EnemyId,
                    EnemyName=wd.Enemy.Name,
                    EnemyLevel=wd.EnemyLevel,
                    EnemyNumber=wd.EnemyNumber,
                    EntryInterval=wd.EntryInterval,
                    EntryPoint=wd.EntryPoint,
                    EntryTime=wd.EntryTime,
                    PlaceId=wd.PlaceId,
                    EnemyDetail= new EnemyDetailDTO() { 
                        EnemyLevelId=ed.Id,
                        Armor=ed.Armor,
                        Coin=ed.Coin,
                        BarierDamageAmount=ed.BarierDamageAmount,
                        Health=ed.Health,
                        Speed=ed.Speed
                        
                    }
                    
                    
                    });
                }

                response.Data = new UserTDInfoDTO()
                {
                    WaveId = nextWave!.Id,
                    Stage = stageDto,
                    WaveOrderId = nextWave!.OrderId,
                    TotalCoin = nextWave!.OrderId == 1 ? waveDetail[0].Wave.Stage.Coin : userWave!.TotalCoin,
                    BarrierHealth = userWave?.BarierHealth ?? waveDetail[0].Wave.Stage.BarrierHealth,
                    UserTowerStatusList = nextWave!.OrderId == 1 ? new List<UserTowerStatusDTO>() : await _mapper.ProjectTo<UserTowerStatusDTO>(quserTowerStatus).ToListAsync(),
                    WaveDetailList = waveDetailList,
                    CreatableTowerList =creatableTowers
                };


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