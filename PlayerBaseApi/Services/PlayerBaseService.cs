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
                    CollectDuration=duration,
                    CollectedResource= (int)(duration.TotalHours * playerBaseInfo.ResourceProductionPerHour),
                    ResourceProductionPerHour=playerBaseInfo.ResourceProductionPerHour,
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


    }
}
