using System.Text;
using ProgressApi.Models;
using ProgressApi.Entities;
using ProgressApi.Interfaces;
using AutoMapper;
using SharedLibrary.Helpers;
using SharedLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
                    WaveId = req.Data.WaveId,
                    SpentCoin = req.Data.SpentCoin,
                    GainedCoin = req.Data.GainedCoin,
                    TotalCoin = req.Data.TotalCoin,
                    BarrierHealth = req.Data.BarrierHealth,
                    WaveStartTime = DateTimeOffset.Now - new TimeSpan(0, 0, (int)req.Data.Time),
                    WaveEndTime = DateTimeOffset.Now
                };

                await _context.AddAsync(userProgressHistory);
                await _context.SaveChangesAsync();

                if (userProgressHistory.BarrierHealth <= 0)
                {
                    response.SetSuccess();
                    info.AddInfo(OperationMessages.Success);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                List<TowerProgress> qTowerProgress = _mapper.ProjectTo<TowerProgress>(req.Data!.TowerProgressList.AsQueryable()).ToList();
                qTowerProgress.ForEach((l) => { l.UserProgressHistoryId = userProgressHistory.Id; });
                List<EnemyKill> enemyKill = _mapper.ProjectTo<EnemyKill>(req.Data!.EnemyKillList.AsQueryable()).ToList();
                enemyKill.ForEach((l) => { l.UserProgressHistoryId = userProgressHistory.Id; });
                List<UserTowerPlace> userTowerPlace = req.Data.TowerPlaceList.Where(l=>l.TowerLevelId != null && l.TowerLevelId != 0).Select(l => new UserTowerPlace()
                {
                    PlaceId = l.PlaceId,
                    TowerLevelId = l.TowerLevelId,
                    UserId = UserDto.Id,
                    WaveId = req.Data.WaveId

                }).ToList();

                UserWave? query = await _context.UserWave.Where(l => l.UserId == UserDto.Id).FirstOrDefaultAsync();
                if (query == null)
                {
                    query = new UserWave()
                    {
                        UserId = UserDto.Id,
                        BarierHealth = (int)req.Data.BarrierHealth,
                        TotalCoin = req.Data.TotalCoin,
                        WaveId = req.Data.WaveId
                    };
                    await _context.AddAsync(query);
                }
                else
                {
                    query.BarierHealth = (int)req.Data.BarrierHealth;
                    query.TotalCoin = req.Data.TotalCoin;
                    query.WaveId = req.Data.WaveId;
                }

                await _context.AddRangeAsync(qTowerProgress);
                await _context.AddRangeAsync(userTowerPlace);
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

        public async Task<TDResponse> ResetLevel(BaseRequest req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "ResetLevel");

            try
            {


                UserWave? query = await _context.UserWave.Include(l => l.Wave).Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (query == null)
                {
                    info.AddInfo(OperationMessages.NoChanges);
                    response.SetError(OperationMessages.NoChanges);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                _context.RemoveRange(_context.UserTowerPlace.Where(l => l.UserId == user.Id && l.Wave.StageId == query.Wave.StageId));
                if (query.Wave.StageId != 1)
                {
                    query.WaveId = await _context.Wave.Where(l => l.StageId == query.Wave.StageId - 1).OrderByDescending(l => l.OrderId).Select(l => l.Id).FirstOrDefaultAsync();
                }
                else
                {
                    _context.Remove(query);
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
                if (userWave != null && userWave.Wave.StageId == Int32.Parse(Environment.GetEnvironmentVariable("TutorialLastLevel")))
                {
                    _context.Remove(userWave);
                    await _context.SaveChangesAsync();
                    userWave = null;
                }
                if (userWave == null)
                {

                    waveDetail = await _context.WaveDetail.Include(l => l.Enemy).Include(l => l.Wave).ThenInclude(l => l.Stage)
                        .Where(l => l.Wave.Stage.Id == 1 && l.Wave.OrderId == 1).OrderBy(l => l.PlaceId)
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
                var quserTowerStatus = _context.UserTowerPlace.Include(l => l.TowerLevel).ThenInclude(l => l.Tower)
                    .Where(l => l.UserId == user.Id && l.WaveId == userWave!.WaveId);
                var creatableTowers = new List<CreatableTowerDTO>();
                
                var towerLevels = Environment.GetEnvironmentVariable("DefaultTowerLevels").Split(',')
                    .Select(l => new TowerLevelPair
                    {
                        TowerId = Int32.Parse(l.Split('-')[0]),
                        TowerLevel = Int32.Parse(l.Split('-')[1])
                    }).ToList();
                var researchTowers = await GetActiveTowerLevels(user.Id);
                
                if (researchTowers is { HasError: false, Data: { } })
                {
                    towerLevels.AddRange(researchTowers.Data);
                }
                
                var qq = await _context.TowerLevel.Include(l => l.Tower).Where(l => l.Tower.IsActive).OrderBy(l => l.TowerId).ThenBy(l => l.Level).ToListAsync();

                var groupedLevels = qq.GroupBy(l => l.Tower);
                
                
                foreach (var tl in groupedLevels)
                {
                    var thatTowerLevels = towerLevels.Where(l => l.TowerId == tl.Key.Id).Select(l=>l.TowerLevel).ToList();
                    // if (thatTowerLevels.Count == 0)
                    // {
                    //     continue;
                    // }
                    
                    creatableTowers.Add(new CreatableTowerDTO()
                    {

                        Tower = _mapper.Map<TowerDTO>(tl.Key),
                        TowerLevelList = _mapper.ProjectTo<TowerLevelDTO>(tl.ToList().AsQueryable()).ToList()
                    //        .Where(l=>thatTowerLevels.Contains(l.Level)).ToList()

                    });

                }
                var waveDetailList = new List<WaveDetailDTO>();
                foreach (var wd in waveDetail)
                {
                    var ed = await _context.EnemyLevel.Where(l => l.EnemyId == wd.EnemyId && l.Level == wd.EnemyLevel).FirstOrDefaultAsync();
                    waveDetailList.Add(new WaveDetailDTO()
                    {
                        EnemyId = wd.EnemyId,
                        EnemyName = wd.Enemy.Name,
                        EnemyLevel = wd.EnemyLevel,
                        EnemyNumber = wd.EnemyNumber,
                        EntryInterval = wd.EntryInterval,
                        EntryPoint = wd.EntryPoint,
                        EntryTime = wd.EntryTime,
                        PlaceId = wd.PlaceId,
                        EnemyDetail = new EnemyDetailDTO()
                        {
                            EnemyLevelId = ed.Id,
                            Armor = ed.Armor,
                            Coin = ed.Coin,
                            BarierDamageAmount = ed.BarierDamageAmount,
                            Health = ed.Health,
                            Speed = ed.Speed

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
                    CreatableTowerList = creatableTowers
                };

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

        public async Task<TDResponse> AddTutorialProgress(BaseRequest<ProgressDTO> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "AddTutorialProgress");

            try
            {
                if (req.Data == null || req.Info == null)
                {
                    info.AddInfo(OperationMessages.GeneralError);
                    response.SetError(OperationMessages.GeneralError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                UserProgressHistory userProgressHistory = new UserProgressHistory()
                {
                    UserId = user.Id,
                    WaveId = req.Data.WaveId,
                    SpentCoin = req.Data.SpentCoin,
                    GainedCoin = req.Data.GainedCoin,
                    TotalCoin = req.Data.TotalCoin,
                    BarrierHealth = req.Data.BarrierHealth,
                    WaveStartTime = DateTimeOffset.Now - new TimeSpan(0, 0, (int)req.Data.Time),
                    WaveEndTime = DateTimeOffset.Now
                };

                await _context.AddAsync(userProgressHistory);
                await _context.SaveChangesAsync();

                if (userProgressHistory.BarrierHealth <= 0)
                {
                    response.SetSuccess();
                    info.AddInfo(OperationMessages.Success);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                List<TowerProgress> qTowerProgress = _mapper.ProjectTo<TowerProgress>(req.Data!.TowerProgressList.AsQueryable()).ToList();
                qTowerProgress.ForEach((l) => { l.UserProgressHistoryId = userProgressHistory.Id; });
                List<EnemyKill> enemyKill = _mapper.ProjectTo<EnemyKill>(req.Data!.EnemyKillList.AsQueryable()).ToList();
                enemyKill.ForEach((l) => { l.UserProgressHistoryId = userProgressHistory.Id; });

                UserWave? query = await _context.UserWave.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (query == null)
                {
                    query = new UserWave()
                    {
                        UserId = user.Id,
                        BarierHealth = (int)req.Data.BarrierHealth,
                        TotalCoin = req.Data.TotalCoin,
                        WaveId = req.Data.WaveId
                    };
                    await _context.AddAsync(query);
                }
                else
                {
                    query.BarierHealth = (int)req.Data.BarrierHealth;
                    query.TotalCoin = req.Data.TotalCoin;
                    query.WaveId = req.Data.WaveId;
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

        public async Task<TDResponse<UserTDInfoDTO>> GetTutorialWave(BaseRequest req, UserDto user)
        {
            TDResponse<UserTDInfoDTO> response = new TDResponse<UserTDInfoDTO>();
            var info = InfoDetail.CreateInfo(req, "GetTutorialWave");
            try
            {
                UserWave? userWave = await _context.UserWave.Include(l => l.Wave).Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                List<WaveDetail> waveDetail = new List<WaveDetail>();
                Wave? nextWave = null;
                if (userWave == null)
                {
                    waveDetail = await _context.WaveDetail.Include(l => l.Enemy).Include(l => l.Wave).ThenInclude(l => l.Stage)
                        .Where(l => l.Wave.Stage.Id == 900 && l.Wave.OrderId == 1).OrderBy(l => l.PlaceId)
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
                var creatableTowers = new List<CreatableTowerDTO>();
                var qq = await _context.TowerLevel.Include(l => l.Tower).Where(l => l.Tower.IsActive).OrderBy(l => l.TowerId).ThenBy(l => l.Level).ToListAsync();

                var groupedLevels = qq.GroupBy(l => l.Tower);

                foreach (var tl in groupedLevels)
                {
                    creatableTowers.Add(new CreatableTowerDTO()
                    {

                        Tower = _mapper.Map<TowerDTO>(tl.Key),
                        TowerLevelList = _mapper.ProjectTo<TowerLevelDTO>(tl.ToList().AsQueryable()).ToList()

                    });

                }
                var waveDetailList = new List<WaveDetailDTO>();
                foreach (var wd in waveDetail)
                {
                    var ed = await _context.EnemyLevel.Where(l => l.EnemyId == wd.EnemyId && l.Level == wd.EnemyLevel).FirstOrDefaultAsync();
                    waveDetailList.Add(new WaveDetailDTO()
                    {
                        EnemyId = wd.EnemyId,
                        EnemyName = wd.Enemy.Name,
                        EnemyLevel = wd.EnemyLevel,
                        EnemyNumber = wd.EnemyNumber,
                        EntryInterval = wd.EntryInterval,
                        EntryPoint = wd.EntryPoint,
                        EntryTime = wd.EntryTime,
                        PlaceId = wd.PlaceId,
                        EnemyDetail = new EnemyDetailDTO()
                        {
                            EnemyLevelId = ed.Id,
                            Armor = ed.Armor,
                            Coin = ed.Coin,
                            BarierDamageAmount = ed.BarierDamageAmount,
                            Health = ed.Health,
                            Speed = ed.Speed

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
                    UserTowerStatusList = new List<UserTowerStatusDTO>(),
                    WaveDetailList = waveDetailList,
                    CreatableTowerList = creatableTowers
                };

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


        private static async Task<TDResponse<List<TowerLevelPair>>> GetActiveTowerLevels(long userId)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                { return true; }; //TODO: Prodda silinmeli

            using (HttpClient client = new HttpClient(handler))
            {

                var response = client.PostAsync(new Uri(Environment.GetEnvironmentVariable("PlayerBaseUrl") + "/api/PlayerBase/GetActiveTowers"),
                    new StringContent(JsonConvert.SerializeObject(
                        new BaseRequest<long>()
                        {
                            Data = userId,
                            Info = new InfoDto()
                            {
                                DeviceId = "_mapapi_",
                                OsVersion = "_mapapi_",
                                AppVersion = "_mapapi_",
                                DeviceModel = "_mapapi_",
                                DeviceType = "_mapapi_",
                                UserId = 0,
                                Ip = "_mapapi_"
                            }
                        }
                    ), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var res = JsonConvert.DeserializeObject<TDResponse<List<TowerLevelPair>>>(content);
                    return res;
                }
                return null;
            }
        }

    }
}