using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PlayerBaseApi.Entities;
using PlayerBaseApi.Enums;
using PlayerBaseApi.Helpers;
using PlayerBaseApi.Interfaces;
using PlayerBaseApi.Models;
using SharedLibrary.Enums;
using SharedLibrary.Helpers;
using SharedLibrary.Models;
using SharedLibrary.Models.Loot;
#pragma warning disable CS1591

namespace PlayerBaseApi.Services
{
    public class PlayerBaseService : IPlayerBaseService
    {
        private readonly ILogger<PlayerBaseService> _logger;
        private readonly IMapper _mapper;
        private readonly PlayerBaseContext _context;
        private readonly IConfiguration _configuration;

        public PlayerBaseService(ILogger<PlayerBaseService> logger, PlayerBaseContext context, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<TDResponse<List<PlayerBasePlacementDTO>>> GetBuildings(BaseRequest req, UserDto user)
        {
            TDResponse<List<PlayerBasePlacementDTO>> response = new TDResponse<List<PlayerBasePlacementDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetBuildings");
            try
            {
                if (!(await _context.PlayerBasePlacement.Where(l => l.UserId == user.Id && l.BuildingTypeId == 1 && l.BuildingType.IsActive).AnyAsync()))//base var mı?
                {
                    await _context.AddAsync(new PlayerBasePlacement()
                    {
                        BuildingTypeId = 1,
                        BuildingLevel = 1,
                        CoordX = 0,
                        CoordY = 0,
                        UpdateEndDate = null,
                        UserId = user.Id
                    });
                    await _context.AddAsync(new PlayerBasePlacement()
                    {
                        BuildingTypeId = 10,
                        BuildingLevel = 1,
                        CoordX = -2.021312952041626,
                        CoordY = 5.305946350097656,
                        UpdateEndDate = null,
                        UserId = user.Id
                    });
                    await _context.AddAsync(new PlayerBasePlacement()
                    {
                        BuildingTypeId = 7,
                        BuildingLevel = 1,
                        CoordX = 2.5266411304473877,
                        CoordY = 6.063939094543457,
                        UpdateEndDate = null,
                        UserId = user.Id
                    });
                    
                    var pTroop = new PlayerTroop()
                    {
                        TroopCount = 0,
                        UserId = user.Id,
                        LastTroopCollect = DateTimeOffset.Now,
                        MaxDuration = TimeSpan.FromHours(12),
                        TrainingPerHour = 100
                    };
                    await _context.AddAsync(pTroop);
                    if (!user.IsApe)
                    {
                        await _context.AddAsync(new PlayerHero()
                        {
                            SkillPoint = 0,
                            CurrentLevel = 1,
                            Exp = 0,
                            HeroId = 1,//roger
                            TalentPoint = 1,
                            UserId = user.Id,
                            EndDate = null
                        });
                    }
                    else
                    {
                        await _context.AddAsync(new PlayerHero()
                        {
                            SkillPoint = 0,
                            CurrentLevel = 1,
                            Exp = 0,
                            HeroId = 6,//hell night
                            TalentPoint = 1,
                            UserId = user.Id,
                            EndDate = null
                        });
                    }
                    await _context.SaveChangesAsync();
                }

                var query = _context.PlayerBasePlacement.Include(l => l.BuildingType).Where(l => l.UserId == user.Id && l.BuildingType.IsActive);

                var qlist = await _mapper.ProjectTo<PlayerBasePlacementDTO>(query).ToListAsync();
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

        public async Task<TDResponse<List<BuildingTypeDTO>>> GetBuildingTypes(BaseRequest req, UserDto user)
        {
            TDResponse<List<BuildingTypeDTO>> response = new TDResponse<List<BuildingTypeDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetBuildingTypes");
            try
            {
                var query = _context.BuildingType.Where(l => l.IsActive);
                var qlist = await _mapper.ProjectTo<BuildingTypeDTO>(query).ToListAsync();
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

        public async Task<TDResponse> AddPlayerBaseBuilding(BaseRequest<PlayerBaseBuildingRequest> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "AddPlayerBaseBuilding");
            try
            {
                var duplicateQuery = await _context.PlayerBasePlacement.AnyAsync(l => l.UserId == user.Id && l.BuildingTypeId == req.Data!.BuildingTypeId);
                if (duplicateQuery)
                {
                    info.AddInfo(OperationMessages.DuplicateRecord);
                    response.SetError(OperationMessages.DuplicateRecord);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var typeIsActive = await _context.BuildingType.AnyAsync(l => l.IsActive && l.Id == req.Data!.BuildingTypeId);
                if (!typeIsActive)
                {
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    response.SetError(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                #region Old_creator

                // switch (req.Data!.BuildingTypeId)
                // {
                //     case 4://Hospital
                //         var phospital = new PlayerHospital()
                //         {
                //             HospitalLevelId = 1,
                //             InjuredCount = 0,
                //             InHealingCount = 0,
                //             HealingDoneDate = null,
                //             UserId = user.Id
                //         };
                //         await _context.AddAsync(phospital);
                //         break;
                //     case 5://prison
                //         var pprison = new PlayerPrison()
                //         {
                //             PrisonLevelId = 1,
                //             PrisonerCount = 0,
                //             InTrainingPrisonerCount = 0,
                //             TrainingDoneDate = null,
                //             UserId = user.Id
                //         };
                //         await _context.AddAsync(pprison);
                //         break;
                //     case 10://military base
                //         var pTroop = new PlayerTroop()
                //         {
                //             TroopCount = 0,
                //             UserId = user.Id,
                //             LastTroopCollect = DateTimeOffset.Now,
                //             MaxDuration = TimeSpan.FromHours(12),
                //             TrainingPerHour = 100
                //         };
                //         await _context.AddAsync(pTroop);
                //         break;
                //
                //     default:
                //         break;
                // }

                #endregion
                
                var ent = new PlayerBasePlacement();
                ent.BuildingLevel = 1;
                ent.BuildingTypeId = req.Data!.BuildingTypeId;
                ent.CoordX = req.Data!.CoordX;
                ent.CoordY = req.Data!.CoordY;
                ent.UserId = user.Id;
                await _context.AddAsync(ent);
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

        public async Task<TDResponse> MovePlayerBuilding(BaseRequest<PlayerBaseBuildingRequest> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "MovePlayerBuilding");
            try
            {
                var query = await _context.PlayerBasePlacement.Where(l => l.UserId == user.Id && l.BuildingTypeId == req.Data!.BuildingTypeId).FirstOrDefaultAsync();
                if (query == null)
                {
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    response.SetError(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var typeIsActive = await _context.BuildingType.AnyAsync(l => l.IsActive && l.Id == req.Data!.BuildingTypeId);
                if (!typeIsActive)
                {
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    response.SetError(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                query.CoordX = req.Data!.CoordX;
                query.CoordY = req.Data!.CoordY;
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

        public async Task<TDResponse<PlayerBaseInfoDTO>> GetPlayerBaseInfo(BaseRequest req, UserDto user)
        {
            TDResponse<PlayerBaseInfoDTO> response = new TDResponse<PlayerBaseInfoDTO>();
            var info = InfoDetail.CreateInfo(req, "GetPlayerBaseInfo");
            try
            {
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                if (playerBaseInfo == null)
                {
                    playerBaseInfo = new PlayerBaseInfo()
                    {
                        BaseLevel = 1,
                        BluePrints = 1,
                        Gems = 5000,
                        BaseFullDuration = new TimeSpan(10, 0, 0),//TODO: Confige alınacak
                        Fuel = 100,
                        ResourceProductionPerHour = 1000,//TODO: SONRADAN Değiştirilebilecek
                        RareHeroCards = 0,
                        EpicHeroCards = 0,
                        LegendaryHeroCards = 0,
                        LastBaseCollect = DateTimeOffset.Now,
                        Scraps = 10000,
                        UserId = user.Id,
                        Username = user.Username,
                        IsApe = false
                    };
                    await _context.AddAsync(playerBaseInfo);
                    await _context.SaveChangesAsync();
                }

                #region Resource Addition

                if ((DateTimeOffset.Now - playerBaseInfo.LastBaseCollect).TotalMilliseconds >= (new TimeSpan(0, 1, 0)).TotalMilliseconds)
                {
                    var duration = DateTimeOffset.Now - playerBaseInfo.LastBaseCollect;
                    duration = playerBaseInfo.BaseFullDuration < duration ? playerBaseInfo.BaseFullDuration : duration;

                    playerBaseInfo.Fuel += (int)(duration.TotalHours * playerBaseInfo.ResourceProductionPerHour);
                    playerBaseInfo.Scraps += (int)(duration.TotalHours * playerBaseInfo.ResourceProductionPerHour);
                    playerBaseInfo.LastBaseCollect = DateTimeOffset.Now;
                    _context.Update(playerBaseInfo);
                    await _context.SaveChangesAsync();
                }

                #endregion

                response.Data = _mapper.Map<PlayerBaseInfoDTO>(playerBaseInfo);
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
        
        public async Task<TDResponse<PlayerBaseInfoDTO>> GetOtherPlayersBaseInfo(BaseRequest<long> req)
        {
            TDResponse<PlayerBaseInfoDTO> response = new TDResponse<PlayerBaseInfoDTO>();
            var info = InfoDetail.CreateInfo(req, "GetOtherPlayersBaseInfo");
            try
            {
                if (req.Data == (long)FakeId.TutorialEnemy)
                {
                    response.Data = new PlayerBaseInfoDTO()
                    {
                        Fuel = 0,
                        UserId = (long)FakeId.TutorialEnemy,
                        Gems = 0,
                        Scraps = 10000,
                        BluePrints = 0,
                        EpicHeroCards = 0,
                        LastBaseCollect = DateTimeOffset.UtcNow.ToString(),
                        Username = "Emanuel",
                        RareHeroCards = 0,
                        LegendaryHeroCards = 0,
                        Bio = "Regular guy",
                        BaseLevel = 1,
                        IsApe = false,
                        AvatarId = 3
                        
                    };
                    return response;
                }
                if (req?.Data == null)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUserId(req.Data);
                if (playerBaseInfo == null)
                {
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    response.SetError(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }


                response.Data = _mapper.Map<PlayerBaseInfoDTO>(playerBaseInfo);
                response.Data.Fuel = 0;
                response.Data.Gems = 0;
                response.Data.Scraps = 0;
                response.Data.BluePrints = 0;
                response.Data.EpicHeroCards = 0;
                response.Data.LegendaryHeroCards = 0;
                response.Data.RareHeroCards = 0;
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

        public async Task<TDResponse<PlayerBaseInfoDTO>> UpdateOrCreatePlayerBaseInfo(BaseRequest<PlayerBaseInfoDTO> req)
        {
            TDResponse<PlayerBaseInfoDTO> response = new TDResponse<PlayerBaseInfoDTO>();
            var info = InfoDetail.CreateInfo(req, "UpdateOrCreatePlayerBaseInfo");
            try
            {
                var query = await _context.GetPlayerBaseInfoByUserId(req.Data.UserId);
                if (query != null)
                {
                    query.Scraps += req.Data.Scraps;
                    query.BluePrints += req.Data.BluePrints;
                    query.Gems += req.Data.Gems;
                    query.Fuel += req.Data.Fuel;
                    query.EpicHeroCards += req.Data.EpicHeroCards;
                    query.RareHeroCards += req.Data.RareHeroCards;
                    query.LegendaryHeroCards += req.Data.LegendaryHeroCards;
                    response.Data = _mapper.Map<PlayerBaseInfoDTO>(query);
                    _context.Update(query);
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

        public async Task<TDResponse<BuildingUpgradeTimeDTO>> UpgradeBuildingInfo(BaseRequest<int> req, UserDto user)
        {
            TDResponse<BuildingUpgradeTimeDTO> response = new TDResponse<BuildingUpgradeTimeDTO>();
            var info = InfoDetail.CreateInfo(req, "UpgradeBuildingInfo");
            try
            {

                var query = await _context.PlayerBasePlacement.Where(l => l.UserId == user.Id && l.BuildingTypeId == req.Data).FirstOrDefaultAsync();
                if (query == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (query.UpdateEndDate != null)
                {
                    response.SetError(OperationMessages.ProcessAllreadyExist);
                    info.AddInfo(OperationMessages.ProcessAllreadyExist);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                switch (req.Data)
                {
                    case 5://prison
                        if (await _context.PlayerPrison.Where(l => l.InTrainingPrisonerCount != 0 && l.UserId == user.Id).AnyAsync())//eğitimde esir var mı kontrol ediliyor.
                        {
                            response.SetError(OperationMessages.TrainingMustBeDone);
                            info.AddInfo(OperationMessages.TrainingMustBeDone);
                            _logger.LogInformation(info.ToString());
                            return response;
                        }
                        break;
                    case 4://hospital
                        if (await _context.PlayerHospital.Where(l => l.InHealingCount != 0 && l.UserId == user.Id).AnyAsync())//iyileştirilen asker var mı kontrol ediliyor.
                        {
                            response.SetError(OperationMessages.HealingMustBeDone);
                            info.AddInfo(OperationMessages.HealingMustBeDone);
                            _logger.LogInformation(info.ToString());
                            return response;
                        }
                        break;
                    default:
                        break;
                }

                var buildingUpgradeTimeQuery = _context.BuildingUpgradeTime.Where(l => l.BuildingTypeId == req.Data && l.Level == query.BuildingLevel + 1);

                var buildingUpgradeTime = await _mapper.ProjectTo<BuildingUpgradeTimeDTO>(buildingUpgradeTimeQuery).FirstOrDefaultAsync();


                var duration = buildingUpgradeTime?.UpgradeDuration ?? new TimeSpan(2, 0, 0);
                var cost = buildingUpgradeTime?.ScrapCount ?? 99999999;
                var buff = await BuffHelper.GetPlayersTotalBuff(user.Id);
                duration += duration * buff.BuildingUpgradeDurationMultiplier;
                cost += (int)(cost * buff.BuildingUpgradeCostMultiplier);
                buildingUpgradeTime!.UpgradeDuration = duration;
                buildingUpgradeTime!.ScrapCount = cost;
                var conditions = await _mapper.ProjectTo<BuildingUpgradeConditionDTO>(
                    _context.BuildingUpgradeCondition
                        .Include(l => l.PrereqBuildingType)
                        .Where(l => l.BuildingId == req.Data && l.BuildingLevel == query.BuildingLevel + 1)
                    ).ToListAsync();
                buildingUpgradeTime.Conditions = new List<BuildingUpgradeConditionDTO>();
                foreach (var cond in conditions)
                {
                    bool canUpgrade = await _context.PlayerBasePlacement.Where(l => l.UserId == user.Id && l.BuildingTypeId == cond.PrereqBuildingTypeId && l.BuildingLevel >= cond.PrereqLevel).AnyAsync();
                    if (!canUpgrade)
                    {
                        buildingUpgradeTime.Conditions.Add(cond);
                    }
                }
                response.Data = buildingUpgradeTime;
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

        public async Task<TDResponse<PlayerBasePlacementDTO>> UpgradeBuildingRequest(BaseRequest<int> req, UserDto user)
        {
            TDResponse<PlayerBasePlacementDTO> response = new TDResponse<PlayerBasePlacementDTO>();
            var info = InfoDetail.CreateInfo(req, "UpgradeBuildingRequest");
            try
            {

                var query = await _context.PlayerBasePlacement.Where(l => l.UserId == user.Id && l.BuildingTypeId == req.Data).FirstOrDefaultAsync();
                if (query == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (query.UpdateEndDate != null)
                {
                    response.SetError(OperationMessages.ProcessAllreadyExist);
                    info.AddInfo(OperationMessages.ProcessAllreadyExist);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                switch (req.Data)
                {
                    case 5://prison
                        if (await _context.PlayerPrison.Where(l => l.InTrainingPrisonerCount != 0 && l.UserId == user.Id).AnyAsync())//eğitimde esir var mı kontrol ediliyor.
                        {
                            response.SetError(OperationMessages.TrainingMustBeDone);
                            info.AddInfo(OperationMessages.TrainingMustBeDone);
                            _logger.LogInformation(info.ToString());
                            return response;
                        }
                        break;
                    case 4://hospital
                        if (await _context.PlayerHospital.Where(l => l.InHealingCount != 0 && l.UserId == user.Id).AnyAsync())//iyileştirilen asker var mı kontrol ediliyor.
                        {
                            response.SetError(OperationMessages.HealingMustBeDone);
                            info.AddInfo(OperationMessages.HealingMustBeDone);
                            _logger.LogInformation(info.ToString());
                            return response;
                        }
                        break;
                    default:
                        break;
                }

                var buildingUpdateTime = await _context.BuildingUpgradeTime.Where(l => l.BuildingTypeId == req.Data && l.Level == query.BuildingLevel + 1).FirstOrDefaultAsync();
                var duration = buildingUpdateTime?.UpgradeDuration ?? new TimeSpan(2, 0, 0);
                var cost = buildingUpdateTime?.ScrapCount ?? 99999999;
                var buff = await BuffHelper.GetPlayersTotalBuff(user.Id);
                duration += duration * buff.BuildingUpgradeDurationMultiplier;
                cost += (int)(cost * buff.BuildingUpgradeCostMultiplier);
                var conditions = await _mapper.ProjectTo<BuildingUpgradeConditionDTO>(
                        _context.BuildingUpgradeCondition
                            .Include(l => l.PrereqBuildingType)
                            .Where(l => l.BuildingId == req.Data && l.BuildingLevel == query.BuildingLevel + 1)
                        ).ToListAsync();
                bool canUpgrade = true;
                foreach (var cond in conditions)
                {
                    canUpgrade = await _context.PlayerBasePlacement.Where(l => l.UserId == user.Id && l.BuildingTypeId == cond.PrereqBuildingTypeId && l.BuildingLevel >= cond.PrereqLevel).AnyAsync();
                    if (!canUpgrade)
                    {
                        response.SetError(OperationMessages.BeforeUpgradeThis + cond.PrereqBuildingTypeName + $"({cond.PrereqLevel})");
                        info.AddInfo(OperationMessages.BeforeUpgradeThis);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                }



                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                if (playerBaseInfo.Scraps < cost)
                {
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                playerBaseInfo.Scraps -= cost;
                _context.Update(playerBaseInfo);
                query.UpdateEndDate = DateTimeOffset.Now.Add(duration);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<PlayerBasePlacementDTO>(query);
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

        public async Task<TDResponse<string>> SpeedUpUpgradeBuilding(BaseRequest<SpeedUpRequest> req, UserDto user)
        {
            TDResponse<string> response = new TDResponse<string>();
            var info = InfoDetail.CreateInfo(req, "SpeedUpUpgradeBuilding");
            try
            {
                if (req.Data == null)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var playerBuilding = await _context.PlayerBasePlacement
                    .Where(l => l.UserId == user.Id && l.BuildingTypeId == req.Data.GenericId).FirstOrDefaultAsync();

                if (playerBuilding == null || playerBuilding.UpdateEndDate == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var playerItem = await _context.PlayerItem.Include(l => l.Item)
                    .Where(l => l.ItemId == req.Data.ItemId && l.UserId == user.Id && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp).FirstOrDefaultAsync();

                if ((playerItem == null || playerItem.Count < req.Data.Count) && !req.Data.Buy)
                {
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (req.Data.Buy && (playerItem == null || playerItem.Count < req.Data.Count))
                {
                    var marketItemId = await _context.MarketItem
                        .Where(l => l.ItemId == req.Data.ItemId && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp && l.IsActive)
                        .Select(l => l.Id).FirstOrDefaultAsync();
                    var marketReq = new BaseRequest<BuyMarketItemRequest>()
                    {
                        Info = req.Info,
                        Data = new BuyMarketItemRequest()
                        {
                            Count = req.Data.Count,
                            MarketItemId = marketItemId,
                        }
                    };
                    var buyResponse = await BuyMarketItem(marketReq, user);
                    if (buyResponse.HasError)
                    {
                        response.SetError(buyResponse.Message);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                    else
                    {
                        playerItem = await _context.PlayerItem.Include(l => l.Item)
                            .Where(l => l.ItemId == req.Data.ItemId && l.UserId == user.Id && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp).FirstOrDefaultAsync();
                    }
                }

                playerBuilding.UpdateEndDate -= new TimeSpan(0, req.Data.Count * playerItem.Item.Value1 ?? 0, 0);
                playerItem.Count -= req.Data.Count;
                await _context.SaveChangesAsync();

                response.Data = playerBuilding.UpdateEndDate.ToString();
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

        public async Task<TDResponse<PlayerBasePlacementDTO>> UpgradeBuildingDoneRequest(BaseRequest<int> req, UserDto user)
        {
            TDResponse<PlayerBasePlacementDTO> response = new TDResponse<PlayerBasePlacementDTO>();
            var info = InfoDetail.CreateInfo(req, "UpgradeBuildingDoneRequest");
            try
            {

                var query = await _context.PlayerBasePlacement.Where(l => l.UserId == user.Id && l.BuildingTypeId == req.Data).FirstOrDefaultAsync();
                if (query == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (query.UpdateEndDate == null || (query.UpdateEndDate - DateTimeOffset.Now > TimeSpan.Zero))
                {
                    response.SetError(OperationMessages.NoChanges);
                    info.AddInfo(OperationMessages.NoChanges);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                query.UpdateEndDate = null;
                query.BuildingLevel = query.BuildingLevel + 1;
                switch (req.Data)
                {
                    case 5://prison
                        var pprison = await _context.PlayerPrison.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                        pprison.PrisonLevelId++;
                        await _context.SaveChangesAsync();
                        break;
                    case 4://hospital
                        var phospital = await _context.PlayerHospital.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                        phospital.HospitalLevelId++;
                        await _context.SaveChangesAsync();
                        break;                    
                    case 8://scout
                        var pscout = await _context.PlayerScout.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                        pscout.ScoutLevelId++;
                        await _context.SaveChangesAsync();
                        break;
                    case 1://base
                        var playerbaseInfo = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                        playerbaseInfo.BaseLevel = query.BuildingLevel;
                        await _context.SaveChangesAsync();
                        break;

                    default:
                        await _context.SaveChangesAsync();
                        break;
                }

                response.Data = _mapper.Map<PlayerBasePlacementDTO>(query);
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

        [Obsolete("deprecated", true)]
        public async Task<TDResponse<CollectBaseResponse>> CollectBaseResources(BaseRequest req, UserDto user)
        {
            TDResponse<CollectBaseResponse> response = new TDResponse<CollectBaseResponse>();
            var info = InfoDetail.CreateInfo(req, "CollectBaseResources");
            //try
            //{
            //    var playerBaseInfo = await _context.GetPlayerBaseInfoByUserId(user);
            //    if ((DateTimeOffset.Now - playerBaseInfo.LastBaseCollect).TotalMilliseconds < (new TimeSpan(0, 1, 0)).TotalMilliseconds)
            //    {
            //        response.SetError(OperationMessages.NoChanges);
            //        info.AddInfo(OperationMessages.NoChanges);
            //        _logger.LogInformation(info.ToString());
            //        return response;
            //    }
            //    var duration = DateTimeOffset.Now - playerBaseInfo.LastBaseCollect;
            //    duration = playerBaseInfo.BaseFullDuration < duration ? playerBaseInfo.BaseFullDuration : duration;


            //    response.Data = new CollectBaseResponse()
            //    {
            //        CollectDuration = duration,
            //        CollectedResource = (int)(duration.TotalHours * playerBaseInfo.ResourceProductionPerHour),
            //        ResourceProductionPerHour = playerBaseInfo.ResourceProductionPerHour,
            //        BaseFullDuration = playerBaseInfo.BaseFullDuration
            //    };
            //    response.Data.CollectedResource += (int)(response.Data.CollectedResource * (await GetPlayersTotalBuff(user.Id)).BaseResourceMultiplier);
            //    playerBaseInfo.Fuel += response.Data.CollectedResource;
            //    playerBaseInfo.Scraps += response.Data.CollectedResource;
            //    playerBaseInfo.LastBaseCollect = DateTimeOffset.Now;

            //    await _context.SaveChangesAsync();
            //    response.SetSuccess();
            //    info.AddInfo(OperationMessages.Success);
            //    _logger.LogInformation(info.ToString());
            //}
            //catch (Exception e)
            //{
            //    response.SetError(OperationMessages.DbError);
            //    info.SetException(e);
            //    _logger.LogError(info.ToString());
            //}
            return response;

        }


        #region RESEARCH UTILS

        public async Task<TDResponse<List<int>>> GetReadyResearchNodes(BaseRequest req, UserDto user)
        {
            TDResponse<List<int>> response = new TDResponse<List<int>>();
            var info = InfoDetail.CreateInfo(req, "GetReadyResearchNodes");
            try
            {
                var now = DateTimeOffset.Now;
                var playerResearchNodes = await _context.PlayerResearchNode.Where(l => l.UpdateEndDate < now && l.UserId == user.Id).Select(l => l.ResearchNodeId).ToListAsync();
                response.Data = playerResearchNodes;
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

        public async Task<TDResponse<List<ResearchTableDTO>>> GetResearchTable(BaseRequest req, UserDto user)
        {
            TDResponse<List<ResearchTableDTO>> response = new TDResponse<List<ResearchTableDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetResearchTable");
            try
            {
                var talentTrees = _context.ResearchTable;
                var qlist = await _mapper.ProjectTo<ResearchTableDTO>(talentTrees).ToListAsync();
                for (int i = 0; i < qlist.Count; i++)
                {
                    var qq = _context.ResearchNode.Include(l => l.Buff).Where(l => l.IsActive && l.ResearchTableId == qlist[i].Id).OrderBy(l => l.PlaceId);
                    var playerResearchNodes = await _context.PlayerResearchNode.Where(l => l.ResearchNode.ResearchTableId == qlist[i].Id && l.UserId == user.Id).ToListAsync();
                    qlist[i].Nodes = await _mapper.ProjectTo<ResearchNodeDTO>(qq).ToListAsync();
                    qlist[i].Nodes.ForEach(l =>
                    {
                        l.CurrentLevel = playerResearchNodes.Where(k => k.ResearchNodeId == l.Id).Select(o => o.CurrentLevel).FirstOrDefault();
                        l.UpdateEndDate = playerResearchNodes.Where(k => k.ResearchNodeId == l.Id).Select(o => o.UpdateEndDate.ToString()).FirstOrDefault();
                    });
                }
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

        public async Task<TDResponse<ResearchNodeUpgradeNecessariesDTO>> GetResearchNodeUpgradeNecessariesByNodeId(BaseRequest<int> req, UserDto user)
        {
            TDResponse<ResearchNodeUpgradeNecessariesDTO> response = new TDResponse<ResearchNodeUpgradeNecessariesDTO>();
            var info = InfoDetail.CreateInfo(req, "GetResearchNodeUpgradeNecessariesByNodeId");
            try
            {
                var currentNode = await _context.PlayerResearchNode.Include(l => l.ResearchNode).Where(l => l.UserId == user.Id && l.ResearchNodeId == req.Data).FirstOrDefaultAsync();
                if (currentNode != null && currentNode.UpdateEndDate != null)
                {
                    response.SetError(OperationMessages.ProcessAllreadyExist);
                    info.AddInfo(OperationMessages.ProcessAllreadyExist);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (currentNode != null && currentNode.CurrentLevel == currentNode.ResearchNode.Capacity)
                {
                    response.SetError(OperationMessages.HeroAllreadyMaxLevel);
                    info.AddInfo(OperationMessages.HeroAllreadyMaxLevel);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var nextLevel = 1;
                if (currentNode != null)
                {
                    nextLevel = currentNode.CurrentLevel + 1;
                }
                var rq = _context.ResearchNodeUpgradeNecessaries.Where(l => l.UpgradeLevel == nextLevel && l.ResearchNodeId == req.Data);
                response.Data = await _mapper.ProjectTo<ResearchNodeUpgradeNecessariesDTO>(rq).FirstOrDefaultAsync();
                var conditions = await _context.ResearchNodeUpgradeCondition
                    .Include(l => l.BuildingType)
                    .Include(l => l.ResearchNode)
                    .Include(l => l.ResearchNodeUpgradeNecessaries)
                    .ThenInclude(l => l.ResearchNode)
                    .Where(l => l.ResearchNodeUpgradeNecessaries.UpgradeLevel == nextLevel && l.ResearchNodeUpgradeNecessaries.ResearchNodeId == req.Data)
                    .OrderBy(l => l.BuildingTypeId)
                    .ToListAsync();

                response.Data.ResearchNodeUpgradeConditionList = new List<ResearchNodeUpgradeConditionDTO>();
                foreach (var item in conditions)
                {
                    if (item.BuildingTypeId != null)
                    {
                        var cond = await _context.PlayerBasePlacement
                            .Where(l => l.UserId == user.Id && l.BuildingTypeId == item.BuildingTypeId && l.BuildingLevel >= item.PrereqLevel)
                            .AnyAsync();
                        if (!cond)
                        {
                            response.Data.ResearchNodeUpgradeConditionList.Add(_mapper.Map<ResearchNodeUpgradeConditionDTO>(item));
                        }
                        continue;
                    }

                    if (item.ResearchNodeId != null)
                    {
                        var cond = await _context.PlayerResearchNode
                            .Where(l => l.UserId == user.Id && l.ResearchNodeId == item.ResearchNodeId && l.CurrentLevel >= item.PrereqLevel)
                            .AnyAsync();
                        if (!cond)
                        {
                            response.Data.ResearchNodeUpgradeConditionList.Add(_mapper.Map<ResearchNodeUpgradeConditionDTO>(item));
                        }
                        continue;
                    }
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


        public async Task<TDResponse> UpgradeResearchNode(BaseRequest<int> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "UpgradeResearchNode");
            try
            {
                
                if (await _context.PlayerResearchNode.AnyAsync(l=>l.UserId==user.Id && l.UpdateEndDate !=null))
                {
                    response.SetError(OperationMessages.ProcessAllreadyExist);
                    info.AddInfo(OperationMessages.ProcessAllreadyExist);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                var currentNode = await _context.PlayerResearchNode.Include(l => l.ResearchNode).Where(l => l.UserId == user.Id && l.ResearchNodeId == req.Data).FirstOrDefaultAsync();
                if (currentNode != null && currentNode.UpdateEndDate != null)
                {
                    response.SetError(OperationMessages.ProcessAllreadyExist);
                    info.AddInfo(OperationMessages.ProcessAllreadyExist);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (currentNode != null && currentNode.CurrentLevel == currentNode.ResearchNode.Capacity)
                {
                    response.SetError(OperationMessages.HeroAllreadyMaxLevel);
                    info.AddInfo(OperationMessages.HeroAllreadyMaxLevel);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                //TODO:Condition kontrolleri yapılacak
                if (currentNode == null)
                {
                    currentNode = new PlayerResearchNode()
                    {
                        CurrentLevel = 0,
                        ResearchNodeId = req.Data,
                        UserId = user.Id,
                    };
                    await _context.AddAsync(currentNode);
                }
                var rq = _context.ResearchNodeUpgradeNecessaries.Where(l => l.UpgradeLevel == currentNode.CurrentLevel + 1 && l.ResearchNodeId == req.Data);
                var necessaries = await _mapper.ProjectTo<ResearchNodeUpgradeNecessariesDTO>(rq).FirstOrDefaultAsync();
                var playerResource = await _context.GetPlayerBaseInfoByUser(user);
                if (necessaries.ScrapCount <= playerResource.Scraps && necessaries.BluePrintCount <= playerResource.BluePrints)
                {
                    playerResource.Scraps -= necessaries.ScrapCount;
                    playerResource.BluePrints -= necessaries.BluePrintCount;
                    currentNode.UpdateEndDate = DateTimeOffset.Now + necessaries.Duration;
                    await _context.SaveChangesAsync();
                    response.SetSuccess();
                    info.AddInfo(OperationMessages.Success);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
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

        public async Task<TDResponse<string>> SpeedUpResearchNodeUpgrade(BaseRequest<SpeedUpRequest> req, UserDto user)
        {
            TDResponse<string> response = new TDResponse<string>();
            var info = InfoDetail.CreateInfo(req, "SpeedUpResearchNodeUpgrade");
            try
            {
                if (req.Data == null)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var currentNode = await _context.PlayerResearchNode.Include(l => l.ResearchNode)
                    .Where(l => l.UserId == user.Id && l.ResearchNodeId == req.Data.GenericId).FirstOrDefaultAsync();

                if (currentNode == null || currentNode.UpdateEndDate == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var playerItem = await _context.PlayerItem.Include(l => l.Item)
                    .Where(l => l.ItemId == req.Data.ItemId && l.UserId == user.Id && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp).FirstOrDefaultAsync();

                if ((playerItem == null || playerItem.Count < req.Data.Count) && !req.Data.Buy)
                {
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (req.Data.Buy && (playerItem == null || playerItem.Count < req.Data.Count))
                {
                    var marketItemId = await _context.MarketItem
                        .Where(l => l.ItemId == req.Data.ItemId && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp && l.IsActive)
                        .Select(l => l.Id).FirstOrDefaultAsync();
                    var marketReq = new BaseRequest<BuyMarketItemRequest>()
                    {
                        Info = req.Info,
                        Data = new BuyMarketItemRequest()
                        {
                            Count = req.Data.Count,
                            MarketItemId = marketItemId,
                        }
                    };
                    var buyResponse = await BuyMarketItem(marketReq, user);
                    if (buyResponse.HasError)
                    {
                        response.SetError(buyResponse.Message);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                    else
                    {
                        playerItem = await _context.PlayerItem.Include(l => l.Item)
                            .Where(l => l.ItemId == req.Data.ItemId && l.UserId == user.Id && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp).FirstOrDefaultAsync();
                    }
                }

                currentNode.UpdateEndDate -= new TimeSpan(0, req.Data.Count * playerItem.Item.Value1 ?? 0, 0);
                playerItem.Count -= req.Data.Count;
                await _context.SaveChangesAsync();

                response.Data = currentNode.UpdateEndDate.ToString();
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

        public async Task<TDResponse> UpgradeResearchNodeDone(BaseRequest<int> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "UpgradeResearchNodeDone");
            try
            {
                var currentNode = await _context.PlayerResearchNode.Include(l => l.ResearchNode).Where(l => l.UserId == user.Id && l.ResearchNodeId == req.Data).FirstOrDefaultAsync();
                if (currentNode != null && currentNode.UpdateEndDate == null)
                {
                    response.SetError(OperationMessages.ProcessAllreadyExist);
                    info.AddInfo(OperationMessages.ProcessAllreadyExist);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (currentNode != null && currentNode.CurrentLevel == currentNode.ResearchNode.Capacity)
                {
                    response.SetError(OperationMessages.HeroAllreadyMaxLevel);
                    info.AddInfo(OperationMessages.HeroAllreadyMaxLevel);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (currentNode != null && (currentNode.UpdateEndDate - DateTime.Now).Value.TotalMilliseconds > new TimeSpan(0, 0, 0).TotalMilliseconds)
                {
                    response.SetError(OperationMessages.ProcessAllreadyExist);
                    info.AddInfo(OperationMessages.ProcessAllreadyExist);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                currentNode.CurrentLevel++;
                currentNode.UpdateEndDate = null;
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
        #endregion


        #region PRISON UTILS

        public async Task<TDResponse<PlayerPrisonDTO>> GetPrisonInfo(BaseRequest req, UserDto user)
        {
            TDResponse<PlayerPrisonDTO> response = new TDResponse<PlayerPrisonDTO>();
            var info = InfoDetail.CreateInfo(req, "GetPrisonInfo");
            try
            {
                var query = _context.PlayerPrison.Include(l => l.PrisonLevel).Where(l => l.UserId == user.Id);
                var pprison = await _mapper.ProjectTo<PlayerPrisonDTO>(query).FirstOrDefaultAsync();
                if (pprison == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                response.Data = pprison;
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

        public async Task<TDResponse<int>> ExecutePrisoners(BaseRequest<int> req, UserDto user)
        {
            TDResponse<int> response = new TDResponse<int>();
            var info = InfoDetail.CreateInfo(req, "ExecutePrisoners");
            try
            {
                if (req.Data < 1)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var query = await _context.PlayerPrison.Include(l => l.PrisonLevel).Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                if (query.PrisonerCount < req.Data)
                {
                    req.Data = query.PrisonerCount;
                }
                if (query.InTrainingPrisonerCount != 0)
                {
                    response.SetError(OperationMessages.TrainingMustBeDone);
                    info.AddInfo(OperationMessages.TrainingMustBeDone);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                query.PrisonerCount -= req.Data;
                playerBaseInfo.Scraps += (int)(req.Data * query.PrisonLevel.ExecutionEarnPerUnit);
                response.Data = (int)(req.Data * query.PrisonLevel.ExecutionEarnPerUnit);
                _context.Update(playerBaseInfo);
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


        public async Task<TDResponse> PrisonerTrainingRequest(BaseRequest<int> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "PrisonerTrainingRequest");
            try
            {
                if (req.Data < 1)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (await _context.PlayerBasePlacement.Where(l => l.UserId == user.Id && l.BuildingTypeId == 5 && l.UpdateEndDate != null).AnyAsync())//prison
                {
                    response.SetError(OperationMessages.UpgradingMustBeDone);
                    info.AddInfo(OperationMessages.UpgradingMustBeDone);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var query = await _context.PlayerPrison.Include(l => l.PrisonLevel).Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                if (query.PrisonerCount < req.Data)
                {
                    req.Data = query.PrisonerCount;
                }

                if (query.PrisonerCount < req.Data)
                {
                    req.Data = query.PrisonerCount;
                }
                if (query.InTrainingPrisonerCount != 0)
                {
                    response.SetError(OperationMessages.TrainingMustBeDone);
                    info.AddInfo(OperationMessages.TrainingMustBeDone);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (playerBaseInfo.Scraps < (int)(req.Data * query.PrisonLevel.TrainingCostPerUnit))
                {
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                query.PrisonerCount -= req.Data;
                query.InTrainingPrisonerCount += req.Data;
                query.TrainingDoneDate = DateTimeOffset.Now + (query.PrisonLevel.TrainingDurationPerUnit * req.Data);
                playerBaseInfo.Scraps -= (int)(req.Data * query.PrisonLevel.TrainingCostPerUnit);
                _context.Update(playerBaseInfo);
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

        public async Task<TDResponse<string>> SpeedUpPrisonerTraining(BaseRequest<SpeedUpRequest> req, UserDto user)
        {
            TDResponse<string> response = new TDResponse<string>();
            var info = InfoDetail.CreateInfo(req, "SpeedUpPrisonerTraining");
            try
            {
                if (req.Data == null)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var playerPrison = await _context.PlayerPrison
                    .Where(l => l.UserId == user.Id).FirstOrDefaultAsync();

                if (playerPrison == null || playerPrison.TrainingDoneDate == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var playerItem = await _context.PlayerItem.Include(l => l.Item)
                    .Where(l => l.ItemId == req.Data.ItemId && l.UserId == user.Id && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp).FirstOrDefaultAsync();

                if ((playerItem == null || playerItem.Count < req.Data.Count) && !req.Data.Buy)
                {
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (req.Data.Buy && (playerItem == null || playerItem.Count < req.Data.Count))
                {
                    var marketItemId = await _context.MarketItem
                        .Where(l => l.ItemId == req.Data.ItemId && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp && l.IsActive)
                        .Select(l => l.Id).FirstOrDefaultAsync();
                    var marketReq = new BaseRequest<BuyMarketItemRequest>()
                    {
                        Info = req.Info,
                        Data = new BuyMarketItemRequest()
                        {
                            Count = req.Data.Count,
                            MarketItemId = marketItemId,
                        }
                    };
                    var buyResponse = await BuyMarketItem(marketReq, user);
                    if (buyResponse.HasError)
                    {
                        response.SetError(buyResponse.Message);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                    else
                    {
                        playerItem = await _context.PlayerItem.Include(l => l.Item)
                            .Where(l => l.ItemId == req.Data.ItemId && l.UserId == user.Id && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp).FirstOrDefaultAsync();
                    }
                }

                playerPrison.TrainingDoneDate -= new TimeSpan(0, req.Data.Count * playerItem.Item.Value1 ?? 0, 0);
                playerItem.Count -= req.Data.Count;
                await _context.SaveChangesAsync();

                response.Data = playerPrison.TrainingDoneDate.ToString();
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

        public async Task<TDResponse<int>> PrisonerTrainingDoneRequest(BaseRequest req, UserDto user)
        {
            TDResponse<int> response = new TDResponse<int>();
            var info = InfoDetail.CreateInfo(req, "PrisonerTrainingDoneRequest");
            try
            {
                var query = await _context.PlayerPrison.Include(l => l.PrisonLevel).Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                var playerTroop = await _context.PlayerTroop.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (query.InTrainingPrisonerCount == 0)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if ((query.TrainingDoneDate - DateTimeOffset.Now).Value.TotalMilliseconds > 0)
                {
                    response.SetError(OperationMessages.TrainingMustBeDone);
                    info.AddInfo(OperationMessages.TrainingMustBeDone);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                playerTroop.TroopCount += query.InTrainingPrisonerCount;
                response.Data = query.InTrainingPrisonerCount;
                query.InTrainingPrisonerCount = 0;
                query.TrainingDoneDate = null;
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

        #endregion


        #region LOOTRUN UTILS

        [Obsolete("deprecated", true)]
        public async Task<TDResponse<List<PlayerHeroLootDTO>>> GetActiveLootRuns(BaseRequest req, UserDto user)
        {
            TDResponse<List<PlayerHeroLootDTO>> response = new TDResponse<List<PlayerHeroLootDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetActiveLootRuns");
            try
            {
                response.Data = new List<PlayerHeroLootDTO>();
                //response.Data.GainedLootRuns = new List<LootRunDoneInfoDTO>();
                var playerHeroLoot = await _context.PlayerHeroLoot.Include(l => l.PlayerHero).ThenInclude(l => l.Hero).Where(l => l.PlayerHero.UserId == user.Id && l.IsActive).ToListAsync();
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                foreach (var loot in playerHeroLoot)
                {
                    if (loot.AutoLootRunEndDate != null)
                    {
                        var oneLootDuration = loot.OperationEndDate - loot.OperationStartDate;
                        if (DateTimeOffset.Now > loot.OperationEndDate)
                        {
                            loot.IsActive = false;
                            var gainedResource = JsonConvert.DeserializeObject<LootRunDoneInfoDTO>(loot.GainedResources);
                            playerBaseInfo!.Scraps += gainedResource?.ScrapCount ?? 0;
                            playerBaseInfo!.BluePrints += gainedResource?.BluePrintCount ?? 0;
                            playerBaseInfo!.Gems += gainedResource?.GemCount ?? 0;
                            gainedResource.StartDate = loot.OperationStartDate.ToString();
                            gainedResource.EndDate = loot.OperationEndDate.ToString();
                            //response.Data.GainedLootRuns.Add(gainedResource); //TODO: SONRADAN MAIL ISLEMI YAZILACAK
                        }
                        else
                        {
                            response.Data.Add(_mapper.Map<PlayerHeroLootDTO>(loot));
                        }

                        var initialDate = loot.OperationEndDate;
                        while (initialDate < DateTimeOffset.Now && initialDate <= loot.AutoLootRunEndDate)
                        {
                            var gainedLoots = await GetLootGainedResource(loot.PlayerHero, initialDate, initialDate + oneLootDuration);
                            var ent = new PlayerHeroLoot()
                            {
                                IsActive = true,
                                LootLevelId = loot.LootLevelId,
                                OperationStartDate = initialDate,
                                OperationEndDate = initialDate + oneLootDuration,
                                GainedResources = JsonConvert.SerializeObject(gainedLoots),
                                PlayerHeroId = loot.PlayerHeroId,
                                AutoLootRunEndDate = loot.AutoLootRunEndDate,
                                PlayerHero = loot.PlayerHero
                            };

                            if (ent.OperationEndDate < DateTimeOffset.Now)
                            {
                                ent.IsActive = false;
                                playerBaseInfo!.Scraps += gainedLoots?.ScrapCount ?? 0;
                                playerBaseInfo!.BluePrints += gainedLoots?.BluePrintCount ?? 0;
                                playerBaseInfo!.Gems += gainedLoots?.GemCount ?? 0;
                                //response.Data.GainedLootRuns.Add(gainedLoots);//TODO: SONRADAN MAIL ISLEMI YAZILACAK
                            }
                            else
                            {
                                response.Data.Add(_mapper.Map<PlayerHeroLootDTO>(ent));
                            }

                            await _context.AddAsync(ent);

                            initialDate += oneLootDuration;
                        }
                        _context.Update(playerBaseInfo);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        response.Data.Add(_mapper.Map<PlayerHeroLootDTO>(loot));
                    }
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

        public async Task<TDResponse<LootRunResponse>> GetActiveLootRunsForSocket(BaseRequest req, UserDto user)
        {
            TDResponse<LootRunResponse> response = new TDResponse<LootRunResponse>();
            var info = InfoDetail.CreateInfo(req, "GetActiveLootRunsForSocket");
            try
            {
                response.Data = new LootRunResponse();
                response.Data.GainedLootRuns = new List<LootRunDoneInfoDTO>();
                response.Data.ActiveLootRuns = new List<PlayerHeroLootDTO>();
                var playerHeroLoot = await _context.PlayerHeroLoot.Include(l => l.PlayerHero).ThenInclude(l => l.Hero).Where(l => l.PlayerHero.UserId == user.Id && l.IsActive).ToListAsync();
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                foreach (var loot in playerHeroLoot)
                {
                    if (loot.AutoLootRunEndDate != null)
                    {
                        var oneLootDuration = loot.OperationEndDate - loot.OperationStartDate;
                        if (DateTimeOffset.Now > loot.OperationEndDate)
                        {
                            loot.IsActive = false;
                            var gainedResource = JsonConvert.DeserializeObject<LootRunDoneInfoDTO>(loot.GainedResources);
                            gainedResource.StartDate = loot.OperationStartDate.ToString();
                            gainedResource.EndDate = loot.OperationEndDate.ToString();
                            gainedResource.HeroId = loot.PlayerHero.HeroId;
                            gainedResource.HeroName = loot.PlayerHero.Hero.Name;
                            response.Data.GainedLootRuns.Add(gainedResource);
                        }
                        else
                        {
                            response.Data.ActiveLootRuns.Add(_mapper.Map<PlayerHeroLootDTO>(loot));
                        }

                        var initialDate = loot.OperationEndDate;
                        while (initialDate < DateTimeOffset.Now && initialDate <= loot.AutoLootRunEndDate)
                        {
                            var gainedLoots = await GetLootGainedResource(loot.PlayerHero, initialDate, initialDate + oneLootDuration);
                            var ent = new PlayerHeroLoot()
                            {
                                IsActive = true,
                                LootLevelId = loot.LootLevelId,
                                OperationStartDate = initialDate,
                                OperationEndDate = initialDate + oneLootDuration,
                                GainedResources = JsonConvert.SerializeObject(gainedLoots),
                                PlayerHeroId = loot.PlayerHeroId,
                                AutoLootRunEndDate = loot.AutoLootRunEndDate,
                                PlayerHero = loot.PlayerHero
                            };

                            if (ent.OperationEndDate < DateTimeOffset.Now)
                            {
                                ent.IsActive = false;
                                response.Data.GainedLootRuns.Add(gainedLoots);
                            }
                            else
                            {
                                response.Data.ActiveLootRuns.Add(_mapper.Map<PlayerHeroLootDTO>(ent));
                            }

                            await _context.AddAsync(ent);

                            initialDate += oneLootDuration;
                        }

                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        if (DateTimeOffset.Now > loot.OperationEndDate)
                        {
                            loot.IsActive = false;
                            await _context.SaveChangesAsync();
                            var gainedResource = JsonConvert.DeserializeObject<LootRunDoneInfoDTO>(loot.GainedResources);
                            gainedResource.StartDate = loot.OperationStartDate.ToString();
                            gainedResource.EndDate = loot.OperationEndDate.ToString();
                            response.Data.GainedLootRuns.Add(gainedResource);
                        }
                        else
                        {
                            response.Data.ActiveLootRuns.Add(_mapper.Map<PlayerHeroLootDTO>(loot));
                        }
                    }
                }

                _context.Update(playerBaseInfo);
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
        public async Task<TDResponse<LootRunPredictionInfo>> GetLootRunPrediction(BaseRequest<int> req, UserDto user)
        {
            TDResponse<LootRunPredictionInfo> response = new TDResponse<LootRunPredictionInfo>();
            var info = InfoDetail.CreateInfo(req, "GetLootRunPrediction");
            try
            {
                var playerHero = await _context.PlayerHero.Where(l => l.UserId == user.Id && l.HeroId == req.Data).FirstOrDefaultAsync();
                if (playerHero == null) //TODO: 2 HERO GÖNDERME İŞLEMİ SONRA YAPILACAK
                {
                    response.SetError(OperationMessages.PlayerHaveNoHero);
                    info.AddInfo(OperationMessages.PlayerHaveNoHero);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var lootLevelId = await _context.PlayerBasePlacement
                    .Where(l => l.UserId == user.Id && l.BuildingTypeId == 8)//8 watch tower
                    .Select(l => l.BuildingLevel).FirstOrDefaultAsync();

                var lootLevel = await _context.LootLevel
                    .Where(l => l.Id == lootLevelId).FirstOrDefaultAsync();

                #region Resource Calculation

                var heroLevelBuff = await _context.HeroLevelThreshold.Include(l => l.Buff)
                    .Where(l => l.HeroId == playerHero.HeroId && l.Level == playerHero.CurrentLevel).Select(l => l.Buff).FirstOrDefaultAsync();

                var heroSkillBuffs = await _context.PlayerHeroSkillLevel.Include(l => l.HeroSkillLevel).ThenInclude(l => l.Buff).Where(l => l.UserId == user.Id && l.HeroSkillLevel.HeroSkill
                .HeroId == req.Data).ToListAsync();

                var totalScrapMultiplier = (heroSkillBuffs?.Sum(l => l.HeroSkillLevel.Buff.LootScrapMultiplier) ?? 0) + heroLevelBuff.LootScrapMultiplier;
                var totalBluePrintMultiplier = (heroSkillBuffs?.Sum(l => l.HeroSkillLevel.Buff.LootBluePrintMultiplier) ?? 0) + heroLevelBuff.LootBluePrintMultiplier;
                var totalGemMultiplier = (heroSkillBuffs?.Sum(l => l.HeroSkillLevel.Buff.LootGemMultiplier) ?? 0) + heroLevelBuff.LootGemMultiplier;
                var totalDurationMultiplier = (heroSkillBuffs?.Sum(l => l.HeroSkillLevel.Buff.LootDurationMultiplier) ?? 0) + heroLevelBuff.LootDurationMultiplier;

                var calculated = new LootRunPredictionInfo()
                {
                    MinScrapCount = (int)(lootLevel.MinScrapCount * totalScrapMultiplier),
                    MaxScrapCount = (int)(lootLevel.MaxScrapCount * totalScrapMultiplier),
                    ScrapHeroLevelBonus = totalScrapMultiplier,
                    BlueprintDoubleChance = totalBluePrintMultiplier,
                    MinGemCount = lootLevel.MinGemCount + (int)(lootLevel.MinGemCount * totalGemMultiplier),
                    MaxGemCount = lootLevel.MaxGemCount + (int)(lootLevel.MaxGemCount * totalGemMultiplier),
                    MinBluePrintCount = lootLevel.MinBlueprintCount,
                    LootDuration = lootLevel.LootDuration + (lootLevel.LootDuration * totalDurationMultiplier)
                };

                #endregion


                response.Data = calculated;
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

        [Obsolete("deprecated", true)]
        public async Task<TDResponse<string>> SpeedUpLootRun(BaseRequest<SpeedUpRequest> req, UserDto user)
        {
            TDResponse<string> response = new TDResponse<string>();
            var info = InfoDetail.CreateInfo(req, "SpeedUpLootRun");
            try
            {
                if (req.Data == null)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var playerHeroLoot = await _context.PlayerHeroLoot
                    .Where(l => l.PlayerHero.UserId == user.Id && l.PlayerHero.HeroId == req.Data.GenericId).FirstOrDefaultAsync();

                if (playerHeroLoot == null || playerHeroLoot.OperationEndDate == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var playerItem = await _context.PlayerItem.Include(l => l.Item)
                    .Where(l => l.ItemId == req.Data.ItemId && l.UserId == user.Id && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp).FirstOrDefaultAsync();

                if ((playerItem == null || playerItem.Count < req.Data.Count) && !req.Data.Buy)
                {
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (req.Data.Buy && (playerItem == null || playerItem.Count < req.Data.Count))
                {
                    var marketItemId = await _context.MarketItem
                        .Where(l => l.ItemId == req.Data.ItemId && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp && l.IsActive)
                        .Select(l => l.Id).FirstOrDefaultAsync();
                    var marketReq = new BaseRequest<BuyMarketItemRequest>()
                    {
                        Info = req.Info,
                        Data = new BuyMarketItemRequest()
                        {
                            Count = req.Data.Count,
                            MarketItemId = marketItemId,
                        }
                    };
                    var buyResponse = await BuyMarketItem(marketReq, user);
                    if (buyResponse.HasError)
                    {
                        response.SetError(buyResponse.Message);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                    else
                    {
                        playerItem = await _context.PlayerItem.Include(l => l.Item)
                            .Where(l => l.ItemId == req.Data.ItemId && l.UserId == user.Id && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp).FirstOrDefaultAsync();
                    }
                }

                playerHeroLoot.OperationEndDate -= new TimeSpan(0, req.Data.Count * playerItem.Item.Value1 ?? 0, 0);
                playerItem.Count -= req.Data.Count;
                await _context.SaveChangesAsync();

                response.Data = playerHeroLoot.OperationEndDate.ToString();
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
        public async Task<TDResponse> SendLootRun(BaseRequest<SendLootRunRequest> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "SendLootRun");
            try
            {
                var playerHeroLoot = await _context.PlayerHeroLoot.Include(l => l.PlayerHero).Where(l => l.PlayerHero.UserId == user.Id && l.IsActive).FirstOrDefaultAsync();

                if (playerHeroLoot != null) //TODO: 2 HERO GÖNDERME İŞLEMİ SONRA YAPILACAK
                {
                    response.SetError(OperationMessages.ProcessAllreadyExist);
                    info.AddInfo(OperationMessages.ProcessAllreadyExist);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var playerHero = await _context.PlayerHero.Include(l=>l.Hero).Where(l => l.UserId == user.Id && l.HeroId == req.Data.HeroId).FirstOrDefaultAsync();
                if (playerHero == null) //TODO: 2 HERO GÖNDERME İŞLEMİ SONRA YAPILACAK
                {
                    response.SetError(OperationMessages.PlayerHaveNoHero);
                    info.AddInfo(OperationMessages.PlayerHaveNoHero);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if ((await _context.Attack.Where(l=>l.AttackerHeroId==playerHero.HeroId && l.AttackerUserId==playerHero.UserId && l.IsActive).AnyAsync())||
                    (await _context.RallyPart.Where(l=>l.HeroId==playerHero.HeroId && l.UserId==playerHero.UserId && l.IsActive).AnyAsync())
                    )
                {
                    response.SetError(OperationMessages.PlayerHeroBusy);
                    info.AddInfo(OperationMessages.PlayerHeroBusy);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var lootLevelId = await _context.PlayerBasePlacement
                    .Where(l => l.UserId == playerHero.UserId && l.BuildingTypeId == 8)//8 watch tower
                    .Select(l => l.BuildingLevel).FirstOrDefaultAsync();

                var lootLevel = await _context.LootLevel
                    .Where(l => l.Id == lootLevelId).FirstOrDefaultAsync();

                #region Resource Calculation

                var heroLevelBuff = await _context.HeroLevelThreshold.Include(l => l.Buff)
                    .Where(l => l.HeroId == playerHero.HeroId && l.Level == playerHero.CurrentLevel).Select(l => l.Buff).FirstOrDefaultAsync();

                var heroSkillBuffs = await _context.PlayerHeroSkillLevel.Include(l => l.HeroSkillLevel).ThenInclude(l => l.Buff)
                    .Where(l => l.UserId == playerHero.UserId && l.HeroSkillLevel.HeroSkill.HeroId == playerHero.HeroId).ToListAsync();

                var totalScrapMultiplier = (heroSkillBuffs?.Sum(l => l.HeroSkillLevel.Buff.LootScrapMultiplier) ?? 0) + heroLevelBuff.LootScrapMultiplier;
                var totalBluePrintMultiplier = (heroSkillBuffs?.Sum(l => l.HeroSkillLevel.Buff.LootBluePrintMultiplier) ?? 0) + heroLevelBuff.LootBluePrintMultiplier;
                var totalGemMultiplier = (heroSkillBuffs?.Sum(l => l.HeroSkillLevel.Buff.LootGemMultiplier) ?? 0) + heroLevelBuff.LootGemMultiplier;
                var totalDurationMultiplier = (heroSkillBuffs?.Sum(l => l.HeroSkillLevel.Buff.LootDurationMultiplier) ?? 0) + heroLevelBuff.LootDurationMultiplier;

                var calculated = new LootRunDoneInfoDTO()
                {
                    ScrapCount = LootRandomer.GetRandomScrap((int)(lootLevel.MinScrapCount * totalScrapMultiplier), (int)(lootLevel.MaxScrapCount * totalScrapMultiplier)),
                    GemCount = LootRandomer.GetRandomGem((int)(lootLevel.MinGemCount * totalGemMultiplier), lootLevel.MaxGemCount + (int)(lootLevel.MaxGemCount * totalGemMultiplier)),
                    BluePrintCount = LootRandomer.GetRandomBlueprint(lootLevel.MinBlueprintCount, totalBluePrintMultiplier),
                    StartDate = DateTimeOffset.Now.ToString(),
                    EndDate = (DateTimeOffset.Now + (lootLevel.LootDuration + lootLevel.LootDuration * totalDurationMultiplier)).ToString(),
                    HeroId = playerHero.HeroId,
                    HeroName = playerHero.Hero.Name
                };

                #endregion

                var ent = new PlayerHeroLoot()
                {
                    LootLevelId = lootLevelId,
                    PlayerHeroId = await _context.PlayerHero.Where(l => l.HeroId == req.Data.HeroId && l.UserId == user.Id).Select(l => l.Id).FirstOrDefaultAsync(),
                    OperationEndDate = DateTimeOffset.Now + (lootLevel.LootDuration + lootLevel.LootDuration * totalDurationMultiplier),
                    OperationStartDate = DateTimeOffset.Now,
                    GainedResources = JsonConvert.SerializeObject(calculated),
                    IsActive = true,
                    LootLevel = lootLevel,
                    AutoLootRunEndDate = req.Data.AutoLootRun ? DateTimeOffset.Now + TimeSpan.FromHours(8) : null
                };

                await _context.AddAsync(ent);
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
        public async Task<TDResponse> OpenCloseAutoRun(BaseRequest<SendLootRunRequest> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "OpenCloseAutoRun");
            try
            {
                var playerHeroLoot = await _context.PlayerHeroLoot.Include(l => l.PlayerHero).Where(l => l.PlayerHero.UserId == user.Id && l.IsActive).FirstOrDefaultAsync();

                if (playerHeroLoot == null) //TODO: 2 HERO GÖNDERME İŞLEMİ SONRA YAPILACAK
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                playerHeroLoot.AutoLootRunEndDate = req.Data.AutoLootRun ? DateTimeOffset.Now + TimeSpan.FromHours(8) : null;

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
        public async Task<TDResponse<LootRunDoneInfoDTO>> LootRunDoneRequest(BaseRequest<int> req, UserDto user)
        {
            TDResponse<LootRunDoneInfoDTO> response = new TDResponse<LootRunDoneInfoDTO>();
            var info = InfoDetail.CreateInfo(req, "LootRunDoneRequest");
            try
            {
                var playerHeroLoot = await _context.PlayerHeroLoot.Include(l => l.PlayerHero)
                    .Where(l => l.PlayerHero.UserId == user.Id && l.PlayerHero.HeroId == req.Data && l.IsActive).FirstOrDefaultAsync();

                if (playerHeroLoot == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if ((playerHeroLoot.OperationEndDate - DateTimeOffset.Now).TotalSeconds > 2)
                {
                    response.SetError(OperationMessages.ProcessAllreadyExist);
                    info.AddInfo(OperationMessages.ProcessAllreadyExist);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                playerHeroLoot.IsActive = false;
                if (playerHeroLoot.AutoLootRunEndDate >= playerHeroLoot.OperationEndDate)
                {
                    var gained = await GetLootGainedResource(playerHeroLoot.PlayerHero, playerHeroLoot.OperationEndDate, (playerHeroLoot.OperationEndDate + (playerHeroLoot.OperationEndDate - playerHeroLoot.OperationStartDate)));
                    var phl = new PlayerHeroLoot()
                    {
                        IsActive = true,
                        OperationEndDate = playerHeroLoot.OperationEndDate + (playerHeroLoot.OperationEndDate - playerHeroLoot.OperationStartDate),
                        AutoLootRunEndDate = playerHeroLoot.AutoLootRunEndDate,
                        OperationStartDate = playerHeroLoot.OperationEndDate,
                        LootLevelId = playerHeroLoot.LootLevelId,
                        PlayerHeroId = playerHeroLoot.PlayerHeroId,
                        GainedResources = JsonConvert.SerializeObject(gained)
                    };
                    await _context.AddAsync(phl);
                }
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                var gainedResource = JsonConvert.DeserializeObject<LootRunDoneInfoDTO>(playerHeroLoot.GainedResources);
                //playerBaseInfo!.Scraps += gainedResource?.ScrapCount ?? 0;
                //playerBaseInfo!.BluePrints += gainedResource?.BluePrintCount ?? 0;
                //playerBaseInfo!.Gems += gainedResource?.GemCount ?? 0;

                await _context.SaveChangesAsync();

                response.Data = gainedResource;
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

        #endregion


        #region HOSPITAL UTILS

        public async Task<TDResponse<PlayerHospitalDTO>> GetHospitalInfo(BaseRequest req, UserDto user)
        {
            TDResponse<PlayerHospitalDTO> response = new TDResponse<PlayerHospitalDTO>();
            var info = InfoDetail.CreateInfo(req, "GetHospitalInfo");
            try
            {
                var query = _context.PlayerHospital.Include(l => l.HospitalLevel).Where(l => l.UserId == user.Id);
                var phospital = await _mapper.ProjectTo<PlayerHospitalDTO>(query).FirstOrDefaultAsync();
                if (phospital == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                response.Data = phospital;
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

        public async Task<TDResponse> HealingRequest(BaseRequest<int> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "HealingRequest");
            try
            {
                var query = await _context.PlayerHospital.Include(l => l.HospitalLevel).Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                if (req.Data < 1)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (query.InjuredCount < req.Data)
                {
                    req.Data = query.InjuredCount;
                }
                if (query.InHealingCount != 0)
                {
                    response.SetError(OperationMessages.HealingMustBeDone);
                    info.AddInfo(OperationMessages.HealingMustBeDone);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (playerBaseInfo.Scraps < (int)(req.Data * query.HospitalLevel.HealingCostPerUnit))
                {
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                query.InjuredCount -= req.Data;
                query.InHealingCount += req.Data;
                query.HealingDoneDate = DateTimeOffset.Now + (query.HospitalLevel.HealingDurationPerUnit * req.Data);
                playerBaseInfo.Scraps -= (int)(req.Data * query.HospitalLevel.HealingCostPerUnit);
                _context.Update(playerBaseInfo);
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

        public async Task<TDResponse<string>> SpeedUpHealing(BaseRequest<SpeedUpRequest> req, UserDto user)
        {
            TDResponse<string> response = new TDResponse<string>();
            var info = InfoDetail.CreateInfo(req, "SpeedUpHealing");
            try
            {
                if (req.Data == null)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var playerHospital = await _context.PlayerHospital
                    .Where(l => l.UserId == user.Id).FirstOrDefaultAsync();

                if (playerHospital == null || playerHospital.HealingDoneDate == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var playerItem = await _context.PlayerItem.Include(l => l.Item)
                    .Where(l => l.ItemId == req.Data.ItemId && l.UserId == user.Id && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp).FirstOrDefaultAsync();

                if ((playerItem == null || playerItem.Count < req.Data.Count) && !req.Data.Buy)
                {
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (req.Data.Buy && (playerItem == null || playerItem.Count < req.Data.Count))
                {
                    var marketItemId = await _context.MarketItem
                        .Where(l => l.ItemId == req.Data.ItemId && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp && l.IsActive)
                        .Select(l => l.Id).FirstOrDefaultAsync();
                    var marketReq = new BaseRequest<BuyMarketItemRequest>()
                    {
                        Info = req.Info,
                        Data = new BuyMarketItemRequest()
                        {
                            Count = req.Data.Count,
                            MarketItemId = marketItemId,
                        }
                    };
                    var buyResponse = await BuyMarketItem(marketReq, user);
                    if (buyResponse.HasError)
                    {
                        response.SetError(buyResponse.Message);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                    else
                    {
                        playerItem = await _context.PlayerItem.Include(l => l.Item)
                            .Where(l => l.ItemId == req.Data.ItemId && l.UserId == user.Id && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp).FirstOrDefaultAsync();
                    }
                }

                playerHospital.HealingDoneDate -= new TimeSpan(0, req.Data.Count * playerItem.Item.Value1 ?? 0, 0);
                playerItem.Count -= req.Data.Count;
                await _context.SaveChangesAsync();

                response.Data = playerHospital.HealingDoneDate.ToString();
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

        public async Task<TDResponse<int>> HealingDoneRequest(BaseRequest req, UserDto user)
        {
            TDResponse<int> response = new TDResponse<int>();
            var info = InfoDetail.CreateInfo(req, "HealingDoneRequest");
            try
            {
                var query = await _context.PlayerHospital.Include(l => l.HospitalLevel).Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                var playerTroop = await _context.PlayerTroop.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (query.InHealingCount == 0)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if ((query.HealingDoneDate - DateTimeOffset.Now).Value.TotalMilliseconds > 0)
                {
                    response.SetError(OperationMessages.HealingMustBeDone);
                    info.AddInfo(OperationMessages.HealingMustBeDone);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                playerTroop.TroopCount += query.InHealingCount;
                response.Data = query.InHealingCount;
                query.InHealingCount = 0;
                query.HealingDoneDate = null;
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

        #endregion

        #region SCOUT UTILS
        public async Task<TDResponse<PlayerScoutDTO>> GetScoutInfo(BaseRequest req, UserDto user)
        {
            TDResponse<PlayerScoutDTO> response = new TDResponse<PlayerScoutDTO>();
            var info = InfoDetail.CreateInfo(req, "GetScoutInfo");
            try
            {
                var query = _context.PlayerScout.Include(l => l.ScoutLevel).Where(l => l.UserId == user.Id);
                var pscout = await _mapper.ProjectTo<PlayerScoutDTO>(query).FirstOrDefaultAsync();
                if (pscout == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                response.Data = pscout;
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

        public async Task<TDResponse> SpyTrainingRequest(BaseRequest<int> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "SpyTrainingRequest");
            try
            {
                var query = await _context.PlayerScout.Include(l => l.ScoutLevel).Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                if (req.Data < 1)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                if (query.InTrainingCount != 0)
                {
                    response.SetError(OperationMessages.TrainingMustBeDone);
                    info.AddInfo(OperationMessages.TrainingMustBeDone);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (playerBaseInfo.Scraps < (int)(req.Data * query.ScoutLevel.TrainingCostPerUnit))
                {
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                query.InTrainingCount += req.Data;
                query.TrainingDoneDate = DateTimeOffset.Now + (query.ScoutLevel.TrainingDurationPerUnit * req.Data);
                playerBaseInfo.Scraps -= (int)(req.Data * query.ScoutLevel.TrainingCostPerUnit);
                _context.Update(playerBaseInfo);
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
        
        public async Task<TDResponse<int>> SpyTrainingDoneRequest(BaseRequest req, UserDto user)
        {
            TDResponse<int> response = new TDResponse<int>();
            var info = InfoDetail.CreateInfo(req, "SpyTrainingDoneRequest");
            try
            {
                var query = await _context.PlayerScout.Include(l => l.ScoutLevel).Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                var playerScout = await _context.PlayerScout.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (query.InTrainingCount == 0)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if ((query.TrainingDoneDate - DateTimeOffset.Now).Value.TotalMilliseconds > 0)
                {
                    response.SetError(OperationMessages.TrainingMustBeDone);
                    info.AddInfo(OperationMessages.TrainingMustBeDone);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                playerScout.SpyCount += query.InTrainingCount;
                response.Data = query.InTrainingCount;
                query.InTrainingCount = 0;
                query.TrainingDoneDate = null;
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
        
        #endregion

        #region MARKET UTILS

        public async Task<TDResponse<MarketDTO>> GetMarket(BaseRequest req, UserDto user)
        {
            TDResponse<MarketDTO> response = new TDResponse<MarketDTO>();
            var info = InfoDetail.CreateInfo(req, "GetMarket");
            try
            {
                var nowDay = DateTimeOffset.UtcNow.Day;
                var query = await _context.MarketItem.Include(l => l.Item).ThenInclude(l => l.ItemType)
                    .Where(l => l.IsActive)
                    .Select(l=>new MarketItem()
                    {
                        Id = l.Id,
                        Item = l.Item,
                        GemPrice = l.GemPrice,
                        IsActive = l.IsActive,
                        ItemId = l.ItemId,
                        MaxCount = l.MaxCount - _context.PlayerMarketHistory.Where(k => k.UserId==user.Id &&k.PurchaseDate.Day==nowDay &&k.MarketItemId==l.Id).Sum(l=>l.Count),
                        ScrapPrice = l.ScrapPrice,
                        MarketOrderId = l.MarketOrderId
                    } )
                    .OrderBy(l => l.Item.ItemTypeId).ToListAsync();

                response.Data = new MarketDTO();
                var qq = query.GroupBy(l => l.Item.ItemType.ItemCategoryId).OrderBy(l => l.Key).ToList();
                for (int i = 0; i < qq.Count(); i++)
                {
                    switch (qq[i].Key)
                    {
                        case 1:
                            response.Data.Resources = _mapper.ProjectTo<MarketItemDTO>(qq?[i].OrderBy(l => l.MarketOrderId).ToList().AsQueryable()).ToList();
                            break;
                        case 2:
                            response.Data.SpeedUps = _mapper.ProjectTo<MarketItemDTO>(qq?[i].OrderBy(l => l.MarketOrderId).ToList().AsQueryable()).ToList();
                            break;
                        case 3:
                            response.Data.Buffs = _mapper.ProjectTo<MarketItemDTO>(qq?[i].OrderBy(l => l.MarketOrderId).ToList().AsQueryable()).ToList();
                            break;
                        case 4:
                            response.Data.Others = _mapper.ProjectTo<MarketItemDTO>(qq?[i].OrderBy(l => l.MarketOrderId).ToList().AsQueryable()).ToList();
                            break;
                        default:
                            break;
                    }
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

        public async Task<TDResponse> BuyMarketItem(BaseRequest<BuyMarketItemRequest> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "BuyMarketItem");
            try
            {
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                var marketItem = await _context.MarketItem.Include(l => l.Item).Where(l => l.Id == (req.Data == null ? 0 : req.Data.MarketItemId) && l.IsActive).FirstOrDefaultAsync();

                if (marketItem == null || playerBaseInfo == null || req.Data == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if ((marketItem.ScrapPrice != 0 && playerBaseInfo.Scraps < marketItem.ScrapPrice * req.Data.Count) || (marketItem.GemPrice != 0 && playerBaseInfo.Gems < marketItem.GemPrice * req.Data.Count))
                {
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var history = new PlayerMarketHistory()
                {
                    Count = req.Data.Count,
                    MarketItemId = marketItem.Id,
                    PurchaseDate = DateTimeOffset.Now,
                    UserId = user.Id,
                    BeforeGemCount = playerBaseInfo.Gems,
                    AfterGemCount = -1,
                    BeforeScrapCount = playerBaseInfo.Scraps,
                    AfterScrapCount = -1
                };

                var query = await _context.PlayerItem
                    .Where(l => l.UserId == user.Id && l.ItemId == marketItem.ItemId).FirstOrDefaultAsync();

                if (query == null)
                {
                    await _context.AddAsync(new PlayerItem()
                    {
                        ItemId = marketItem.ItemId,
                        Count = req.Data.Count,
                        UserId = user.Id
                    });
                }
                else
                {
                    query.Count += req.Data.Count;
                }

                playerBaseInfo.Gems -= marketItem.GemPrice * req.Data.Count;
                playerBaseInfo.Scraps -= marketItem.ScrapPrice * req.Data.Count;
                history.AfterScrapCount = playerBaseInfo.Scraps;
                history.AfterGemCount = playerBaseInfo.Gems;
                _context.Update(playerBaseInfo);
                await _context.AddAsync(history);
                await _context.SaveChangesAsync();
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());


                if (
                    (new int[] { (int)ItemTypeEnum.RareHeroCard, (int)ItemTypeEnum.EpicHeroCard, (int)ItemTypeEnum.LegendaryHeroCard }).Contains(marketItem.Item.ItemTypeId)
                    &&
                    marketItem.Item.Value1 == 1)
                {
                    var useReq = new BaseRequest<UseItemRequest>()
                    {
                        Info = req.Info,
                        Data = new UseItemRequest()
                        {
                            Count = req.Data.Count,
                            ItemId = marketItem.ItemId
                        }
                    };
                    var useResponse = await UseItem(useReq, user);
                    if (useResponse.HasError)
                    {
                        response.SetSuccess(OperationMessages.ItemBuyedButNotUsed);
                        info.AddInfo(OperationMessages.ItemBuyedButNotUsed);
                        _logger.LogInformation(info.ToString());
                    }

                }




            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }

        public async Task<TDResponse<InventoryDTO>> GetInventory(BaseRequest req, UserDto user)
        {
            TDResponse<InventoryDTO> response = new TDResponse<InventoryDTO>();
            var info = InfoDetail.CreateInfo(req, "GetInventory");
            try
            {
                var query = await _context.PlayerItem.Include(l => l.Item).ThenInclude(l => l.ItemType).Where(l => l.UserId == user.Id && l.Count != 0)
                    .OrderBy(l => l.Item.ItemTypeId).ToListAsync();

                response.Data = new InventoryDTO();
                var qq = query.GroupBy(l => l.Item.ItemType.ItemCategoryId).OrderBy(l => l.Key).ToList();
                for (int i = 0; i < qq.Count(); i++)
                {
                    switch (qq[i].Key)
                    {
                        case 1:
                            response.Data.Resources = _mapper.ProjectTo<PlayerItemDTO>(qq?[i].OrderBy(l => l.Id).ToList().AsQueryable()).ToList();
                            break;
                        case 2:
                            response.Data.SpeedUps = _mapper.ProjectTo<PlayerItemDTO>(qq?[i].OrderBy(l => l.Id).ToList().AsQueryable()).ToList();
                            break;
                        case 3:
                            response.Data.Buffs = _mapper.ProjectTo<PlayerItemDTO>(qq?[i].OrderBy(l => l.Id).ToList().AsQueryable()).ToList();
                            break;
                        case 4:
                            response.Data.Others = _mapper.ProjectTo<PlayerItemDTO>(qq?[i].OrderBy(l => l.Id).ToList().AsQueryable()).ToList();
                            break;
                        default:
                            break;
                    }
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
        #endregion


        #region DIALOG UTILS
        public async Task<TDResponse<List<DialogDTO>>> GetDialogByCodeName(BaseRequest<string> req, UserDto user)
        {
            TDResponse<List<DialogDTO>> response = new TDResponse<List<DialogDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetDialogByCodeName");
            try
            {
                var query = _context.Dialog.Include(l => l.DialogScene)
                    .Where(l => l.DialogScene.DialogSceneCode == req.Data).OrderBy(l => l.PlaceId);

                response.Data = await _mapper.ProjectTo<DialogDTO>(query).ToListAsync();


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
        #endregion


        #region ITEM UTILS


        public async Task<TDResponse> UseItem(BaseRequest<UseItemRequest> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "UseItem");
            try
            {
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                var playerItem = await _context.PlayerItem.Include(l => l.Item).ThenInclude(l => l.ItemType)
                    .Where(l => l.ItemId == (req.Data == null ? 0 : req.Data.ItemId) && l.UserId == user.Id).FirstOrDefaultAsync();
                if (playerItem == null || playerBaseInfo == null || req.Data == null || req.Data.Count <= 0)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (playerItem.Count < req.Data.Count)
                {
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (!playerItem.Item.ItemType.IsActive || !playerItem.Item.ItemType.IsConsumable)
                {
                    response.SetError(OperationMessages.ItemNotUsable);
                    info.AddInfo(OperationMessages.ItemNotUsable);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                Buff buff = new Buff();
                switch (playerItem.Item.ItemTypeId)
                {
                    case ((int)ItemTypeEnum.RareHeroCard):
                        playerBaseInfo.RareHeroCards += req.Data.Count * playerItem.Item.Value1 ?? 0;
                        break;
                    case ((int)ItemTypeEnum.EpicHeroCard):
                        playerBaseInfo.EpicHeroCards += req.Data.Count * playerItem.Item.Value1 ?? 0;
                        break;
                    case ((int)ItemTypeEnum.LegendaryHeroCard):
                        playerBaseInfo.LegendaryHeroCards += req.Data.Count * playerItem.Item.Value1 ?? 0;
                        break;
                    case ((int)ItemTypeEnum.Blueprint):
                        playerBaseInfo.BluePrints += req.Data.Count * playerItem.Item.Value1 ?? 0;
                        break;
                    case ((int)ItemTypeEnum.Scrap):
                        playerBaseInfo.Scraps += req.Data.Count * playerItem.Item.Value1 ?? 0;
                        break;
                    case ((int)ItemTypeEnum.Gem):
                        playerBaseInfo.Gems += req.Data.Count * playerItem.Item.Value1 ?? 0;
                        break;
                    case ((int)ItemTypeEnum.Fuel):
                        playerBaseInfo.Fuel += req.Data.Count * playerItem.Item.Value1 ?? 0;
                        break;
                    case ((int)ItemTypeEnum.CityShield):
                        if (
                        await _context.Attack.Where(l=>l.IsActive && (l.AttackerUserId==user.Id) || (l.TargetUserId==user.Id && l.ResultData == null)).AnyAsync()
                        ||
                        await _context.RallyPart.Where(l=>l.IsActive && (l.UserId==user.Id)).AnyAsync()
                        ||
                        await _context.Rally.Where(l=>l.IsActive && (l.TargetUserId==user.Id) && (l.WinnerSide!=null)).AnyAsync()
                        )
                        {
                            response.SetError(OperationMessages.ItemNotUsableWhileAttack);
                            info.AddInfo(OperationMessages.ItemNotUsableWhileAttack);
                            _logger.LogInformation(info.ToString());
                            return response;
                        }
                        buff = new Buff()
                        {
                            Name = "city-shield-" + user.Username,
                            Description = "city-shield-" + user.Username,
                            CityShieldActive = true
                        };
                        break;
                    case ((int)ItemTypeEnum.SpyFaker):
                        buff = new Buff()
                        {
                            Name = "spy-faker-" + user.Username,
                            Description = "spy-faker-" + user.Username,
                            SpyFakerMultiplier = playerItem.Item.Value2 ?? 2
                        };
                        break;
                    case ((int)ItemTypeEnum.DefenseIncrease):
                        buff = new Buff()
                        {
                            Name = "def-increase-" + user.Username,
                            Description = "def-increase-" + user.Username,
                            DefenseMultiplier = (double?)playerItem.Item.Value2 / 100 ?? 0.05
                        };
                        break;
                    case ((int)ItemTypeEnum.AttackIncrease):
                        buff = new Buff()
                        {
                            Name = "atk-increase-" + user.Username,
                            Description = "atk-increase-" + user.Username,
                            AttackMultiplier = (double?)playerItem.Item.Value2 / 100 ?? 0.05
                        };
                        break;
                    case ((int)ItemTypeEnum.SpyProtection):
                        buff = new Buff()
                        {
                            Name = "Spy-Protection-" + user.Username,
                            Description = "Spy-Protection-" + user.Username,
                            SpyProtectionActive = true
                        };
                        break;
                    case ((int)ItemTypeEnum.TroopCapEnhancer):
                        buff = new Buff()
                        {
                            Name = "troop-capacity-" + user.Username,
                            Description = "troop-capacity-" + user.Username,
                            TroopCapacityMultiplier = (double?)playerItem.Item.Value2 / 100 ?? 0.05
                        };
                        break;

                }
                _context.Update(playerBaseInfo);
                await _context.AddAsync(buff);
                await _context.SaveChangesAsync();
                await _context.AddAsync(new PlayerBuff()
                {
                    BuffId = buff.Id,
                    UserId = user.Id,
                    StartDate = DateTimeOffset.Now,
                    EndDate = DateTimeOffset.Now + new TimeSpan(0, playerItem.Item.Value1 ?? 0, 0)
                });

                playerItem.Count -= req.Data.Count;

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
        public async Task<TDResponse<List<long>>> GetCityShields(BaseRequest<List<long>> req)
        {
            TDResponse<List<long>> response = new TDResponse<List<long>>();
            var info = InfoDetail.CreateInfo(req, "UseItem");
            try
            {
                if (req.Data==null)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var arr = req.Data.ToArray();
                var now = DateTimeOffset.UtcNow;
                response.Data = await _context.PlayerBuff
                    .Where(l => l.EndDate > now && l.Buff.CityShieldActive && arr.Contains(l.UserId))
                    .Select(l => l.UserId).ToListAsync();

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

        #endregion


        #region BARRACKS UTILS

        public async Task<TDResponse<CollectTroopResponse>> CollectTroopsFromBarracks(BaseRequest req, UserDto user)
        {
            TDResponse<CollectTroopResponse> response = new TDResponse<CollectTroopResponse>();
            var info = InfoDetail.CreateInfo(req, "CollectTroopsFromBarracks");
            try
            {
                var cou =await _context.PlayerTroop.Where(l => l.UserId == user.Id && l.TroopCount == 0).CountAsync();
                if (cou>1)
                {
                    _context.Remove(await _context.PlayerTroop.Where(l => l.UserId == user.Id).OrderByDescending(l=>l.LastTroopCollect).FirstOrDefaultAsync());
                    await _context.SaveChangesAsync();
                }
                var playerTroops = await _context.PlayerTroop.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();

                if ((DateTimeOffset.Now - playerTroops.LastTroopCollect).TotalMilliseconds < (new TimeSpan(0, 1, 0)).TotalMilliseconds)
                {
                    response.SetError(OperationMessages.NoChanges);
                    info.AddInfo(OperationMessages.NoChanges);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var duration = DateTimeOffset.Now - playerTroops.LastTroopCollect;
                duration = playerTroops.MaxDuration < duration ? playerTroops.MaxDuration : duration;


                response.Data = new CollectTroopResponse()
                {
                    CollectDuration = duration,
                    CollectedTroops = (int)(duration.TotalHours * playerTroops.TrainingPerHour),
                    TroopTrainingPerHour = playerTroops.TrainingPerHour,
                    BarrackFullDuration = playerTroops.MaxDuration
                };
                response.Data.CollectedTroops += (int)(response.Data.CollectedTroops * (await BuffHelper.GetPlayersTotalBuff(user.Id)).TroopTrainingMultiplier);
                playerTroops.LastTroopCollect = DateTimeOffset.Now;
                playerTroops.TroopCount += response.Data.CollectedTroops;

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
        #endregion


        #region GANG UTILS

        public async Task<TDResponse> SpendGangCreateMoney(BaseRequest req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "SpendGangCreateMoney");
            try
            {
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                if (playerBaseInfo == null || playerBaseInfo.Gems < 500) //TODO: GEM SAYISI CONFIGDEN ALINACAK
                {
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                playerBaseInfo.Gems -= 500;
                _context.Update(playerBaseInfo);
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

        #endregion


        #region TUTORIAL QUEST UTILS
        public async Task<TDResponse<List<PlayerTutorialQuestDTO>>> GetPlayerTutorialQuests(BaseRequest req, UserDto user)//Todo: algoritma daha verimli olabilir
        {
            TDResponse<List<PlayerTutorialQuestDTO>> response = new TDResponse<List<PlayerTutorialQuestDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetPlayerTutorialQuests");
            try
            {
                var currentStageId = 1;
                var playerTutorialQuest = await _context.PlayerTutorialQuest
                    .Include(l => l.TutorialQuest)
                    .Where(l => l.UserId == user.Id && l.IsClaim)
                    .OrderByDescending(l => l.TutorialQuest.StageId).FirstOrDefaultAsync();

                if (playerTutorialQuest != null)
                {
                    currentStageId = playerTutorialQuest.TutorialQuest.StageId;
                    var isCurruntStage =
                        (await _context.PlayerTutorialQuest.Where(l => l.UserId == user.Id && l.IsClaim).CountAsync())
                        <
                        (await _context.TutorialQuest.Where(l => l.StageId == currentStageId && l.IsActive == true).CountAsync());
                    currentStageId += isCurruntStage ? 0 : 1;
                }

                var playerQuest = await _context.PlayerTutorialQuest
                    .Include(l => l.TutorialQuest)
                    .Where(l => l.UserId == user.Id && l.TutorialQuest.IsActive == true && l.TutorialQuest.StageId == currentStageId).ToListAsync();

                var allQuest = await _context.TutorialQuest.Where(l => l.StageId == currentStageId && l.IsActive).ToListAsync();
                var resList = new List<PlayerTutorialQuestDTO>();
                foreach (var tq in allQuest)
                {
                    var ptq = playerQuest.FirstOrDefault(l => l.TutorialQuestId == tq.Id);
                    resList.Add(new PlayerTutorialQuestDTO()
                    {
                        TutorialQuestId = tq.Id,
                        StageId = tq.StageId,
                        StageOrderId = tq.StageOrderId,
                        IsClaim = ptq?.IsClaim ?? false,
                        IsDone = ptq?.IsDone ?? false
                    });
                }
                response.Data = resList;
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
        
        public async Task<TDResponse<int?>> GetFirstTimeTutorial(BaseRequest<string> req, UserDto user)
        {
            TDResponse<int?> response = new TDResponse<int?>();
            var info = InfoDetail.CreateInfo(req, "GetFirstTimeTutorial");
            try
            {
                var bt = await _context.FirstTimeTutorial
                    .Where(l => l.UserId == user.Id && l.Action == req.Data)
                    .FirstOrDefaultAsync();
                response.Data = bt?.State;
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
        
        public async Task<TDResponse> FirstTimeTutorialDone(BaseRequest<string> req, UserDto user)
        {
            TDResponse<int?> response = new TDResponse<int?>();
            var info = InfoDetail.CreateInfo(req, "FirstTimeTutorialDone");
            try
            {
                if (req.Data==null)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var bt = await _context.FirstTimeTutorial
                    .Where(l => l.UserId == user.Id && l.Action == req.Data)
                    .FirstOrDefaultAsync();
                
                if (bt==null)
                {
                    await _context.AddAsync(
                        new FirstTimeTutorial()
                        {
                            UserId = user.Id,
                            Action = req.Data,
                            State = 0
                        }
                        );
                }
                else
                {
                    bt.State++;
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
        
        #endregion

        #region TD REWARD UTILS

        public async Task<TDResponse<List<PlayerItemDTO>>> GetTDWaveRewardsByWaveId(BaseRequest<int> req, UserDto user)
        {
            TDResponse<List<PlayerItemDTO>> response = new TDResponse<List<PlayerItemDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetTDWaveRewardsByWaveId");
            try
            {
                if (await _context.PlayerTDRewardHistory.Where(l => l.UserId == user.Id && l.WaveId == req.Data).AnyAsync())
                {
                    response.SetError(OperationMessages.WaveRewardAllreadyReceived);
                    info.AddInfo(OperationMessages.WaveRewardAllreadyReceived);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var waveItemListQuery = _context.PlayerTDReward.Where(l => l.WaveId == req.Data);
                response.Data = await _mapper.ProjectTo<PlayerItemDTO>(waveItemListQuery).ToListAsync();
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

        public async Task<TDResponse> GetTDWaveRewardsDoneByWaveId(BaseRequest<int> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "GetTDWaveRewardsDoneByWaveId");
            try
            {
                var waveRewardList = await _context.PlayerTDReward.Where(l => l.WaveId == req.Data).ToListAsync();
                if (waveRewardList.Count==0)
                {
                    response.SetError(OperationMessages.NoReward);
                    info.AddInfo(OperationMessages.NoReward);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (await _context.PlayerTDRewardHistory.Where(l => l.UserId == user.Id && l.WaveId == req.Data).AnyAsync())
                {
                    response.SetError(OperationMessages.WaveRewardAllreadyReceived);
                    info.AddInfo(OperationMessages.WaveRewardAllreadyReceived);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                foreach (var tdReward in waveRewardList)
                {
                    var inventoryItem = await _context.PlayerItem.Where(l => l.UserId == user.Id && l.ItemId == tdReward.ItemId).FirstOrDefaultAsync();
                    if (inventoryItem == null)
                    {
                        await _context.AddAsync(new PlayerItem()
                        {
                            ItemId = tdReward.ItemId,
                            Count = tdReward.Count,
                            UserId = user.Id
                        });
                        continue;
                    }
                    inventoryItem.Count += tdReward.Count;

                }
                await _context.SaveChangesAsync();
                await _context.AddRangeAsync(waveRewardList.Select(l => new PlayerTDRewardHistory()
                {
                    UserId = user.Id,
                    WaveId = l.WaveId,
                    Date = DateTimeOffset.UtcNow
                }).ToList());
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

        #endregion

        #region LEADERBOARD UTILS
        
        public async Task<TDResponse<Paging<LeaderBoardItem>>> GetBaseLevelLeaderBoard(BaseRequest<int> req, UserDto user)
        {
            TDResponse<Paging<LeaderBoardItem>> response = new TDResponse<Paging<LeaderBoardItem>>();
            var info = InfoDetail.CreateInfo(req, "GetBaseLevelLeaderBoard");
            try
            {
                response.Data = new Paging<LeaderBoardItem>();
                response.Data.PageIndex = req.Data;
                
                response.Data.PagingData = await _context.PlayerBaseInfo
                    .OrderByDescending(l => l.BaseLevel).ThenBy(l => l.UserId)
                    .Skip(req.Data*10)
                    .Take(10)
                    .Select(l=>new LeaderBoardItem()
                    {
                        Username = l.Username,
                        Value = l.BaseLevel,
                        UserId = l.UserId
                    }).ToListAsync();

                var ownValue =
                    await _context.PlayerBaseInfo
                        .Where(l => l.UserId == user.Id)
                        .Select(l => new LeaderBoardItem()
                        {
                            Username = l.Username,
                            Value = l.BaseLevel,
                            UserId = l.UserId
                        }).FirstOrDefaultAsync()
                    ?? new LeaderBoardItem()
                    {
                        Username = user.Username,
                        UserId = user.Id,
                        Value = 0
                    };
                ownValue.OwnRanked = (await _context.PlayerBaseInfo.Where(l => l.BaseLevel > ownValue.Value || (l.BaseLevel == ownValue.Value && l.UserId < user.Id) )
                    .OrderByDescending(l => l.BaseLevel).ThenBy(l => l.Id).CountAsync()) + 1;
                
                response.Data.PagingData.Add(ownValue);
                
                
                
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
                
        public async Task<TDResponse<LeaderBoardItem>> GetBaseLevelRankedByUserId(BaseRequest<long> req)
        {
            TDResponse<LeaderBoardItem> response = new TDResponse<LeaderBoardItem>();
            var info = InfoDetail.CreateInfo(req, "GetBaseLevelRankedByUserId");
            try
            {

                var ownValue =
                    await _context.PlayerBaseInfo
                        .Where(l => l.UserId == req.Data)
                        .Select(l => new LeaderBoardItem()
                        {
                            Username = l.Username,
                            Value = l.BaseLevel,
                            UserId = l.UserId,
                        }).FirstOrDefaultAsync();
                ownValue.OwnRanked = (await _context.PlayerBaseInfo.Where(l => l.BaseLevel > ownValue.Value || (l.BaseLevel == ownValue.Value && l.UserId < req.Data) )
                    .OrderByDescending(l => l.BaseLevel).ThenBy(l => l.Id).CountAsync()) + 1;

                response.Data = ownValue;

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
        
        public async Task<TDResponse<Paging<LeaderBoardItem>>> GetKillTroopLeaderBoard(BaseRequest<int> req, UserDto user)
        {
            TDResponse<Paging<LeaderBoardItem>> response = new TDResponse<Paging<LeaderBoardItem>>();
            var info = InfoDetail.CreateInfo(req, "GetKillTroopLeaderBoard");
            try
            {
                response.Data = new Paging<LeaderBoardItem>();
                response.Data.PageIndex = req.Data;
                
                response.Data.PagingData = await _context.PlayerBaseInfo
                    .OrderByDescending(l => l.KillCount).ThenBy(l => l.UserId)
                    .Skip(req.Data*10)
                    .Take(10)
                    .Select(l=>new LeaderBoardItem()
                    {
                        Username = l.Username,
                        Value = l.KillCount,
                        UserId = l.UserId
                    }).ToListAsync();

                var ownValue =
                    await _context.PlayerBaseInfo
                        .Where(l => l.UserId == user.Id)
                        .Select(l => new LeaderBoardItem()
                        {
                            Username = l.Username,
                            Value = l.KillCount,
                            UserId = l.UserId
                        }).FirstOrDefaultAsync()
                    ?? new LeaderBoardItem()
                    {
                        Username = user.Username,
                        UserId = user.Id,
                        Value = 0
                    };
                ownValue.OwnRanked = (await _context.PlayerBaseInfo.Where(l => l.KillCount > ownValue.Value || (l.KillCount == ownValue.Value && l.UserId < user.Id) )
                    .OrderByDescending(l => l.KillCount).ThenBy(l => l.Id).CountAsync()) + 1;
                
                response.Data.PagingData.Add(ownValue);
                
                
                
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
                
        public async Task<TDResponse<LeaderBoardItem>> GetKillTroopRankedByUserId(BaseRequest<long> req)
        {
            TDResponse<LeaderBoardItem> response = new TDResponse<LeaderBoardItem>();
            var info = InfoDetail.CreateInfo(req, "GetKillTroopRankedByUserId");
            try
            {

                var ownValue =
                    await _context.PlayerBaseInfo
                        .Where(l => l.UserId == req.Data)
                        .Select(l => new LeaderBoardItem()
                        {
                            Username = l.Username,
                            Value = l.KillCount,
                            UserId = l.UserId
                        }).FirstOrDefaultAsync();
                ownValue.OwnRanked = (await _context.PlayerBaseInfo.Where(l => l.KillCount > ownValue.Value || (l.KillCount == ownValue.Value && l.UserId < req.Data) )
                    .OrderByDescending(l => l.KillCount).ThenBy(l => l.Id).CountAsync()) + 1;

                response.Data = ownValue;
                
                
                
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
                
        public async Task<TDResponse<Paging<LeaderBoardItem>>> GetLootedScrapLeaderBoard(BaseRequest<int> req, UserDto user)
        {
            TDResponse<Paging<LeaderBoardItem>> response = new TDResponse<Paging<LeaderBoardItem>>();
            var info = InfoDetail.CreateInfo(req, "GetLootedScrapLeaderBoard");
            try
            {
                response.Data = new Paging<LeaderBoardItem>();
                response.Data.PageIndex = req.Data;
                
                response.Data.PagingData = await _context.PlayerBaseInfo
                    .OrderByDescending(l => l.LootedScrap).ThenBy(l => l.UserId)
                    .Skip(req.Data*10)
                    .Take(10)
                    .Select(l=>new LeaderBoardItem()
                    {
                        Username = l.Username,
                        Value = l.LootedScrap,
                        UserId = l.UserId
                    }).ToListAsync();

                var ownValue =
                    await _context.PlayerBaseInfo
                        .Where(l => l.UserId == user.Id)
                        .Select(l => new LeaderBoardItem()
                        {
                            Username = l.Username,
                            Value = l.LootedScrap,
                            UserId = l.UserId
                        }).FirstOrDefaultAsync()
                    ?? new LeaderBoardItem()
                    {
                        Username = user.Username,
                        UserId = user.Id,
                        Value = 0
                    };
                ownValue.OwnRanked = (await _context.PlayerBaseInfo.Where(l => l.LootedScrap > ownValue.Value || (l.LootedScrap == ownValue.Value && l.UserId < user.Id) )
                    .OrderByDescending(l => l.LootedScrap).ThenBy(l => l.Id).CountAsync()) + 1;
                
                response.Data.PagingData.Add(ownValue);
                
                
                
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
        
        public async Task<TDResponse<LeaderBoardItem>> GetLootedScrapRankedByUserId(BaseRequest<long> req)
        {
            TDResponse<LeaderBoardItem> response = new TDResponse<LeaderBoardItem>();
            var info = InfoDetail.CreateInfo(req, "GetLootedScrapRankedByUserId");
            try
            {
                var ownValue =
                    await _context.PlayerBaseInfo
                        .Where(l => l.UserId == req.Data)
                        .Select(l => new LeaderBoardItem()
                        {
                            Username = l.Username,
                            Value = l.LootedScrap,
                            UserId = l.UserId
                        }).FirstOrDefaultAsync();
                ownValue.OwnRanked = (await _context.PlayerBaseInfo.Where(l => l.LootedScrap > ownValue.Value || (l.LootedScrap == ownValue.Value && l.UserId < req.Data) )
                    .OrderByDescending(l => l.LootedScrap).ThenBy(l => l.Id).CountAsync()) + 1;
                
                response.Data=ownValue;
                
                
                
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
        public async Task<TDResponse<Paging<LeaderBoardItem>>> GetDefenseKillLeaderBoard(BaseRequest<int> req, UserDto user)
        {
            TDResponse<Paging<LeaderBoardItem>> response = new TDResponse<Paging<LeaderBoardItem>>();
            var info = InfoDetail.CreateInfo(req, "GetDefenseKillLeaderBoard");
            try
            {
                response.Data = new Paging<LeaderBoardItem>();
                response.Data.PageIndex = req.Data;
                
                response.Data.PagingData = await _context.PlayerBaseInfo
                    .OrderByDescending(l => l.DefenseKillCount).ThenBy(l => l.UserId)
                    .Skip(req.Data*10)
                    .Take(10)
                    .Select(l=>new LeaderBoardItem()
                    {
                        Username = l.Username,
                        Value = l.DefenseKillCount,
                        UserId = l.UserId
                    }).ToListAsync();

                var ownValue =
                    await _context.PlayerBaseInfo
                        .Where(l => l.UserId == user.Id)
                        .Select(l => new LeaderBoardItem()
                        {
                            Username = l.Username,
                            Value = l.DefenseKillCount,
                            UserId = l.UserId
                        }).FirstOrDefaultAsync()
                    ?? new LeaderBoardItem()
                    {
                        Username = user.Username,
                        UserId = user.Id,
                        Value = 0
                    };
                ownValue.OwnRanked = (await _context.PlayerBaseInfo.Where(l => l.DefenseKillCount > ownValue.Value || (l.DefenseKillCount == ownValue.Value && l.UserId < user.Id) )
                    .OrderByDescending(l => l.DefenseKillCount).ThenBy(l => l.Id).CountAsync()) + 1;
                
                response.Data.PagingData.Add(ownValue);
                
                
                
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
        
        
        public async Task<TDResponse<LeaderBoardItem>> GetDefenseKillRankedByUserId(BaseRequest<long> req)
        {
            TDResponse<LeaderBoardItem> response = new TDResponse<LeaderBoardItem>();
            var info = InfoDetail.CreateInfo(req, "GetDefenseKillRankedByUserId");
            try
            {
                var ownValue =
                    await _context.PlayerBaseInfo
                        .Where(l => l.UserId == req.Data)
                        .Select(l => new LeaderBoardItem()
                        {
                            Username = l.Username,
                            Value = l.DefenseKillCount,
                            UserId = l.UserId
                        }).FirstOrDefaultAsync();
                ownValue.OwnRanked = (await _context.PlayerBaseInfo.Where(l => l.DefenseKillCount > ownValue.Value || (l.DefenseKillCount == ownValue.Value && l.UserId < req.Data) )
                    .OrderByDescending(l => l.DefenseKillCount).ThenBy(l => l.Id).CountAsync()) + 1;
                
                response.Data = ownValue;

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
        
        #endregion


        public async Task<TDResponse> ChangeAvatar(BaseRequest<int> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "ChangeAvatar");
            try
            {
                var _playerbase =await _context.GetPlayerBaseInfoByUser(user);
                var playerBaseInfo = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (playerBaseInfo == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                playerBaseInfo.AvatarId = req.Data;
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
        public async Task<TDResponse> ChangeBio(BaseRequest<string> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "ChangeBio");
            try
            {
                var _playerbase =await _context.GetPlayerBaseInfoByUser(user);
                var playerBaseInfo = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (playerBaseInfo == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                playerBaseInfo.Bio = req.Data;
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
        public async Task<TDResponse<PlayerTroopInfoDTO>> GetPlayerTroopInfo(BaseRequest req, UserDto user)
        {
            TDResponse<PlayerTroopInfoDTO> response = new TDResponse<PlayerTroopInfoDTO>();
            var info = InfoDetail.CreateInfo(req, "GetPlayerTroopInfo");
            try
            {
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                var cou =await _context.PlayerTroop.Where(l => l.UserId == user.Id && l.TroopCount == 0).CountAsync();
                if (cou>1)
                {
                    _context.Remove(await _context.PlayerTroop.Where(l => l.UserId == user.Id).OrderByDescending(l=>l.LastTroopCollect).FirstOrDefaultAsync());
                    await _context.SaveChangesAsync();
                }
                
                var playerTroops = await _context.PlayerTroop.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (playerTroops == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                response.Data = _mapper.Map<PlayerTroopInfoDTO>(playerTroops);
                // var attacks = await _context.Attack.Where(l => l.IsActive && l.AttackerUserId == user.Id).ToListAsync();
                // attacks.ForEach(l=>
                //         response.Data.OutSideTroops.Add(new TroopUnitDTO()
                //         {
                //             TroopCount = l.AttackerTroopCount,
                //             IsAttack = true,
                //             HeroId = l.AttackerHeroId,
                //             Coord = GetUserCoordinate(l.TargetUserId).Result.Data,
                //             HeroName = _context.Hero.Where(k=>k.Id==l.AttackerHeroId).Select(k=>k.Name).FirstOrDefault(),
                //             TUserId = l.TargetUserId,
                //             TUserName = _context.PlayerBaseInfo.Where(k=>k.Id==l.TargetUserId).Select(k=>k.Username).FirstOrDefault(),
                //             TUserAvatarId = _context.PlayerBaseInfo.Where(k=>k.Id==l.TargetUserId).Select(k=>k.AvatarId).FirstOrDefault()??0,
                //             ArrivedDate = l.ArriveDate.ToString(),
                //             ComebackDate = l.ComeBackDate.ToString(),
                //             Id = l.Id
                //         })
                // );
                // var supports = await _context.SupportUnit
                //     .Include(l=>l.Hero)
                //     .Where(l => l.IsActive && l.ClientUserId == user.Id)
                //     .ToListAsync();
                // supports.ForEach(l=>
                //     response.Data.OutSideTroops.Add(new TroopUnitDTO()
                //     {
                //         TroopCount = l.TroopCount,
                //         IsAttack = true,
                //         HeroId = l.HeroId,
                //         Coord = GetUserCoordinate(l.HostUserId).Result.Data,
                //         HeroName = _context.Hero.Where(k=>k.Id==l.Hero.Id).Select(k=>k.Name).FirstOrDefault(),
                //         TUserId = l.HostUserId,
                //         TUserName = _context.PlayerBaseInfo.Where(k=>k.Id==l.HostUserId).Select(k=>k.Username).FirstOrDefault(),
                //         TUserAvatarId = _context.PlayerBaseInfo.Where(k=>k.Id==l.HostUserId).Select(k=>k.AvatarId).FirstOrDefault()??0,
                //         ArrivedDate = l.ArrivedDate?.ToString(),
                //         ComebackDate = l.ComeBackDate?.ToString(),
                //         Id = l.Id
                //     })
                // );
                // var inSupports = await _context.SupportUnit
                //     .Include(l=>l.Hero)
                //     .Where(l => l.IsActive && l.HostUserId == user.Id)
                //     .ToListAsync();
                // inSupports.ForEach(l=>
                //     response.Data.InsideTroops.Add(new TroopUnitDTO()
                //     {
                //         TroopCount = l.TroopCount,
                //         IsAttack = true,
                //         HeroId = l.HeroId,
                //         Coord = GetUserCoordinate(l.ClientUserId).Result.Data,
                //         HeroName = _context.Hero.Where(k=>k.Id==l.Hero.Id).Select(k=>k.Name).FirstOrDefault(),
                //         TUserId = l.ClientUserId,
                //         TUserName = _context.PlayerBaseInfo.Where(k=>k.Id==l.ClientUserId).Select(k=>k.Username).FirstOrDefault(),
                //         TUserAvatarId = _context.PlayerBaseInfo.Where(k=>k.Id==l.ClientUserId).Select(k=>k.AvatarId).FirstOrDefault()??0,
                //         ArrivedDate = l.ArrivedDate?.ToString(),
                //         ComebackDate = l.ComeBackDate?.ToString(),
                //         Id = l.Id
                //     })
                // );
                playerBaseInfo.Power = response.Data.TroopCount * 42;
                _context.Update(playerBaseInfo);
                await _context.SaveChangesAsync();
                response.Data.OutsideTroops = await _context.Attack
                    .Where(l => l.AttackerUserId == user.Id && l.IsActive).SumAsync(l => l.AttackerTroopCount);
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
        public async Task<TDResponse<PlayerTroopInfoDTOv2>> GetPlayerTroopInfoV2(BaseRequest req, UserDto user)
        {
            TDResponse<PlayerTroopInfoDTOv2> response = new TDResponse<PlayerTroopInfoDTOv2>();
            var info = InfoDetail.CreateInfo(req, "GetPlayerTroopInfoV2");
            try
            {
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                var cou =await _context.PlayerTroop.Where(l => l.UserId == user.Id && l.TroopCount == 0).CountAsync();
                if (cou>1)
                {
                    _context.Remove(await _context.PlayerTroop.Where(l => l.UserId == user.Id).OrderByDescending(l=>l.LastTroopCollect).FirstOrDefaultAsync());
                    await _context.SaveChangesAsync();
                }
                
                var playerTroops = await _context.PlayerTroop.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (playerTroops == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                response.Data = _mapper.Map<PlayerTroopInfoDTOv2>(playerTroops);
                response.Data.InsideTroops = new List<TroopUnitDTO>();
                response.Data.InsideTroops.Add(new TroopUnitDTO()
                {
                    TroopCount = response.Data.TroopCount,
                    Id = null,
                    HeroId = null,
                    Coord = null,
                    ArrivedDate = null,
                    ComebackDate = null,
                    HeroName = null,
                    TUserId = null,
                    TUserName = null,
                    TroopType = null,
                    TUserAvatarId = 0
                });
                var attacks = await _context.Attack.Where(l => l.IsActive && l.AttackerUserId == user.Id).ToListAsync();
                attacks.ForEach(l=>
                        response.Data.OutSideTroops.Add(new TroopUnitDTO()
                        {
                            TroopCount = l.AttackerTroopCount,
                            TroopType = (int)TroopTypeEnum.Attack,
                            HeroId = l.AttackerHeroId,
                            Coord = GetUserCoordinate(l.TargetUserId).Result.Data,
                            HeroName = _context.Hero.Where(k=>k.Id==l.AttackerHeroId).Select(k=>k.Name).FirstOrDefault(),
                            TUserId = l.TargetUserId,
                            TUserName = _context.PlayerBaseInfo.Where(k=>k.Id==l.TargetUserId).Select(k=>k.Username).FirstOrDefault(),
                            TUserAvatarId = _context.PlayerBaseInfo.Where(k=>k.Id==l.TargetUserId).Select(k=>k.AvatarId).FirstOrDefault()??0,
                            ArrivedDate = l.ArriveDate.ToString(),
                            ComebackDate = l.ComeBackDate.ToString(),
                            Id = l.Id
                        })
                );                
                var rallies = await _context.RallyPart.Include(l=>l.Rally).Where(l => l.IsActive && l.UserId == user.Id).ToListAsync();
                rallies.ForEach(l=>
                        response.Data.OutSideTroops.Add(new TroopUnitDTO()
                        {
                            TroopCount = l.TroopCount,
                            TroopType = (int)TroopTypeEnum.Rally,
                            HeroId = l.HeroId,
                            Coord = GetUserCoordinate(l.Rally.TargetUserId).Result.Data,
                            HeroName = _context.Hero.Where(k=>k.Id==l.HeroId).Select(k=>k.Name).FirstOrDefault(),
                            TUserId = l.Rally.TargetUserId,
                            TUserName = _context.PlayerBaseInfo.Where(k=>k.Id==l.Rally.TargetUserId).Select(k=>k.Username).FirstOrDefault(),
                            TUserAvatarId = _context.PlayerBaseInfo.Where(k=>k.Id==l.Rally.TargetUserId).Select(k=>k.AvatarId).FirstOrDefault()??0,
                            ArrivedDate = l.ArriveDate.ToString(),
                            ComebackDate = l.ComeBackDate.ToString(),
                            Id = l.Id
                        })
                );
                var supports = await _context.SupportUnit
                    .Include(l=>l.Hero)
                    .Where(l => l.IsActive && l.ClientUserId == user.Id)
                    .ToListAsync();
                supports.ForEach(l=>
                    response.Data.OutSideTroops.Add(new TroopUnitDTO()
                    {
                        TroopCount = l.TroopCount,
                        TroopType = (int)TroopTypeEnum.Support,
                        HeroId = l.HeroId,
                        Coord = GetUserCoordinate(l.HostUserId).Result.Data,
                        HeroName = _context.Hero.Where(k=>k.Id==l.Hero.Id).Select(k=>k.Name).FirstOrDefault(),
                        TUserId = l.HostUserId,
                        TUserName = _context.PlayerBaseInfo.Where(k=>k.Id==l.HostUserId).Select(k=>k.Username).FirstOrDefault(),
                        TUserAvatarId = _context.PlayerBaseInfo.Where(k=>k.Id==l.HostUserId).Select(k=>k.AvatarId).FirstOrDefault()??0,
                        ArrivedDate = l.ArrivedDate?.ToString(),
                        ComebackDate = l.ComeBackDate?.ToString(),
                        Id = l.Id
                    })
                );
                var inSupports = await _context.SupportUnit
                    .Include(l=>l.Hero)
                    .Where(l => l.IsActive && l.HostUserId == user.Id)
                    .ToListAsync();
                inSupports.ForEach(l=>
                    response.Data.InsideTroops.Add(new TroopUnitDTO()
                    {
                        TroopCount = l.TroopCount,
                        TroopType = (int)TroopTypeEnum.Support,
                        HeroId = l.HeroId,
                        Coord = GetUserCoordinate(l.ClientUserId).Result.Data,
                        HeroName = _context.Hero.Where(k=>k.Id==l.Hero.Id).Select(k=>k.Name).FirstOrDefault(),
                        TUserId = l.ClientUserId,
                        TUserName = _context.PlayerBaseInfo.Where(k=>k.Id==l.ClientUserId).Select(k=>k.Username).FirstOrDefault(),
                        TUserAvatarId = _context.PlayerBaseInfo.Where(k=>k.Id==l.ClientUserId).Select(k=>k.AvatarId).FirstOrDefault()??0,
                        ArrivedDate = l.ArrivedDate?.ToString(),
                        ComebackDate = l.ComeBackDate?.ToString(),
                        Id = l.Id
                    })
                );
                playerBaseInfo.Power = response.Data.InsideTroops.Where(l=>l.TroopType==null).Select(l=>l.TroopCount).FirstOrDefault() * 42;
                _context.Update(playerBaseInfo);
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
        public async Task<TDResponse<List<UsableItemDTO>>> GetPlayersSpeedUpItems(BaseRequest req, UserDto user)
        {
            TDResponse<List<UsableItemDTO>> response = new TDResponse<List<UsableItemDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetPlayersSpeedUpItems");
            try
            {

                var pq = _context.PlayerItem.Include(l => l.Item)
                   .Where(l => l.UserId == user.Id && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp && l.Count > 0).OrderBy(l => l.ItemId);
                var playerItems = await _mapper.ProjectTo<PlayerItemDTO>(pq).ToListAsync();


                var speedUpItems = await _mapper.ProjectTo<UsableItemDTO>(_context.MarketItem
                    .Where(l => l.IsActive && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp)
                    .OrderBy(l => l.MarketOrderId)).ToListAsync();
                foreach (var sui in speedUpItems)
                {
                    sui.Count = playerItems.FirstOrDefault(l => l.Item.Id == sui.Item.Id)?.Count ?? 0;
                }
                response.Data = speedUpItems.GroupBy(l => l.Count == 0).OrderBy(l => l.Key).SelectMany(l => l).ToList();
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

        #region THREAD BASED INTERACTION UTILS
        
        public async Task<TDResponse<ScoutDTO>> ScoutPlayer(BaseRequest<ScoutRequest> req, UserDto user)
        {
            TDResponse<ScoutDTO> response = new TDResponse<ScoutDTO>();
            var info = InfoDetail.CreateInfo(req, "ScoutPlayer");
            try
            {
                //todo: kac tane aktif scoutu var kontrol edilecek
                if (req.Data == null)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (!(await _context.PlayerBaseInfo.Where(l=>l.UserId==req.Data.TargetUserId).AnyAsync()))
                {
                    info.AddInfo(OperationMessages.InputError+"nasi");
                    response.SetError(OperationMessages.InputError+"nasi");
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var ent = new Scout()
                {
                    TargetUserId = req.Data.TargetUserId,
                    TargetUsername = await _context.PlayerBaseInfo.Where(l=>l.UserId==req.Data.TargetUserId).Select(l=>l.Username).FirstOrDefaultAsync(),
                    ArrivedDate = DateTimeOffset.UtcNow + TimeSpan.FromMinutes(2),
                    ComeBackDate = DateTimeOffset.UtcNow + TimeSpan.FromMinutes(4),
                    SenderUserId = user.Id,
                    SenderUsername = user.Username

                };

                await _context.AddAsync(ent);
                await _context.SaveChangesAsync();
                
                ScoutHelper.AddScoutList(ent);
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
        public async Task<TDResponse> ScoutPlayerV2(BaseRequest<ScoutRequestV2> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "ScoutPlayerV2");
            try
            {
                //todo: kac tane aktif scoutu var kontrol edilecek
                if (req.Data == null)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (!(await _context.PlayerBaseInfo.Where(l=>l.UserId==req.Data.TargetUserId).AnyAsync()))
                {
                    info.AddInfo(OperationMessages.InputError+"nasi");
                    response.SetError(OperationMessages.InputError+"nasi");
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var playerScout = await _context.PlayerScout.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (playerScout==null)
                {
                    
                    playerScout = new PlayerScout()
                    {
                        TrainingDoneDate = null,
                        UserId = user.Id,
                        ScoutLevelId = await _context.PlayerBasePlacement
                            .Where(l=>l.UserId==user.Id && l.BuildingTypeId==8)
                            .Select(l=>l.BuildingLevel).FirstOrDefaultAsync(),
                        SpyCount = 0,
                        InTrainingCount = 0
                    };
                    await _context.AddAsync(playerScout);
                    await _context.SaveChangesAsync();
                }
                var ent = new Scout()
                {
                    TargetUserId = req.Data.TargetUserId,
                    TargetUsername = await _context.PlayerBaseInfo.Where(l=>l.UserId==req.Data.TargetUserId).Select(l=>l.Username).FirstOrDefaultAsync(),
                    ArrivedDate = DateTimeOffset.UtcNow + TimeSpan.FromMinutes(2),
                    ComeBackDate = DateTimeOffset.UtcNow + TimeSpan.FromMinutes(4),
                    SenderUserId = user.Id,
                    AttackerSpyCount = req.Data.SpyCount,
                    SenderUsername = user.Username

                };

                await _context.AddAsync(ent);
                await _context.SaveChangesAsync();
                
                ScoutHelperV2.AddScoutList(ent);
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
        public async Task<TDResponse<AttackInfoDTO>> AttackPlayer(BaseRequest<AttackRequest> req, UserDto user)
        {
            TDResponse<AttackInfoDTO> response = new TDResponse<AttackInfoDTO>();
            var info = InfoDetail.CreateInfo(req, "AttackPlayer");
            try
            {
                bool isFake = req.Data.TargetUserId==(long)FakeId.TutorialEnemy;
                //todo: kac tane aktif attack var kontrol edilecek
                if (req.Data == null)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var targetPlayerbaseInfo = await _context.GetPlayerBaseInfoByUserId(req.Data.TargetUserId);
                if (targetPlayerbaseInfo == null && !isFake)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (!isFake)
                {
                    var targetBuffs = await BuffHelper.GetPlayersTotalBuff(req.Data.TargetUserId);

                    if (targetBuffs.CityShieldActive)
                    {
                        info.AddInfo(OperationMessages.TargetHasCityShield);
                        response.SetError(OperationMessages.TargetHasCityShield);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                }


                var heroOnRally = await _context.RallyPart.Where(l =>
                        l.IsActive && l.UserId == user.Id && l.HeroId == req.Data.AttackerHeroId)
                    .AnyAsync();
                var heroOnLoot = await _context.PlayerHeroLoot
                    .Where(l => l.IsActive && l.PlayerHero.HeroId == req.Data.AttackerHeroId 
                                           && l.PlayerHero.UserId == user.Id)
                    .AnyAsync();
                var attackList =await  _context.Attack
                    .Where(l => l.IsActive && l.AttackerUserId == user.Id )
                    .ToListAsync();
                if (attackList.Any(l=>l.AttackerHeroId == req.Data.AttackerHeroId) || heroOnRally || heroOnLoot)
                {
                    info.AddInfo(OperationMessages.PlayerHeroBusy);
                    response.SetError(OperationMessages.PlayerHeroBusy);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var pt = (await _context.PlayerTroop
                    .Where(l => l.UserId == user.Id)
                    .FirstOrDefaultAsync());

                if (!isFake)
                {
                    var playerPrisons = await _context.PlayerPrison
                        .Where(l => l.UserId == user.Id || l.UserId == req.Data.TargetUserId).CountAsync();
                    var playerHospital = await _context.PlayerHospital
                        .Where(l => l.UserId == user.Id || l.UserId == req.Data.TargetUserId).CountAsync();                
                    var playerTroop = await _context.PlayerTroop
                        .Where(l => l.UserId == user.Id || l.UserId == req.Data.TargetUserId).CountAsync();
                    if (playerPrisons!=2 || playerHospital!=2 || playerTroop!=2)
                    {
                        info.AddInfo(OperationMessages.PlayerIsUnderProtection);
                        response.SetError(OperationMessages.PlayerIsUnderProtection);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                
                
                    if (pt==null || pt.TroopCount<req.Data.AttackerTroopCount || req.Data.AttackerTroopCount==0)
                    {
                        info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                        response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                }
                var att = new Attack()
                {
                    TargetUserId = req.Data.TargetUserId,
                    
                    ArriveDate = DateTimeOffset.UtcNow + ( isFake? TimeSpan.FromSeconds(10) : TimeSpan.FromMinutes(2)),
                    ComeBackDate = DateTimeOffset.UtcNow + ( isFake? TimeSpan.FromSeconds(20) : TimeSpan.FromMinutes(4)),
                    AttackerUserId = user.Id,
                    WinnerSide = null,
                    AttackerHeroId = req.Data.AttackerHeroId,
                    AttackerTroopCount = req.Data.AttackerTroopCount
                };
                
                pt.TroopCount -= att.AttackerTroopCount;
                
                
                await _context.AddAsync(att);
                await _context.SaveChangesAsync();
                
                AttackHelper.NewAttack(att);

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }
        public async Task<TDResponse> SendSupportUnit(BaseRequest<SupportUnitRequest> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "SendSupportUnit");
            try
            {
                bool isFake = req.Data.TargetUserId==(long)FakeId.TutorialEnemy;
                if (req.Data == null)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var targetPlayerbaseInfo = await _context.GetPlayerBaseInfoByUserId(req.Data.TargetUserId);
                var senderPlayerbaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                if (targetPlayerbaseInfo == null && !isFake)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }


                var heroOnRally = await _context.RallyPart.Where(l =>
                        l.IsActive && l.UserId == user.Id && l.HeroId == req.Data.SenderHeroId)
                    .AnyAsync();                
                var heroOnSupport = await _context.SupportUnit.Where(l =>
                        l.IsActive && l.ClientUserId == user.Id && l.HeroId == req.Data.SenderHeroId)
                    .AnyAsync();
                var heroOnLoot = await _context.PlayerHeroLoot
                    .Where(l => l.IsActive && l.PlayerHero.HeroId == req.Data.SenderHeroId 
                                           && l.PlayerHero.UserId == user.Id)
                    .AnyAsync();
                var attackList =await  _context.Attack
                    .Where(l => l.IsActive && l.AttackerUserId == user.Id )
                    .ToListAsync();
                if (attackList.Any(l=>l.AttackerHeroId == req.Data.SenderHeroId) || heroOnRally || heroOnLoot || heroOnSupport)
                {
                    info.AddInfo(OperationMessages.PlayerHeroBusy);
                    response.SetError(OperationMessages.PlayerHeroBusy);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var pt = (await _context.PlayerTroop
                    .Where(l => l.UserId == user.Id)
                    .FirstOrDefaultAsync());
                var playerHero = await _context.PlayerHero.Include(l=>l.Hero)
                    .Where(l => l.UserId == user.Id && l.HeroId == req.Data.SenderHeroId).FirstOrDefaultAsync();
                if (playerHero==null)
                {
                    info.AddInfo(OperationMessages.PlayerHaveNoHero);
                    response.SetError(OperationMessages.PlayerHaveNoHero);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (!isFake)
                {
                    var playerPrisons = await _context.PlayerPrison
                        .Where(l => l.UserId == user.Id || l.UserId == req.Data.TargetUserId).CountAsync();
                    var playerHospital = await _context.PlayerHospital
                        .Where(l => l.UserId == user.Id || l.UserId == req.Data.TargetUserId).CountAsync();                
                    var playerTroop = await _context.PlayerTroop
                        .Where(l => l.UserId == user.Id || l.UserId == req.Data.TargetUserId).CountAsync();
                    if (playerPrisons!=2 || playerHospital!=2 || playerTroop!=2)
                    {
                        info.AddInfo(OperationMessages.PlayerIsUnderProtection);
                        response.SetError(OperationMessages.PlayerIsUnderProtection);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                
                
                    if (pt==null || pt.TroopCount<req.Data.SenderTroopCount || req.Data.SenderTroopCount==0)
                    {
                        info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                        response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                }

                var now = DateTimeOffset.UtcNow;
                var spu = new SupportUnit()
                {
                    HostUserId = req.Data.TargetUserId,
                    SendedDate = now,
                    ArrivedDate = now + ( isFake? TimeSpan.FromSeconds(10) : TimeSpan.FromMinutes(2)),
                    ComeBackDate = now + ( isFake? TimeSpan.FromSeconds(20) : TimeSpan.FromMinutes(4)),
                    ClientUserId = user.Id,
                    State = (int)SupportUnitState.Pending,
                    HeroId = req.Data.SenderHeroId,
                    TroopCount = req.Data.SenderTroopCount,
                    IsActive = true,
                    ClientAvatarId = senderPlayerbaseInfo.AvatarId??0,
                    ClientUsername = senderPlayerbaseInfo.Username,
                    HostUsername = targetPlayerbaseInfo.Username,
                    HeroName = playerHero.Hero.Name,
                    HostAvatarId = targetPlayerbaseInfo.AvatarId??0,
                    Wounded = 0,
                    Dead = 0
                };
                
                pt.TroopCount -= spu.TroopCount;
                
                
                await _context.AddAsync(spu);
                await _context.SaveChangesAsync();
                
                SupportUnitHelper.NewSupport(spu);
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
        public async Task<TDResponse> GetSupportUnitBackById(BaseRequest<long> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "GetSupportUnitBackById");
            try
            {
                if (req.Data == null)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var spu = await _context.SupportUnit.Where(l => l.Id == req.Data).FirstOrDefaultAsync();

                if (spu==null || spu.State == (int)SupportUnitState.Returning)
                {
                    info.AddInfo(OperationMessages.ProcessAllreadyExist);
                    response.SetError(OperationMessages.ProcessAllreadyExist);
                    _logger.LogInformation(info.ToString());
                    return response;
                }                
                
                if (!spu.IsActive)
                {
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    response.SetError(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var now = DateTimeOffset.UtcNow;
                spu.ComeBackDate = spu.State == (int)SupportUnitState.Pending
                    ? now + (now - spu.SendedDate)
                    : now + TimeSpan.FromMinutes(2);
                spu.State = (int)SupportUnitState.Returning;
                await _context.SaveChangesAsync();
                
                
                SupportUnitHelper.ComebackSupport(spu);
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

        public async Task<TDResponse> CreateRally(BaseRequest<CreateRallyRequest> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "CreateRally");
            try
            {
                //todo: kac tane aktif attack var kontrol edilecek
                if (req.Data == null)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var targetPlayerbaseInfo = await _context.GetPlayerBaseInfoByUserId(req.Data.TargetUserId);
                var leaderPlayerbaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                if (targetPlayerbaseInfo == null)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var targetBuffs = await BuffHelper.GetPlayersTotalBuff(req.Data.TargetUserId);

                if (targetBuffs.CityShieldActive)
                {
                    info.AddInfo(OperationMessages.TargetHasCityShield);
                    response.SetError(OperationMessages.TargetHasCityShield);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                

                var rallyList =await  _context.RallyPart
                    .Where(l => l.IsActive && l.UserId == user.Id )
                    .ToListAsync();
                var heroOnAttack = await _context.Attack.Where(l =>
                        l.IsActive && l.AttackerUserId == user.Id && l.AttackerHeroId == req.Data.AttackerHeroId)
                    .AnyAsync();
                var heroOnLoot = await _context.PlayerHeroLoot
                    .Where(l => l.IsActive && l.PlayerHero.HeroId == req.Data.AttackerHeroId 
                                           && l.PlayerHero.UserId == user.Id)
                    .AnyAsync();
                if (rallyList.Any(l=>l.HeroId == req.Data.AttackerHeroId) || heroOnAttack || heroOnLoot)
                {
                    info.AddInfo(OperationMessages.PlayerHeroBusy);
                    response.SetError(OperationMessages.PlayerHeroBusy);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var pt = (await _context.PlayerTroop
                    .Where(l => l.UserId == user.Id)
                    .FirstOrDefaultAsync());

                var playerPrisons = await _context.PlayerPrison
                    .Where(l => l.UserId == user.Id || l.UserId == req.Data.TargetUserId).CountAsync();
                var playerHospital = await _context.PlayerHospital
                    .Where(l => l.UserId == user.Id || l.UserId == req.Data.TargetUserId).CountAsync();                
                var playerTroop = await _context.PlayerTroop
                    .Where(l => l.UserId == user.Id || l.UserId == req.Data.TargetUserId).CountAsync();
                
                
                if (pt==null || pt.TroopCount<req.Data.AttackerTroopCount || req.Data.AttackerTroopCount==0)
                {
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var leaderCoord = (await GetUserCoordinate(user.Id)).Data;
                var targetCoord = (await GetUserCoordinate(req.Data.TargetUserId)).Data;
                var targetGangInfo = (await GetGangInfoForRally(req.Data.TargetUserId)).Data;
                var leaderGangInfo = (await GetGangInfoForRally(user.Id)).Data;
                
                var now = DateTimeOffset.UtcNow;
                var rally = new Rally()
                {
                    TargetUserId = req.Data.TargetUserId,
                    Date= now,
                    RallyStartDate = now + TimeSpan.FromMinutes(req.Data.RallyStartAfterMinute),
                    LeaderUsername = user.Username,
                    LeaderAvatarId = leaderPlayerbaseInfo?.AvatarId??0,
                    TargetUsername = targetPlayerbaseInfo.Username,
                    WarDate = now + TimeSpan.FromMinutes(req.Data.RallyStartAfterMinute) + TimeSpan.FromMinutes(2),
                    ComeBackDate = now+ TimeSpan.FromMinutes(req.Data.RallyStartAfterMinute) + TimeSpan.FromMinutes(4),
                    LeaderUserId = user.Id,
                    LeaderUserCoord = leaderCoord,
                    TargetUserCoord = targetCoord,
                    LeaderGangId = leaderGangInfo.Id.ToString(),
                    LeaderGangName = $"[{leaderGangInfo.ShortName}]{leaderGangInfo.Name}",
                    LeaderGangAvatarId = leaderGangInfo.AvatarId,
                    TargetGangId = targetGangInfo.Id.ToString(),
                    TargetGangName = $"[{targetGangInfo.ShortName}]{targetGangInfo.Name}",
                    TargetGangAvatarId = targetGangInfo.AvatarId,
                    WinnerSide = null,
                    IsActive = true,
                    TargetAvatarId = targetPlayerbaseInfo.AvatarId??0
                };
                
                await _context.AddAsync(rally);
                await _context.SaveChangesAsync();

                var rallyPart = new RallyPart()
                {
                    RallyId = rally.Id,
                    ArriveDate = now,
                    HeroId = req.Data.AttackerHeroId,
                    IsActive = true,
                    Username=leaderPlayerbaseInfo?.Username??"--",
                    TroopCount = req.Data.AttackerTroopCount,
                    UserId = user.Id,
                    SenderAvatarId = leaderPlayerbaseInfo?.AvatarId??0,
                    ComeBackDate = now+ TimeSpan.FromMinutes(req.Data.RallyStartAfterMinute) + TimeSpan.FromMinutes(4),
                    WallLevel = 0,
                    PrisonerCount = 0,
                    BarracksLevel = 0,
                    DeadTroop = 0,
                    LootedScrap = 0,
                    WoundedTroop = 0,
                    
                };
                rally.ATotalTroop = rallyPart.TroopCount;
                await _context.AddAsync(rallyPart);
                pt.TroopCount -= rallyPart.TroopCount;
                await _context.SaveChangesAsync();
                

                var dbRally = await _context.Rally.Where(l => l.Id == rally.Id).FirstOrDefaultAsync();
                if (dbRally==null)
                {
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    response.SetError(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                RallyHelper.NewRally(dbRally);

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }
                
        public async Task<TDResponse> JoinRally(BaseRequest<JoinRallyRequest> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "JoinRally");
            try
            {
                //todo: kac tane aktif attack var kontrol edilecek
                if (req.Data == null)
                {
                    info.AddInfo(OperationMessages.InputError);
                    response.SetError(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var rallyList =await  _context.RallyPart
                    .Where(l => l.IsActive && l.UserId == user.Id )
                    .ToListAsync();
                var heroOnAttack = await _context.Attack.Where(l =>
                        l.IsActive && l.AttackerUserId == user.Id && l.AttackerHeroId == req.Data.AttackerHeroId)
                    .AnyAsync();
                var heroOnLoot = await _context.PlayerHeroLoot
                    .Where(l => l.IsActive && l.PlayerHero.HeroId == req.Data.AttackerHeroId 
                                           && l.PlayerHero.UserId == user.Id)
                    .AnyAsync();
                if (rallyList.Any(l=>l.HeroId == req.Data.AttackerHeroId) || heroOnAttack || heroOnLoot)
                {
                    info.AddInfo(OperationMessages.PlayerHeroBusy);
                    response.SetError(OperationMessages.PlayerHeroBusy);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var pt = (await _context.PlayerTroop
                    .Where(l => l.UserId == user.Id)
                    .FirstOrDefaultAsync());

                var playerPrisons = await _context.PlayerPrison
                    .Where(l => l.UserId == user.Id ).AnyAsync();
                var playerHospital = await _context.PlayerHospital
                    .Where(l => l.UserId == user.Id ).AnyAsync();                       
                var playerBaseInfo = await _context.PlayerBaseInfo
                    .Where(l => l.UserId == user.Id ).FirstOrDefaultAsync();       
                
                
                if (pt==null || pt.TroopCount<req.Data.AttackerTroopCount || req.Data.AttackerTroopCount==0)
                {
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                
                var rally = await _context.Rally.Where(l => l.Id == req.Data.RallyId).FirstOrDefaultAsync();
                var gangInfo = (await GetGangInfoForRally(user.Id)).Data;
                if (gangInfo==null || gangInfo.Id.ToString() != rally?.LeaderGangId)
                {
                    info.AddInfo(OperationMessages.CantJoinRally);
                    response.SetError(OperationMessages.CantJoinRally);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                var now = DateTimeOffset.UtcNow;
                var arriveDate = now + TimeSpan.FromSeconds(30);
                if (rally==null || !rally.IsActive || rally.RallyStartDate <= arriveDate)
                {
                    info.AddInfo(OperationMessages.CantJoinRally);
                    response.SetError(OperationMessages.CantJoinRally);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var rallyPart = new RallyPart()
                {
                    RallyId = rally.Id,
                    ArriveDate = arriveDate,
                    HeroId = req.Data.AttackerHeroId,
                    IsActive = true,
                    Username=playerBaseInfo?.Username??"--",
                    TroopCount = req.Data.AttackerTroopCount,
                    UserId = user.Id,
                    SenderAvatarId = playerBaseInfo?.AvatarId??0,
                    ComeBackDate = rally.WarDate + TimeSpan.FromMinutes(4)

                };
                await _context.AddAsync(rallyPart);
                
                pt.TroopCount -= rallyPart.TroopCount;
                await _context.SaveChangesAsync();
                var dbRally = await _context.Rally.Where(l => l.Id == rally.Id).FirstOrDefaultAsync();
                if (dbRally==null)
                {
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    response.SetError(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
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
        
                        
        public async Task<TDResponse<List<RallyDTO>>> GetRallyList(BaseRequest req, UserDto user)
        {
            TDResponse<List<RallyDTO>> response = new TDResponse<List<RallyDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetRallyList");
            try
            {
                var gangInfo = (await GetGangInfoForRally(user.Id)).Data;
                if (gangInfo==null )
                {
                    info.AddInfo(OperationMessages.Success);
                    response.SetSuccess();
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var rallyList =await  _context.Rally
                    .Include(l=>l.RallyParts)
                    .Where(l => l.IsActive && l.LeaderGangId==gangInfo.Id.ToString())
                    .ToListAsync();
                response.Data = rallyList.Select(l => RallyHelper.MapRallyDTO(l)).ToList();

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }
        
      
        public async Task<TDResponse<InteractionsDTO>> GetActiveInteractionsForSocket(BaseRequest req, UserDto user)
        {
            TDResponse<InteractionsDTO> response = new TDResponse<InteractionsDTO>();
            response.Data = new InteractionsDTO();
            response.Data.ActiveAttackList = new List<AttackInfoDTO>();
            response.Data.ActiveScoutList = new List<ScoutInfoDTO>();
            var info = InfoDetail.CreateInfo(req, "GetActiveInteractionsForSocket");
            try
            {

                var attackList =await  _context.Attack
                    .Where(l => l.IsActive && l.AttackerUserId == user.Id || l.TargetUserId==user.Id )
                    .ToListAsync();
                
                var scoutList =await  _context.Scout
                    .Where(l => l.IsActive && l.SenderUserId == user.Id || l.TargetUserId==user.Id )
                    .ToListAsync();

                response.Data.ActiveAttackList = attackList.Select(l => new AttackInfoDTO()
                {
                    IsActive = l.IsActive,
                    ComeBackDate = l.ComeBackDate.ToString(),
                    Id = l.Id,
                    ArriveDate = l.ArriveDate.ToString(),
                    ResultData = l.ResultData,
                    WinnerSide = l.WinnerSide,
                    AttackerHeroId = l.AttackerHeroId,
                    AttackerHeroName= _context.Hero.Where(k=>k.Id==l.AttackerHeroId).Select(k=>k.Name).FirstOrDefault()??"",
                    AttackerTroopCount = l.AttackerTroopCount,
                    AttackerUserId = l.AttackerUserId,
                    DefenserUserId = l.TargetUserId,
                    AttackerUsername = _context.PlayerBaseInfo.Where(k=>k.UserId==l.AttackerUserId).Select(k=>k.Username).FirstOrDefault()??"",
                    DefenserUsername = _context.PlayerBaseInfo.Where(k=>k.UserId==l.TargetUserId).Select(k=>k.Username).FirstOrDefault()??"",
                    
                }).ToList();

                response.Data.ActiveScoutList = scoutList.Select(s => new ScoutInfoDTO()
                {
                    ArrivedDate = s.ArrivedDate.ToString(),
                    ScoutedData = s.ScoutedData,
                    IsActive = s.IsActive,
                    ComeBackDate = s.ComeBackDate.ToString(),
                    SenderUserId = s.SenderUserId,
                    TargetUserId = s.TargetUserId,
                    SenderUserName = s.SenderUsername,
                    TargetUserName = s.TargetUsername,
                    Id = s.Id
                }).ToList();
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

        
        

        #endregion

        #region PRIVATE FUNCTIONS


        private async Task<LootRunDoneInfoDTO> GetLootGainedResource(PlayerHero playerHero, DateTimeOffset StartDate, DateTimeOffset EndDate)
        {

            var lootLevelId = await _context.PlayerBasePlacement
                .Where(l => l.UserId == playerHero.UserId && l.BuildingTypeId == 8)//8 watch tower
                .Select(l => l.BuildingLevel).FirstOrDefaultAsync();

            var lootLevel = await _context.LootLevel
                .Where(l => l.Id == lootLevelId).FirstOrDefaultAsync();

            var heroLevelBuff = await _context.HeroLevelThreshold.Include(l => l.Buff)
                .Where(l => l.HeroId == playerHero.HeroId && l.Level == playerHero.CurrentLevel).Select(l => l.Buff).FirstOrDefaultAsync();

            var heroSkillBuffs = await _context.PlayerHeroSkillLevel.Include(l => l.HeroSkillLevel).ThenInclude(l => l.Buff)
                .Where(l => l.UserId == playerHero.UserId && l.HeroSkillLevel.HeroSkill.HeroId == playerHero.HeroId).ToListAsync();

            var totalScrapMultiplier = (heroSkillBuffs?.Sum(l => l.HeroSkillLevel.Buff.LootScrapMultiplier) ?? 0) + heroLevelBuff.LootScrapMultiplier;
            var totalBluePrintMultiplier = (heroSkillBuffs?.Sum(l => l.HeroSkillLevel.Buff.LootBluePrintMultiplier) ?? 0) + heroLevelBuff.LootBluePrintMultiplier;
            var totalGemMultiplier = (heroSkillBuffs?.Sum(l => l.HeroSkillLevel.Buff.LootGemMultiplier) ?? 0) + heroLevelBuff.LootGemMultiplier;
            var totalDurationMultiplier = (heroSkillBuffs?.Sum(l => l.HeroSkillLevel.Buff.LootDurationMultiplier) ?? 0) + heroLevelBuff.LootDurationMultiplier;

            var calculated = new LootRunDoneInfoDTO()
            {
                ScrapCount = LootRandomer.GetRandomScrap((int)(lootLevel.MinScrapCount * totalScrapMultiplier), (int)(lootLevel.MaxScrapCount * totalScrapMultiplier)),
                GemCount = LootRandomer.GetRandomGem((int)(lootLevel.MinGemCount * totalGemMultiplier), lootLevel.MaxGemCount + (int)(lootLevel.MaxGemCount * totalGemMultiplier)),
                BluePrintCount = LootRandomer.GetRandomBlueprint(lootLevel.MinBlueprintCount, totalBluePrintMultiplier),
                StartDate = StartDate.ToString(),
                EndDate = EndDate.ToString(),
                HeroId = playerHero.HeroId,
                HeroName = playerHero.Hero.Name

            };


            return calculated;
        }

        private async Task<TDResponse<string>> GetUserCoordinate(long id)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                { return true; }; //TODO: Prodda silinmeli

            using (HttpClient client = new HttpClient(handler))
            {

                var response = client.PostAsync(new Uri(Environment.GetEnvironmentVariable("MapiApiUrl") + "/api/Map/GetUserCoordinate"),
                    new StringContent(JsonConvert.SerializeObject(
                        new BaseRequest<long>()
                        {
                            Data = id,
                            Info = new InfoDto()
                            {
                                DeviceId = "_socket_",
                                OsVersion = "_socket_",
                                AppVersion = "_socket_",
                                DeviceModel = "_socket_",
                                DeviceType = "_socket_",
                                UserId = 0,
                                Ip = "_socket_"
                            }
                        }
                    ), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var res = JsonConvert.DeserializeObject<TDResponse<string>>(content);
                    return res;
                }
                return null;
            }
        }
        private async Task<TDResponse<GangInfo>> GetGangInfoForRally(long id)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                { return true; }; //TODO: Prodda silinmeli

            using (HttpClient client = new HttpClient(handler))
            {

                var response = client.PostAsync(new Uri(Environment.GetEnvironmentVariable("WebSocketUrl") + "/api/Gang/GetGangInfoForRally"),
                    new StringContent(JsonConvert.SerializeObject(
                        new BaseRequest<long>()
                        {
                            Data = id,
                            Info = new InfoDto()
                            {
                                DeviceId = "_socket_",
                                OsVersion = "_socket_",
                                AppVersion = "_socket_",
                                DeviceModel = "_socket_",
                                DeviceType = "_socket_",
                                UserId = 0,
                                Ip = "_socket_"
                            }
                        }
                    ), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var res = JsonConvert.DeserializeObject<TDResponse<GangInfo>>(content);
                    return res;
                }
                return null;
            }
        }
        #endregion


    }
}
