using ZTD.Models;
using ZTD.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Helpers;
using SharedLibrary.Models;
using ZTD.Entities;
using ZTD.Enums;

namespace ZTD.Services
{

    public class DialogService : IDialogService
    {


        private readonly ILogger<DialogService> _logger;
        private readonly IMapper _mapper;
        private readonly ZTDContext _context;
        private readonly IConfiguration _configuration;

        public DialogService(ILogger<DialogService> logger, ZTDContext context, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        
        public async Task<TDResponse<List<DialogSceneDTO>>> GetDialogScenes(BaseRequest req, UserDto user)
        {
            TDResponse<List<DialogSceneDTO>> response = new TDResponse<List<DialogSceneDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetDialogScenes");
            try
            {
                var query = _context.DialogScene
                    .Include(l => l.Dialogs);
                var dialogSceneDtos = await _mapper.ProjectTo<DialogSceneDTO>(query).ToListAsync();
                
                response.Data = dialogSceneDtos;
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
                await SyncPlayerTable(new[] { TableEnum.Dialog },user);
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
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