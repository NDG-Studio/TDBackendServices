using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlayerBaseApi.Entities;
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
                        if (await _context.PlayerPrison.Where(l=>l.InTrainingPrisonerCount!=0 && l.UserId==user.Id).AnyAsync())//eğitimde esir var mı kontrol ediliyor.
                        {
                            response.SetError(OperationMessages.TrainingMustBeDone);
                            info.AddInfo(OperationMessages.TrainingMustBeDone);
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
                if (query.PrisonerCount<req.Data)
                {
                    req.Data = query.PrisonerCount;
                }
                if (query.InTrainingPrisonerCount!=0)
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

        #endregion
    }
}
