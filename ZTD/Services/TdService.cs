using ZTD.Models;
using ZTD.Entities;
using ZTD.Interfaces;
using AutoMapper;
using SharedLibrary.Helpers;
using SharedLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ZTD.Services
{

    public class TdService : ITdService
    {


        private readonly ILogger<TdService> _logger;
        private readonly IMapper _mapper;
        private readonly ZTDContext _context;
        private readonly IConfiguration _configuration;

        public TdService(ILogger<TdService> logger, ZTDContext context, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        
        public async Task<TDResponse<ChapterInfoDTO>> GetChapterInfo(BaseRequest req, UserDto user)
        {
                TDResponse<ChapterInfoDTO> response = new TDResponse<ChapterInfoDTO>();
                var info = InfoDetail.CreateInfo(req, "GetPlayerChapterInfo");

                try
                {
                    var userStatus =await _context.UserTdStatus.Include(l=>l.Level).Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                    var chapterId = 1;
                    if (userStatus?.TdLevelId !=null)
                    {
                        chapterId = userStatus.Level.ChapterId;
                    }
                    var query = _context.Chapter.Include(l => l.Levels)
                        .Where(l => l.Id == chapterId);
                    var chapter = await _mapper.ProjectTo<ChapterInfoDTO>(query).FirstOrDefaultAsync();

                    var userLevels = await _context.UserProgressHistory
                        .Where(l => l.UserId == user.Id && l.GainedStar > 0 && l.Level.ChapterId == chapter.Id)
                        .GroupBy(l=>l.LevelId)
                        .Select(l=>l.OrderByDescending(x=>x.GainedStar).First())
                        .ToListAsync();

                    foreach (var o in userLevels)
                    {
                        var cc = chapter.Levels.FirstOrDefault(l => l.Id == o.LevelId);
                        if (cc!=null)
                        {
                            cc.UserStar = o.GainedStar;
                        }
                    }
                    
                    response.Data = chapter;
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
        public async Task<TDResponse<List<LevelDTO>>> GetLevels(BaseRequest<List<int>> req, UserDto user)
        {
            TDResponse<List<LevelDTO>> response = new TDResponse<List<LevelDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetLevels");

            try
            {
                var chapterId = 1;
                var userStatus = await _context.UserTdStatus.Include(l=>l.Level)
                    .Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (userStatus!=null)
                {
                    chapterId = await _context.Level.Where(l => l.OrderId == userStatus.Level.OrderId + 1)
                        .Select(l=>l.ChapterId)
                        .FirstOrDefaultAsync();
                }

                var query = _context.Level.Include(l => l.Waves).ThenInclude(l=>l.WaveParts)
                    .Where(l => req.Data == null ? l.ChapterId == chapterId : req.Data.Contains(l.Id));
                
                var levelDtos = await _mapper.ProjectTo<LevelDTO>(query).ToListAsync();
                response.Data = levelDtos;
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
        public async Task<TDResponse<List<TowerDTO>>> GetTowers(BaseRequest req, UserDto userDto)
        {
            TDResponse<List<TowerDTO>> response = new TDResponse<List<TowerDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetTowers");

            try
            {
                var query = _context.Tower.Include(l => l.TowerLevels);
                var towerLevelDtos = await _mapper.ProjectTo<TowerDTO>(query).ToListAsync();
                
                // todo: burada player bazli degisiklikler yapilacak
                
                response.Data = towerLevelDtos;
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
        
        public async Task<TDResponse<List<EnemyDTO>>> GetEnemyList(BaseRequest req, UserDto userDto)
        {
            TDResponse<List<EnemyDTO>> response = new TDResponse<List<EnemyDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetEnemyList");

            try
            {
                var query = _context.Enemy.Include(l => l.EnemyLevels).Where(l=>l.IsActive);
                var enemyLevelDtos = await _mapper.ProjectTo<EnemyDTO>(query).ToListAsync();
                
                response.Data = enemyLevelDtos;
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
        
        public async Task<TDResponse<List<TableChangesDTO>>> GetSyncStatus(BaseRequest req, UserDto user)
        {
            TDResponse<List<TableChangesDTO>> response = new TDResponse<List<TableChangesDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetSyncStatus");

            try
            {
                var userLastSyncDate = await _context.User
                    .Where(l => l.Id == user.Id)
                    .Select(l => l.TdSyncDate).FirstOrDefaultAsync();
                if (userLastSyncDate==null)
                {
                    userLastSyncDate=DateTimeOffset.MinValue;
                }
                
                var query = _context.TableChanges.Where(l=>l.LastChangeDate > userLastSyncDate);
                var tableChangesDtos = await _mapper.ProjectTo<TableChangesDTO>(query).ToListAsync();
                
                response.Data = tableChangesDtos;
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

        public async Task<TDResponse> AddProgressList(BaseRequest<List<ProgressDTO>> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "AddProgressList");

            try
            {
                if (req.Data==null)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                foreach (var p in req.Data)
                {
                    var userProgressHistory = new UserProgressHistory();
                    userProgressHistory.UserId = user.Id;
                    userProgressHistory.LevelId = p.LevelId;
                    userProgressHistory.GainedStar = p.StarCount;
                    userProgressHistory.BarrierHealth = p.BarrierHealth;
                    userProgressHistory.GainedCoin = p.GainedCoin;
                    userProgressHistory.SpentCoin = p.SpentCoin;
                    userProgressHistory.TotalCoin = p.TotalCoin;
                    userProgressHistory.WaveStartTime = p.WaveStartTime.ToDateTimeOffsetUtc() ?? DateTimeOffset.UtcNow;
                    userProgressHistory.WaveEndTime = userProgressHistory.WaveStartTime + TimeSpan.FromSeconds(p.TimeSecond);
                    await _context.AddAsync(userProgressHistory);
                    await _context.SaveChangesAsync();
                    await _context.AddRangeAsync(p.EnemyKillList.Select(l => new EnemyKill()
                    {
                        UserProgressHistoryId = userProgressHistory.Id,
                        DeadCount = l.DeadCount,
                        EnemyLevelId = l.EnemyLevelId
                    }).ToList());
                    await _context.SaveChangesAsync();
                    await _context.AddRangeAsync(p.TowerProgressList.Select(l=> new TowerProgress()
                    {
                        UserProgressHistoryId = userProgressHistory.Id,
                        TowerId = l.TowerId,
                        TowerCount = l.TowerCount,
                        TowerDamage = l.TowerDamage,
                        TowerArmorDamage = l.TowerArmorDamage,
                        TowerDotDamage = l.TowerDotDamage,
                        TowerFireCount = l.TowerFireCount,
                        TowerUpgradeNumber = l.TowerUpgradeNumber
                    }).ToList());
                    await _context.SaveChangesAsync();

                }
                
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