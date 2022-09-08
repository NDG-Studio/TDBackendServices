using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MapApi.Entities;
using MapApi.Interfaces;
using MapApi.Models;
using SharedLibrary.Helpers;
using SharedLibrary.Models;
using MapApi;

namespace MapApi.Services
{
    public class MapService : IMapService
    {
        private readonly ILogger<MapService> _logger;
        private readonly IMapper _mapper;
        private readonly MapContext _context;
        private readonly IConfiguration _configuration;

        public MapService(ILogger<MapService> logger, MapContext context, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        //public async Task<TDResponse<List<PlayerBasePlacementDTO>>> GetBuildings(BaseRequest req, UserDto user)
        //{
        //    TDResponse<List<PlayerBasePlacementDTO>> response = new TDResponse<List<PlayerBasePlacementDTO>>();
        //    var info = InfoDetail.CreateInfo(req, "GetBuildings");
        //    try
        //    {
        //        var query = _context.PlayerBasePlacement.Include(l => l.BuildingType).Where(l => l.UserId == user.Id && l.BuildingType.IsActive);
        //        var qlist = await _mapper.ProjectTo<PlayerBasePlacementDTO>(query).ToListAsync();
        //        response.Data = qlist;
        //        response.SetSuccess();
        //        info.AddInfo(OperationMessages.Success);
        //        _logger.LogInformation(info.ToString());
        //    }
        //    catch (Exception e)
        //    {
        //        response.SetError(OperationMessages.DbError);
        //        info.SetException(e);
        //        _logger.LogError(info.ToString());
        //    }
        //    return response;

        //}

        public async Task<TDResponse<List<MapItemTypeDTO>>> GetMapItemTypes(BaseRequest req, UserDto user)
        {
            TDResponse<List<MapItemTypeDTO>> response = new TDResponse<List<MapItemTypeDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetMapItemTypes");
            try
            {
                var query = _context.MapItemType.Where(l => l.IsActive);
                var qlist = await _mapper.ProjectTo<MapItemTypeDTO>(query).ToListAsync();
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

        public async Task<TDResponse<MapItemDTO>> AddUserBase(BaseRequest<bool> isApe, UserDto user)
        {
            TDResponse<MapItemDTO> response = new TDResponse<MapItemDTO>();
            var info = InfoDetail.CreateInfo(isApe, "AddUserBase");
            try
            {
                if (await _context.MapItem.AnyAsync(l => l.UserId == user.Id))
                {
                    response.SetError(OperationMessages.DuplicateRecord);
                    info.AddInfo(OperationMessages.DuplicateRecord);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var randArea = (await _context.Area.Where(l => (!isApe.Data ? l.ZoneId <= 6 : l.ZoneId > 9) && _context.MapItem.Where(k => k.AreaId == l.Id).Count() != 225).ToListAsync()).OrderBy(r => Guid.NewGuid()).FirstOrDefault();
                //randArea = await _context.Area.Where(l => l.Id == 1).FirstOrDefaultAsync();    //TODO: TEStTEN SONRA SİL
                var exclude = await _context.MapItem.Where(l => l.AreaId == randArea.Id).ToListAsync();
                var m = new List<MapItemDTO>();
                for (int i = randArea.XMin; i < randArea.XMax; i++)
                {
                    for (int l = randArea.YMin; l < randArea.YMax; l++)
                    {
                        if (!exclude.Any(t => t.CoordX == i && t.CoordY == l))
                        {
                            m.Add(new MapItemDTO() { CoordX = i, CoordY = l });
                        }
                    }
                }
                var x = m[new Random().Next(0, m.Count())];


                var ent = new MapItem()
                {
                    AreaId = randArea.Id,
                    CoordX = x.CoordX,
                    CoordY = x.CoordY,
                    IsApe = isApe.Data,
                    MapItemTypeId = 1,//player
                    UserId = user.Id,
                    UserName = user.Username
                };
                await _context.AddAsync(ent);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<MapItemDTO>(ent);
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


        public async Task<TDResponse> MoveUserBase(BaseRequest<MapItemDTO> req, UserDto user)
        {
            TDResponse<MapItemDTO> response = new TDResponse<MapItemDTO>();
            var info = InfoDetail.CreateInfo(req, "MoveUserBase");
            try
            {
                if (!await _context.MapItem.AnyAsync(l => l.UserId == user.Id))
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var q = await _context.MapItem.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                q.CoordX = req.Data.CoordX;
                q.CoordY = req.Data.CoordY;
                q.AreaId = await _context.Area.Where(l => l.XMax > q.CoordX && l.XMin <= q.CoordX && l.YMax > q.CoordY && l.YMin <= q.CoordY).Select(l => l.Id).FirstOrDefaultAsync();
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


        public async Task<TDResponse<List<MapInfoDto>>> GetMapByAreaIds(BaseRequest<List<int>> req, UserDto user)
        {
            TDResponse<List<MapInfoDto>> response = new TDResponse<List<MapInfoDto>>();
            var info = InfoDetail.CreateInfo(req, "GetMapByAreaIds");
            try
            {
                var q = _context.MapItem.Where(l => req.Data.Contains(l.AreaId));
                response.Data = await _mapper.ProjectTo<MapInfoDto>(q).ToListAsync();
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

        public async Task<TDResponse<bool>> GetApeIsRecommended(BaseRequest req, UserDto user)
        {
            TDResponse<bool> response = new TDResponse<bool>();
            var info = InfoDetail.CreateInfo(req, "GetApeIsRecommended");
            try
            {
                var apeCount = await _context.MapItem.CountAsync(l => l.IsApe);
                var humanCount = await _context.MapItem.CountAsync(l => !l.IsApe);
                response.Data = apeCount - humanCount >= 0 ? true : false;
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
