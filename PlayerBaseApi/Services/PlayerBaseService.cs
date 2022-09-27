using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlayerBaseApi.Entities;
using PlayerBaseApi.Interfaces;
using PlayerBaseApi.Models;
using SharedLibrary.Helpers;
using PlayerBaseApi.Helpers;
using SharedLibrary.Models;
using Newtonsoft.Json;

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
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    response.SetError(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
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

        public async Task<TDResponse<PlayerBaseInfoDTO>> UpdateOrCreatePlayerBaseInfo(BaseRequest<PlayerBaseInfoDTO> req, UserDto user)
        {
            TDResponse<PlayerBaseInfoDTO> response = new TDResponse<PlayerBaseInfoDTO>();
            var info = InfoDetail.CreateInfo(req, "UpdatePlayerBaseInfo");
            try
            {
                var query = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (query != null)
                {
                    query.Scraps = req.Data.Scraps;
                    query.BluePrints = req.Data.BluePrints;
                    query.HeroCards = req.Data.HeroCards;
                    query.Gems = req.Data.Gems;
                    query.LastBaseCollect = req.Data.LastBaseCollect != null && req.Data.LastBaseCollect != "" ? DateTimeOffset.Now : query.LastBaseCollect;
                    response.Data = _mapper.Map<PlayerBaseInfoDTO>(query);
                }
                else
                {
                    var newInfo = new PlayerBaseInfo()
                    {
                        BaseLevel = 1,
                        BluePrints = 0,
                        Gems = 0,
                        BaseFullDuration = new TimeSpan(10, 0, 0),//TODO: Confige alınacak
                        Fuel = 0,
                        ResourceProductionPerHour = 1000,//TODO: SONRADAN Değiştirilebilecek
                        HeroCards = 0,
                        LastBaseCollect = DateTimeOffset.Now,
                        Scraps = 0,
                        UserId = user.Id,
                        Username = user.Username
                    };
                    await _context.AddAsync(newInfo);
                    response.Data = _mapper.Map<PlayerBaseInfoDTO>(newInfo);
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


                query.UpdateEndDate = DateTimeOffset.Now.Add(buildingUpdateTime?.UpgradeDuration ?? new TimeSpan(2, 0, 0));

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
                    var qq = _context.ResearchNode.Where(l => l.IsActive && l.ResearchTableId == qlist[i].Id).OrderBy(l => l.PlaceId);
                    var playerResearchNodes = await _context.PlayerResearchNode.Where(l => l.ResearchNode.ResearchTableId == qlist[i].Id).ToListAsync();
                    qlist[i].Nodes = await _mapper.ProjectTo<ResearchNodeDTO>(qq).ToListAsync();
                    qlist[i].Nodes.ForEach(l => l.CurrentLevel = playerResearchNodes.Where(k => k.ResearchNodeId == l.Id).Select(o => o.CurrentLevel).FirstOrDefault());
                    qlist[i].Nodes.ForEach(l => l.UpdateEndDate = playerResearchNodes.Where(k => k.ResearchNodeId == l.Id).Select(o => o.UpdateEndDate.ToString()).FirstOrDefault());
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
                var currentLevel = 0;
                if (currentNode == null)
                {
                    currentNode = new PlayerResearchNode()
                    {
                        CurrentLevel = currentLevel,
                        ResearchNodeId = req.Data,
                        UserId = user.Id,
                    };
                    await _context.AddAsync(currentNode);
                }
                var rq = _context.ResearchNodeUpgradeNecessaries.Where(l => l.UpgradeLevel == currentLevel + 1 && l.ResearchNodeId == req.Data);
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

                if (playerHeroLoot==null)
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


        //private async Task<Buff> GetPlayerTotalBuffs(long userId,int? heroId=null)
        //{
        //    List<Buff> playerBuffs = new List<Buff>();

        //    if (heroId!=null)
        //    {
        //        var heroSkillBuffs = await _context.PlayerHeroSkillLevel.Include(l=>l.HeroSkillLevel).The.Where(l => l.UserId == userId && l.HeroSkillLevel.HeroSkill.HeroId == heroId).Select(l => l.HeroSkillLevel.Buff).ToListAsync();
        //    }



        //    return playerBuffs;
        //}
    }
}
