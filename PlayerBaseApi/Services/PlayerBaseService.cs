
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PlayerBaseApi.Entities;
using PlayerBaseApi.Enums;
using PlayerBaseApi.Helpers;
using PlayerBaseApi.Interfaces;
using PlayerBaseApi.Models;
using SharedLibrary.Helpers;
using SharedLibrary.Models;

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
                switch (req.Data!.BuildingTypeId)
                {
                    case 4://Hospital
                        var phospital = new PlayerHospital()
                        {
                            HospitalLevelId = 1,
                            InjuredCount = 0,
                            InHealingCount = 0,
                            HealingDoneDate = null,
                            UserId = user.Id
                        };
                        await _context.AddAsync(phospital);
                        break;
                    case 5://prison
                        var pprison = new PlayerPrison()
                        {
                            PrisonLevelId = 1,
                            PrisonerCount = 0,
                            InTrainingPrisonerCount = 0,
                            TrainingDoneDate = null,
                            UserId = user.Id
                        };
                        await _context.AddAsync(pprison);
                        break;
                    case 10://military base
                        var pTroop = new PlayerTroop()
                        {
                            TroopCount = 0,
                            UserId = user.Id
                        };
                        await _context.AddAsync(pTroop);
                        break;

                    default:
                        break;
                }
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
                var query = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (query == null)
                {
                    query = new PlayerBaseInfo()
                    {
                        BaseLevel = 1,
                        BluePrints = 0,
                        Gems = 5,
                        BaseFullDuration = new TimeSpan(10, 0, 0),//TODO: Confige alınacak
                        Fuel = 100,
                        ResourceProductionPerHour = 1000,//TODO: SONRADAN Değiştirilebilecek
                        RareHeroCards = 0,
                        EpicHeroCards = 0,
                        LegendaryHeroCards = 0,
                        LastBaseCollect = DateTimeOffset.Now,
                        Scraps = 10000,
                        UserId = user.Id,
                        Username = user.Username
                    };
                    await _context.AddAsync(query);
                    await _context.SaveChangesAsync();
                }
                response.Data = _mapper.Map<PlayerBaseInfoDTO>(query);
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
        public async Task<TDResponse<PlayerBaseInfoDTO>> UpdateOrCreatePlayerBaseInfo(BaseRequest<PlayerBaseInfoDTO> req, UserDto user)
        {
            TDResponse<PlayerBaseInfoDTO> response = new TDResponse<PlayerBaseInfoDTO>();
            var info = InfoDetail.CreateInfo(req, "UpdatePlayerBaseInfo");
            try
            {
                //var query = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                //if (query != null)
                //{
                //    query.Scraps = req.Data.Scraps;
                //    query.BluePrints = req.Data.BluePrints;
                //    query.HeroCards = req.Data.HeroCards;
                //    query.Gems = req.Data.Gems;
                //    query.LastBaseCollect = req.Data.LastBaseCollect != null && req.Data.LastBaseCollect != "" ? DateTimeOffset.Now : query.LastBaseCollect;
                //    response.Data = _mapper.Map<PlayerBaseInfoDTO>(query);
                //}
                //else
                //{
                //    var newInfo = new PlayerBaseInfo()
                //    {
                //        BaseLevel = 1,
                //        BluePrints = 0,
                //        Gems = 0,
                //        BaseFullDuration = new TimeSpan(10, 0, 0),//TODO: Confige alınacak
                //        Fuel = 0,
                //        ResourceProductionPerHour = 1000,//TODO: SONRADAN Değiştirilebilecek
                //        HeroCards = 0,
                //        LastBaseCollect = DateTimeOffset.Now,
                //        Scraps = 0,
                //        UserId = user.Id,
                //        Username = user.Username
                //    };
                //    await _context.AddAsync(newInfo);
                //    response.Data = _mapper.Map<PlayerBaseInfoDTO>(newInfo);
                //}
                //await _context.SaveChangesAsync();

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
                var buff = await GetPlayersTotalBuff(user.Id);
                duration += duration * buff.BuildingUpgradeDurationMultiplier;
                cost += (int)(cost * buff.BuildingUpgradeCostMultiplier);
                buildingUpgradeTime!.UpgradeDuration = duration;
                buildingUpgradeTime!.ScrapCount = cost;

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
                var buff = await GetPlayersTotalBuff(user.Id);
                duration += duration * buff.BuildingUpgradeDurationMultiplier;
                cost += (int)(cost * buff.BuildingUpgradeCostMultiplier);
                var playerBaseInfo = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (playerBaseInfo.Scraps < cost)
                {
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                playerBaseInfo.Scraps -= cost;
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

        public async Task<TDResponse<CollectBaseResponse>> CollectBaseResources(BaseRequest req, UserDto user)
        {
            TDResponse<CollectBaseResponse> response = new TDResponse<CollectBaseResponse>();
            var info = InfoDetail.CreateInfo(req, "CollectBaseResources");
            try
            {
                var playerBaseInfo = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if ((DateTimeOffset.Now - playerBaseInfo.LastBaseCollect).TotalMilliseconds < (new TimeSpan(0, 1, 0)).TotalMilliseconds)
                {
                    response.SetError(OperationMessages.NoChanges);
                    info.AddInfo(OperationMessages.NoChanges);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var duration = DateTimeOffset.Now - playerBaseInfo.LastBaseCollect;
                duration = playerBaseInfo.BaseFullDuration < duration ? playerBaseInfo.BaseFullDuration : duration;


                response.Data = new CollectBaseResponse()
                {
                    CollectDuration = duration,
                    CollectedResource = (int)(duration.TotalHours * playerBaseInfo.ResourceProductionPerHour),
                    ResourceProductionPerHour = playerBaseInfo.ResourceProductionPerHour,
                    BaseFullDuration = playerBaseInfo.BaseFullDuration
                };
                response.Data.CollectedResource += (int)(response.Data.CollectedResource * (await GetPlayersTotalBuff(user.Id)).BaseResourceMultiplier);
                playerBaseInfo.Fuel += response.Data.CollectedResource;
                playerBaseInfo.Scraps += response.Data.CollectedResource;
                playerBaseInfo.LastBaseCollect = DateTimeOffset.Now;

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
                var playerResource = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
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

                if (playerItem == null || playerItem.Count < req.Data.Count)
                {
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
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
                var playerBaseInfo = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
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
                var playerBaseInfo = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
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

                if (playerItem == null || playerItem.Count < req.Data.Count)
                {
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
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
                var playerBaseInfo = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
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

        public async Task<TDResponse<List<PlayerHeroLootDTO>>> GetActiveLootRuns(BaseRequest req, UserDto user)
        {
            TDResponse<List<PlayerHeroLootDTO>> response = new TDResponse<List<PlayerHeroLootDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetActiveLootRuns");
            try
            {
                var playerHeroLoot = _context.PlayerHeroLoot.Where(l => l.PlayerHero.UserId == user.Id && l.IsActive);

                response.Data = await _mapper.ProjectTo<PlayerHeroLootDTO>(playerHeroLoot).ToListAsync();
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
                    MinScrapCount = lootLevel.MinScrapCount + (int)(lootLevel.MinScrapCount * totalScrapMultiplier),
                    MaxScrapCount = lootLevel.MaxScrapCount + (int)(lootLevel.MaxScrapCount * totalScrapMultiplier),
                    MinGemCount = lootLevel.MinGemCount + (int)(lootLevel.MinGemCount * totalGemMultiplier),
                    MaxGemCount = lootLevel.MaxGemCount + (int)(lootLevel.MaxGemCount * totalGemMultiplier),
                    MinBluePrintCount = lootLevel.MinBlueprintCount + (int)(lootLevel.MinBlueprintCount * totalBluePrintMultiplier),
                    MaxBluePrintCount = lootLevel.MaxBlueprintCount + (int)(lootLevel.MaxBlueprintCount * totalBluePrintMultiplier),
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

                if (playerItem == null || playerItem.Count < req.Data.Count)
                {
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
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

        public async Task<TDResponse> SendLootRun(BaseRequest<int> req, UserDto user)
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

                var calculated = new LootRunDoneInfoDTO()
                {
                    ScrapCount = LootRandomer.GetRandomResource(lootLevel.MinScrapCount + (int)(lootLevel.MinScrapCount * totalScrapMultiplier), lootLevel.MaxScrapCount + (int)(lootLevel.MaxScrapCount * totalScrapMultiplier)),
                    GemCount = LootRandomer.GetRandomResource(lootLevel.MinGemCount + (int)(lootLevel.MinGemCount * totalGemMultiplier), lootLevel.MaxGemCount + (int)(lootLevel.MaxGemCount * totalGemMultiplier)),
                    BluePrintCount = LootRandomer.GetRandomResource(lootLevel.MinBlueprintCount + (int)(lootLevel.MinBlueprintCount * totalBluePrintMultiplier), lootLevel.MaxBlueprintCount + (int)(lootLevel.MaxBlueprintCount * totalBluePrintMultiplier)),
                };

                #endregion

                var ent = new PlayerHeroLoot()
                {
                    LootLevelId = lootLevelId,
                    PlayerHeroId = await _context.PlayerHero.Where(l => l.HeroId == req.Data && l.UserId == user.Id).Select(l => l.Id).FirstOrDefaultAsync(),
                    OperationEndDate = DateTimeOffset.Now + (lootLevel.LootDuration + lootLevel.LootDuration * totalDurationMultiplier),
                    OperationStartDate = DateTimeOffset.Now,
                    GainedResources = JsonConvert.SerializeObject(calculated),
                    IsActive = true,
                    LootLevel = lootLevel
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

                if ((playerHeroLoot.OperationEndDate - DateTimeOffset.Now).TotalMilliseconds > 0)
                {
                    response.SetError(OperationMessages.ProcessAllreadyExist);
                    info.AddInfo(OperationMessages.ProcessAllreadyExist);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                playerHeroLoot.IsActive = false;
                var playerBaseInfo = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                var gainedResource = JsonConvert.DeserializeObject<LootRunDoneInfoDTO>(playerHeroLoot.GainedResources);
                playerBaseInfo!.Scraps += gainedResource?.ScrapCount ?? 0;
                playerBaseInfo!.BluePrints += gainedResource?.BluePrintCount ?? 0;
                playerBaseInfo!.Gems += gainedResource?.GemCount ?? 0;

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
                var playerBaseInfo = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
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

                if (playerItem == null || playerItem.Count < req.Data.Count)
                {
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
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
                var playerBaseInfo = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
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


        #region MARKET UTILS

        public async Task<TDResponse<MarketDTO>> GetMarket(BaseRequest req, UserDto user)
        {
            TDResponse<MarketDTO> response = new TDResponse<MarketDTO>();
            var info = InfoDetail.CreateInfo(req, "GetMarket");
            try
            {
                var query = await _context.MarketItem.Include(l => l.Item).ThenInclude(l => l.ItemType)
                    .Where(l => l.IsActive).OrderBy(l => l.Item.ItemTypeId).ToListAsync();

                response.Data = new MarketDTO();
                var qq = query.GroupBy(l => l.Item.ItemType.ItemCategoryId).OrderBy(l => l.Key).ToList();
                for (int i = 0; i < qq.Count(); i++)
                {
                    switch (qq[i].Key)
                    {
                        case 1:
                            response.Data.Resources = _mapper.ProjectTo<MarketItemDTO>(qq?[i].ToList().AsQueryable()).ToList();
                            break;
                        case 2:
                            response.Data.SpeedUps = _mapper.ProjectTo<MarketItemDTO>(qq?[i].ToList().AsQueryable()).ToList();
                            break;
                        case 3:
                            response.Data.Buffs = _mapper.ProjectTo<MarketItemDTO>(qq?[i].ToList().AsQueryable()).ToList();
                            break;
                        case 4:
                            response.Data.Others = _mapper.ProjectTo<MarketItemDTO>(qq?[i].ToList().AsQueryable()).ToList();
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
                var playerBaseInfo = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                var marketItem = await _context.MarketItem.Where(l => l.Id == (req.Data == null ? 0 : req.Data.MarketItemId) && l.IsActive).FirstOrDefaultAsync();

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

                await _context.AddAsync(history);
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
                            response.Data.Resources = _mapper.ProjectTo<PlayerItemDTO>(qq?[i].ToList().AsQueryable()).ToList();
                            break;
                        case 2:
                            response.Data.SpeedUps = _mapper.ProjectTo<PlayerItemDTO>(qq?[i].ToList().AsQueryable()).ToList();
                            break;
                        case 3:
                            response.Data.Buffs = _mapper.ProjectTo<PlayerItemDTO>(qq?[i].ToList().AsQueryable()).ToList();
                            break;
                        case 4:
                            response.Data.Others = _mapper.ProjectTo<PlayerItemDTO>(qq?[i].ToList().AsQueryable()).ToList();
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
                var playerBaseInfo = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
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

        #endregion

        public async Task<TDResponse<List<PlayerItemDTO>>> GetPlayersSpeedUpItems(BaseRequest req, UserDto user)
        {
            TDResponse<List<PlayerItemDTO>> response = new TDResponse<List<PlayerItemDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetPlayersSpeedUpItems");
            try
            {

                var pq = _context.PlayerItem.Include(l => l.Item)
                   .Where(l => l.UserId == user.Id && l.Item.ItemTypeId == (int)ItemTypeEnum.SpeedUp).OrderBy(l => l.ItemId);
                var playerItems = await _mapper.ProjectTo<PlayerItemDTO>(pq).ToListAsync();

                response.Data = playerItems;
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


        #region PRIVATE FUNCTIONS


        /// <summary>
        /// HeroId gönderilmezse veya null gönderilirse hero buffları eklenmez
        /// </summary>
        /// <param name="userId">bufflarına ulaşılmak istenen userın id değeri</param>
        /// <param name="heroId">heroya bağlı bufflara ulaşabilmek için gerekli olan heroId</param>
        /// <returns>Tüm buffların değerlerinin toplamı olan tek bir buff objesi döner</returns>
        private async Task<Buff> GetPlayersTotalBuff(long userId, int? heroId = null)
        {
            List<Buff> playerBuffs = new List<Buff>();

            if (heroId != null)
            {
                var heroSkillBuffs = await _context.PlayerHeroSkillLevel
                    .Include(l => l.HeroSkillLevel).ThenInclude(l => l.Buff)
                    .Where(l => l.UserId == userId && l.HeroSkillLevel.HeroSkill.HeroId == heroId)
                    .Select(l => l.HeroSkillLevel.Buff).ToListAsync();

                var heroTalentBuffs = await _context.PlayerTalentTreeNode
                    .Include(l => l.TalentTreeNode).ThenInclude(l => l.Buff)
                    .Where(l => l.UserId == userId)
                    .Select(l => l.TalentTreeNode.Buff).ToListAsync();

                var playerHeroLevel = await _context.PlayerHero
                    .Where(l => l.UserId == userId && l.HeroId == heroId)
                    .Select(l => l.CurrentLevel).FirstOrDefaultAsync();
                var heroLevelBuffs = await _context.HeroLevelThreshold
                    .Include(l => l.Buff)
                    .Where(h => h.HeroId == heroId && h.Level == playerHeroLevel)
                    .Select(l => l.Buff).ToListAsync();

                playerBuffs.AddRange(heroSkillBuffs);
                playerBuffs.AddRange(heroTalentBuffs);
                playerBuffs.AddRange(heroLevelBuffs);
            }

            var researchBuffs = await _context.PlayerResearchNode
                .Include(l => l.ResearchNode).ThenInclude(l => l.Buff)
                .Where(l => l.UserId == userId)
                .Select(l => l.ResearchNode.Buff).ToListAsync();

            playerBuffs.AddRange(researchBuffs);



            return new Buff()
            {
                Id = playerBuffs.Count,
                Name = "user total buff",
                Description = "",
                LootBluePrintMultiplier = playerBuffs.Sum(l => l.LootBluePrintMultiplier),
                LootCapacity = playerBuffs.Sum(l => l.LootCapacity),
                LootDurationMultiplier = playerBuffs.Sum(l => l.LootDurationMultiplier),
                LootGemMultiplier = playerBuffs.Sum(l => l.LootGemMultiplier),
                LootPerfectRunMultiplier = playerBuffs.Sum(l => l.LootPerfectRunMultiplier),
                LootScrapMultiplier = playerBuffs.Sum(l => l.LootScrapMultiplier),
                PrisonCapacityMultiplier = playerBuffs.Sum(l => l.PrisonCapacityMultiplier),
                PrisonCostMultiplier = playerBuffs.Sum(l => l.PrisonCostMultiplier),
                PrisonExecutionEarnMultiplier = playerBuffs.Sum(l => l.PrisonExecutionEarnMultiplier),
                PrisonTrainingCostMultiplier = playerBuffs.Sum(l => l.PrisonTrainingCostMultiplier),
                PrisonTrainingDurationMultiplier = playerBuffs.Sum(l => l.PrisonTrainingDurationMultiplier),
                BuildingUpgradeDurationMultiplier = playerBuffs.Sum(l => l.BuildingUpgradeDurationMultiplier)
            };
        }

        #endregion


    }
}
