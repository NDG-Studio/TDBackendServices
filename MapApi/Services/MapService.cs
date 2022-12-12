using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MapApi.Entities;
using MapApi.Interfaces;
using MapApi.Models;
using SharedLibrary.Helpers;
using SharedLibrary.Models;
using MapApi;
using MapApi.Enums;
using Newtonsoft.Json;

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
        
        public async Task<TDResponse<string>> GetUserCoordinate(BaseRequest<long> req)
        {
            TDResponse<string> response = new TDResponse<string>();
            var info = InfoDetail.CreateInfo(req, "GetMapItemTypes");
            try
            {
                var query =await _context.MapItem.Where(l => l.UserId == req.Data)
                    .Select(l=> $"{l.CoordX},{l.CoordY}").FirstOrDefaultAsync();

                response.Data = query;
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
                    UserName = user.Username,
                    BaseLevel = 1
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



        public async Task<TDResponse> TeleportPlayerBase(BaseRequest<TeleportBaseRequest> req, UserDto user)
        {
            TDResponse<TeleportBaseRequest> response = new TDResponse<TeleportBaseRequest>();
            var info = InfoDetail.CreateInfo(req, "TeleportPlayerBase");
            try
            {
                var area = await _context.Area.Where(l =>
                    req.Data.CoordX >= l.XMin &&
                    req.Data.CoordX < l.XMax &&
                    req.Data.CoordY >= l.YMin &&
                    req.Data.CoordY < l.YMax
                    )
                    .FirstOrDefaultAsync();
                if (area == null)
                {
                    response.SetError(OperationMessages.WrongCoordinate);
                    info.AddInfo(OperationMessages.WrongCoordinate);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var q = await _context.MapItem.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (q==null)
                {
                    var ent = new MapItem()
                    {
                        AreaId = area.Id,
                        CoordX = req.Data.CoordX,
                        CoordY = req.Data.CoordY,
                        MapItemTypeId = (int)MapItemTypeEnum.Player,//player
                        IsApe = user.IsApe,
                        UserId = user.Id,
                        UserName = user.Username,
                        BaseLevel = 1
                    };
                    await _context.AddAsync(ent);
                    await _context.SaveChangesAsync();
                    q = await _context.MapItem.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                }
                if (q==null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                q!.CoordX = req.Data.CoordX;
                q!.CoordY = req.Data.CoordY;
                q.AreaId = area.Id;
                //TODO: Fuel harcama eklenecek


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
                if (req.Data == null || req.Data?.Count == 0)//TODO: test için eklendi prodda sil
                {
                    q = _context.MapItem;
                }
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

        public async Task<TDResponse<List<InfoWithAreaDTO>>> GetMapByBoundBox(BaseRequest<BoundBox> req, UserDto user)
        {
            TDResponse<List<InfoWithAreaDTO>> response = new TDResponse<List<InfoWithAreaDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetMapByBoundBox");
            try
            {



                var qa = await _context.Area.Where(l =>
                (l.XMin <= req.Data.XMax && l.XMin > req.Data.XMin) && (l.YMin <= req.Data.YMax && l.YMin > req.Data.YMin)
                    ||
                (l.XMin <= req.Data.XMax && l.XMin > req.Data.XMin) && (l.YMax <= req.Data.YMax && l.YMax > req.Data.YMin)
                    ||
                (l.XMax <= req.Data.XMax && l.XMax > req.Data.XMin) && (l.YMin <= req.Data.YMax && l.YMin > req.Data.YMin)
                    ||
                (l.XMax <= req.Data.XMax && l.XMax > req.Data.XMin) && (l.YMax <= req.Data.YMax && l.YMax > req.Data.YMin)

                   ||

                (req.Data.XMin <= l.XMax && req.Data.XMin > l.XMin) && (req.Data.YMin <= l.YMax && req.Data.YMin > l.YMin)
                    ||
                (req.Data.XMin <= l.XMax && req.Data.XMin > l.XMin) && (req.Data.YMax <= l.YMax && req.Data.YMax > l.YMin)
                    ||
                (req.Data.XMax <= l.XMax && req.Data.XMax > l.XMin) && (req.Data.YMin <= l.YMax && req.Data.YMin > l.YMin)
                    ||
                (req.Data.XMax <= l.XMax && req.Data.XMax > l.XMin) && (req.Data.YMax <= l.YMax && req.Data.YMax > l.YMin)


                ).Select(l => l.Id).ToListAsync();

                var q = _context.MapItem.Where(l => qa.Contains(l.AreaId));

                response.Data = await _mapper.ProjectTo<MapInfoDto>(q).GroupBy(l => l.AreaId).Select(l => new InfoWithAreaDTO()
                {
                    AreaId = l.Key,
                    MapItems = l.ToList(),
                }).ToListAsync();
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

        public async Task<TDResponse<List<MapInfoDto>>> GetMapByBoundBoxV2(BaseRequest<BoundBox> req, UserDto user)
        {
            TDResponse<List<MapInfoDto>> response = new TDResponse<List<MapInfoDto>>();
            var info = InfoDetail.CreateInfo(req, "GetMapByBoundBoxV2");
            try
            {
                var q = _context.MapItem.Where(l =>
                l.CoordX <= req.Data.XMax &&
                l.CoordX >= req.Data.XMin &&
                l.CoordY >= req.Data.YMin &&
                l.CoordY <= req.Data.YMax &&
                l.MapItemTypeId == (int)MapItemTypeEnum.Player &&
                l.UserId != user.Id
                );

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
        
        public async Task<TDResponse<MapInfoDto>> GetPlayerBaseCoord(BaseRequest req, UserDto user)
        {
            TDResponse<MapInfoDto> response = new TDResponse<MapInfoDto>();
            var info = InfoDetail.CreateInfo(req, "GetPlayerBaseCoord");
            try
            {
                var q = _context.MapItem.Where(l =>
                    l.UserId == user.Id &&
                    l.MapItemTypeId == (int)MapItemTypeEnum.Player
                );
                var cc=await q.FirstOrDefaultAsync();
                if (cc!=null)
                {  
                    var baseInfo = await GetPlayerBaseInfo(user.Id);
                    if (!baseInfo.HasError && baseInfo.Data!=null)
                    {
                        cc.BaseLevel = baseInfo.Data.BaseLevel;
                    }
                    cc.UserName = user.Username;
                    await _context.SaveChangesAsync();
                }


                response.Data = await _mapper.ProjectTo<MapInfoDto>(q).FirstOrDefaultAsync() ?? new MapInfoDto()
                {
                    Id = 0,
                    AreaId = 0,
                    BaseLevel = 0,
                    CoordX = 50,
                    CoordY = 50,
                    UserId = user.Id,
                    UserName = user.Username,
                    IsApe = user.IsApe,
                    MapItemTypeId = (int)MapItemTypeEnum.Player
                };
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
                response.Data = apeCount - humanCount >= 0 ? false : true;
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

        #region GATE UTILS
        public async Task<TDResponse<List<MapItemDTO>>> GetAllGates(BaseRequest req, UserDto user)
        {
            TDResponse<List<MapItemDTO>> response = new TDResponse<List<MapItemDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetAllGates");
            try
            {
                var q = _context.MapItem.Include(l => l.Gate)
                    .Where(l => l.MapItemTypeId == (int)MapItemTypeEnum.Gate);
                response.Data = await _mapper.ProjectTo<MapItemDTO>(q).ToListAsync();

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
        
        
        private static async Task<TDResponse<PlayerBaseInfoDTO>> GetPlayerBaseInfo(long id)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                { return true; }; //TODO: Prodda silinmeli

            using (HttpClient client = new HttpClient(handler))
            {

                var response = client.PostAsync(new Uri(Environment.GetEnvironmentVariable("PlayerbaseUrl") + "/api/playerbase/GetOtherPlayersBaseInfo"),
                    new StringContent(JsonConvert.SerializeObject(
                        new BaseRequest<long>()
                        {
                            Data = id,
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
                    var res = JsonConvert.DeserializeObject<TDResponse<PlayerBaseInfoDTO>>(content);
                    return res;
                }
                return null;
            }
        }
    }
}
