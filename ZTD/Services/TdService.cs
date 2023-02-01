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
                    var query = _context.Chapter.Include(l => l.Levels)
                        .Where(l => l.Id == userStatus.Level.ChapterId);
                    var chapter = await _mapper.ProjectTo<ChapterInfoDTO>(query).FirstOrDefaultAsync();

                    var userLevels = await _context.UserProgressHistory
                        .Where(l => l.UserId == user.Id && l.GainedStar > 0 && l.Level.ChapterId ==chapter.Id)
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

        public async Task<TDResponse<List<LevelDTO>>> GetLevels(BaseRequest<List<int>> req, UserDto userDto)
        {
            TDResponse<List<LevelDTO>> response = new TDResponse<List<LevelDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetLevels");

            try
            {
                var query = _context.Level.Include(l => l.Waves).ThenInclude(l=>l.WaveParts)
                    .Where(l => req.Data.Contains(l.Id));
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

        public Task<TDResponse<List<LevelDTO>>> GetTowers(BaseRequest<List<int>> req, UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<TDResponse<List<TableChangesDTO>>> GetSyncStatus(BaseRequest req, UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}