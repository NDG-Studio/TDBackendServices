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


    }
}
