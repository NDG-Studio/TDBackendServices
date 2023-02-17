using ZTD.Models;
using ZTD.Entities;
using ZTD.Interfaces;
using AutoMapper;
using SharedLibrary.Helpers;
using SharedLibrary.Models;
using Microsoft.EntityFrameworkCore;
using ZTD.Enums;

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
                    await SyncPlayerTable( new []{
                        TableEnum.Chapter
                    }, user);
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

                var query = _context.Level
                    .Include(l => l.Waves).ThenInclude(l=>l.WaveParts)
                    .Include(l=>l.LevelGifts)
                    .Include(l=>l.LevelChestChances)
                    .Where(l => req.Data == null ? l.ChapterId == chapterId : req.Data.Contains(l.Id));
                
                var levelDtos = await _mapper.ProjectTo<LevelDTO>(query).ToListAsync();
                response.Data = levelDtos;
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
                await SyncPlayerTable( new []{
                    TableEnum.Level,
                    TableEnum.Wave,
                    TableEnum.WavePart,
                    TableEnum.LevelGift,
                    TableEnum.LevelChestChance
                }, user);

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }
        public async Task<TDResponse<List<TowerDTO>>> GetTowers(BaseRequest req, UserDto user)
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
                await SyncPlayerTable(new []
                {
                    TableEnum.Tower,
                    TableEnum.TowerLevel
                }, user);

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }        
        
        public async Task<TDResponse<List<EnemyDTO>>> GetEnemyList(BaseRequest req, UserDto user)
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
                await SyncPlayerTable(new []
                {
                    TableEnum.Enemy,
                    TableEnum.EnemyLevel
                }, user);

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }
                
        public async Task<TDResponse<List<ItemDTO>>> GetItems(BaseRequest req, UserDto user)
        {
            TDResponse<List<ItemDTO>> response = new TDResponse<List<ItemDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetItems");

            try
            {
                var query = _context.Item.Where(l=>l.IsActive);
                var itemDtos = await _mapper.ProjectTo<ItemDTO>(query).ToListAsync();
                
                response.Data = itemDtos;
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
                await SyncPlayerTable(new []
                {
                    TableEnum.Item
                }, user);

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }                
        
        public async Task<TDResponse<List<ChestTypeDTO>>> GetChestTypes(BaseRequest req, UserDto user)
        {
            TDResponse<List<ChestTypeDTO>> response = new TDResponse<List<ChestTypeDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetChestTypes");

            try
            {
                var query = _context.ChestType.Include(l=>l.Chests.Where(k=>k.IsActive))
                    .Where(l=>l.IsActive);
                var chestTypeDtos = await _mapper.ProjectTo<ChestTypeDTO>(query).ToListAsync();
                
                response.Data = chestTypeDtos;
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
                await SyncPlayerTable( new []{
                    TableEnum.ChestType,
                    TableEnum.Chest
                }, user);

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }      
        
        public async Task<TDResponse<List<PlayerChestDTO>>> GetPlayerChests(BaseRequest req, UserDto user)
        {
            TDResponse<List<PlayerChestDTO>> response = new TDResponse<List<PlayerChestDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetPlayerChests");
            try
            {
                var query = _context.PlayerChest
                    .Where(l=> l.Chest.IsActive && l.UserId == user.Id && l.SlotPlace > 0);
                var playerChestTypeDtos = await _mapper.ProjectTo<PlayerChestDTO>(query).ToListAsync();
                
                response.Data = playerChestTypeDtos;
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
        
        public async Task<TDResponse<List<PlayerItemDTO>>> GetPlayerItems(BaseRequest req, UserDto user)
        {
            TDResponse<List<PlayerItemDTO>> response = new TDResponse<List<PlayerItemDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetPlayerItems");
            try
            {
                var query = _context.PlayerItem.Include(l=>l.Item)
                    .Where(l=> l.Item.IsActive && l.UserId == user.Id);
                var playerItemDtos = await _mapper.ProjectTo<PlayerItemDTO>(query).ToListAsync();
                
                response.Data = playerItemDtos;
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
        
        public async Task<TDResponse<List<PlayerItemDTO>>> SetPlayerItems(BaseRequest<List<PlayerItemDTO>> req, UserDto user)
        {
            TDResponse<List<PlayerItemDTO>> response = new TDResponse<List<PlayerItemDTO>>();
            var info = InfoDetail.CreateInfo(req, "SetPlayerItems");
            try
            {
                if (req.Data==null)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                foreach (var ld in req.Data)
                {
                    if (ld.Id==0)
                    {
                        await _context.AddAsync(new PlayerItem()
                        {
                            UserId = user.Id,
                            ItemId = ld.ItemId,
                            Count = ld.Count,
                        });
                    }
                    else
                    {
                        var ent = await _context.PlayerItem.Where(l => l.UserId == user.Id && l.Id == ld.Id)
                            .FirstOrDefaultAsync();
                        if (ent != null)
                        {
                            ent.Count = ld.Count;
                        }

                    }
                    
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

        
        public async Task<TDResponse<PlayerVariableDTO>> GetPlayerVariable(BaseRequest req, UserDto user)
        {
            TDResponse<PlayerVariableDTO> response = new TDResponse<PlayerVariableDTO>();
            var info = InfoDetail.CreateInfo(req, "GetPlayerVariable");
            try
            {
                var query = _context.PlayerVariable
                    .Where(l=> l.UserId == user.Id );
                var playerVariable = await _mapper.ProjectTo<PlayerVariableDTO>(query).FirstOrDefaultAsync();
                
                response.Data = playerVariable;
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
        
        public async Task<TDResponse<PlayerVariableDTO>> SetPlayerVariable(BaseRequest<PlayerVariableDTO> req, UserDto user)
        {
            TDResponse<PlayerVariableDTO> response = new TDResponse<PlayerVariableDTO>();
            var info = InfoDetail.CreateInfo(req, "SetPlayerVariable");
            try
            {
                var query = await _context.PlayerVariable
                    .Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (query==null)
                {
                    await _context.AddAsync(new PlayerVariable()
                    {
                        UserId = user.Id,
                        GemCount = req.Data?.GemCount ?? 0,
                        ResearchPoint = req.Data?.ResearchPoint ?? 0
                    });
                    await _context.SaveChangesAsync();
                }
                
                response.Data = _mapper.Map<PlayerVariableDTO>(query);
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
        
        public async Task<TDResponse<List<PlayerChestDTO>>> SetPlayerChests(BaseRequest<List<PlayerChestDTO>> req, UserDto user)
        {
            TDResponse<List<PlayerChestDTO>> response = new TDResponse<List<PlayerChestDTO>>();
            var info = InfoDetail.CreateInfo(req, "SetPlayerChests");
            try
            {
                if (req.Data==null)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                foreach (var ld in req.Data)
                {
                    if (ld.Id<0)
                    {
                        await _context.AddAsync(new PlayerChest()
                        {
                            UserId = user.Id,
                            SlotPlace = ld.SlotPlace,
                            OpenStartDate = ld.OpenStartDate?.ToDateTimeOffsetUtc(),
                            OpenFinishDate = ld.OpenFinishDate?.ToDateTimeOffsetUtc(),
                            ChestId = ld.ChestId,
                            GainedItems = ld.GainedItems,
                            UsedGem = ld.UsedGem
                        });
                    }
                    else
                    {
                        var ent = await _context.PlayerChest.Where(l => l.UserId == user.Id && l.Id == ld.Id)
                            .FirstOrDefaultAsync();
                        if (ent != null)
                        {
                            ent.SlotPlace = ld.SlotPlace;
                            ent.UsedGem = ld.UsedGem;
                            ent.OpenStartDate = ld.OpenStartDate?.ToDateTimeOffsetUtc();
                            ent.OpenFinishDate = ld.OpenFinishDate?.ToDateTimeOffsetUtc();
                        }

                    }
                    
                    await _context.SaveChangesAsync();

                }
                
                var query = _context.PlayerChest
                    .Where(l=> l.Chest.IsActive && l.UserId == user.Id && l.SlotPlace > 0);
                var playerChestTypeDtos = await _mapper.ProjectTo<PlayerChestDTO>(query).ToListAsync();
                
                response.Data = playerChestTypeDtos;
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
        
        public async Task<TDResponse<List<TableChangesDTO>>> GetPlayerSyncStatus(BaseRequest req, UserDto user)
        {
            TDResponse<List<TableChangesDTO>> response = new TDResponse<List<TableChangesDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetSyncStatus");

            try
            {
                var playerSync = await _context.PlayerTableSync.Where(l => l.UserId == user.Id).ToListAsync();
                var query = _context.TableChanges;
                var tableChangesDtos = await _mapper.ProjectTo<TableChangesDTO>(query).ToListAsync();
                response.Data = tableChangesDtos.Where(k=>
                    playerSync.Any(l=>l.TableChangesId == k.Id && l.LastSyncDate < k.LastChangeDate.ToDateTimeOffsetUtc()  ) || 
                    !playerSync.Any(l=>l.TableChangesId == k.Id)).ToList();
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

        public async Task<TDResponse<List<ResearchNodeDTO>>> GetResearchNodes(BaseRequest req, UserDto user)
        {
            TDResponse<List<ResearchNodeDTO>> response = new TDResponse<List<ResearchNodeDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetResearchNodes");
            try
            {
                var query = _context.ResearchNode
                    .Include(l=>l.ResearchNodeLevels)
                    .ThenInclude(l=>l.Conditions);
                var researchNodeDtos = await _mapper.ProjectTo<ResearchNodeDTO>(query).ToListAsync();
                
                response.Data = researchNodeDtos;
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
                await SyncPlayerTable(new []
                {
                    TableEnum.ResearchNode,
                    TableEnum.ResearchNodeLevel,
                    TableEnum.ResearchNodeLevelCondition
                    
                }, user);

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }
        
        public async Task<TDResponse<List<PlayerResearchNodeLevelDTO>>> GetPlayerResearchNodeLevels(BaseRequest req, UserDto user)
        {
            TDResponse<List<PlayerResearchNodeLevelDTO>> response = new TDResponse<List<PlayerResearchNodeLevelDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetPlayerResearchNodeLevels");
            try
            {
                var query = _context.PlayerResearchNodeLevel;
                var playerResearchNodeDtos = await _mapper.ProjectTo<PlayerResearchNodeLevelDTO>(query).ToListAsync();
                
                response.Data = playerResearchNodeDtos;
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
        
        public async Task<TDResponse<List<PlayerResearchNodeLevelDTO>>> SetPlayerResearchNodeLevels(BaseRequest<List<PlayerResearchNodeLevelDTO>> req, UserDto user)
        {
            TDResponse<List<PlayerResearchNodeLevelDTO>> response = new TDResponse<List<PlayerResearchNodeLevelDTO>>();
            var info = InfoDetail.CreateInfo(req, "SetPlayerResearchNodeLevels");
            try
            {
                if (req.Data==null)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                foreach (var ld in req.Data)
                {
                    if (ld.Id==0)
                    {
                        await _context.AddAsync(new PlayerResearchNodeLevel()
                        {
                            UserId = user.Id,
                            ResearchNodeLevelId = ld.ResearchNodeLevelId
                        });
                    }
                    else
                    {
                        var ent = await _context.PlayerResearchNodeLevel.Where(l => l.UserId == user.Id && l.Id == ld.Id)
                            .FirstOrDefaultAsync();
                        if (ent != null)
                        {
                            ent.ResearchNodeLevelId = ld.ResearchNodeLevelId;
                        }

                    }
                    
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
        
        
        public async Task<TDResponse> AddWavePart(AddWavePartRequest req)
        {
            TDResponse response = new TDResponse();
            try
            {
                if (req.P!="s3ms1p4s4p4s4j1nd4s3si3uzus3s1c3l3r")
                {
                    response.SetError("derleeeer");
                    return response;
                }

                var chapters = await _context.Chapter.Where(l => l.OrderId == req.ChapterOrder).ToListAsync();
                if (chapters.Count>1)
                {
                    response.SetError("chapter order idleri aynı olan chapterlar var birininkini ya sil ya da degistir kirvem");
                    return response;
                }
                if (chapters.Count==0)
                {
                    response.SetError("chapter order idsi "+ req.ChapterOrder +"  olan chapter yok dayicim");
                    return response;
                }

                var levels = await _context.Level.Where(l => l.OrderId == req.LevelOrder && l.ChapterId == chapters[0].Id).ToListAsync();
                
                if (levels.Count>1)
                {
                    response.SetError("level order idleri aynı olan leveller var birininkini ya sil ya da degistir kirvem");
                    return response;
                }
                if (levels.Count==0)
                {
                    response.SetError("level order idsi "+ req.LevelOrder +"  olan level yok dayicim");
                    return response;
                }
                
                
                var waves = await _context.Wave.Where(l => l.OrderId == req.WaveOrder && l.LevelId == levels[0].Id).ToListAsync();
                
                if (waves.Count>1)
                {
                    response.SetError("wave order idleri aynı olan waveler var birininkini ya sil ya da degistir kirvem");
                    return response;
                }
                if (waves.Count==0)
                {
                    response.SetError("wave order idsi "+ req.WaveOrder +"  olan wave yok dayicim");
                    return response;
                }

                var enemy = await _context.Enemy.Where(l => l.Id == req.EnemyId).FirstOrDefaultAsync();

                if (enemy==null)
                {
                    response.SetError("üstad bu enemy idde bi yanlislik var haberin olsun");
                    return response;
                }

                if (!enemy.IsActive)
                {
                    response.SetError("kuzen bu enemy aktif degil git bunu bi aktiflestir önce");
                    return response;
                }
                
                var enemyLevel = await _context.EnemyLevel.Where(l => l.EnemyId == req.EnemyId && l.Level== req.EnemyLevel).FirstOrDefaultAsync();
                
                if (enemyLevel==null)
                {
                    response.SetError("moruk bu enemynin "+ req.EnemyLevel +" leveli yok buna bi bak");
                    return response;
                }

                var ent = new WavePart()
                {
                    WaveId = waves[0].Id,
                    EnemyLevelId = enemyLevel.Id,
                    Count = req.Count
                };

                await _context.AddAsync(ent);
                await _context.SaveChangesAsync();
                
                response.SetSuccess("ADAMSIN");
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
            }

            return response;
        }    


        private async Task SyncPlayerTable(TableEnum[] tableEnum,UserDto user)
        {
            try
            {
                var tableEnumAr = tableEnum.Cast<int>().ToArray();
                var playerTableSync = await _context.PlayerTableSync
                    .Include(l=>l.TableChanges)
                    .Where(l => l.UserId == user.Id && tableEnumAr.Contains(l.TableChanges.TableEnum))
                    .ToListAsync();

                var now = DateTimeOffset.UtcNow;

                for (int i = 0; i < tableEnumAr.Length; i++)
                {
                    if (playerTableSync.FirstOrDefault(l => l.TableChanges.TableEnum == tableEnumAr[i]) == null)
                    {
                        var ent = new PlayerTableSync()
                        {
                            TableChangesId = await _context.TableChanges
                                .Where(l => l.TableEnum == tableEnumAr[i])
                                .Select(l => l.Id)
                                .FirstOrDefaultAsync(),
                            UserId = user.Id,
                            LastSyncDate = now
                        };
                        await _context.AddAsync(ent);
                        await _context.SaveChangesAsync();
                        continue;
                    }
                    
                    playerTableSync.FirstOrDefault(l => l.TableChanges.TableEnum == tableEnumAr[i])!.LastSyncDate =
                        now;
                    await _context.SaveChangesAsync();
                }
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}