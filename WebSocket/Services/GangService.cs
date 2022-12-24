using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSocket.Entities;
using WebSocket.Interfaces;
using WebSocket.Models;
using SharedLibrary.Helpers;
using SharedLibrary.Models;
using WebSocket.Socket;
using Newtonsoft.Json;
using System.Text;
using SharedLibrary.Enums;
using WebSocket.Enums;

namespace WebSocket.Services
{
    public class GangService : IGangService
    {
        private readonly ILogger<GangService> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly WebSocketContext _context;

        public GangService(ILogger<GangService> logger, IMapper mapper, IConfiguration configuration, WebSocketContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
            _context = context;
        }

        public async Task<TDResponse> CreateGang(BaseRequest<CreateGangRequest> req, UserDto user, string token)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "CreateGang");
            try
            {
                if (req.Data == null)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var query = await _context.GangMember
                    .Where(l => l.UserId == user.Id && l.MemberType.Gang.IsActive&& l.IsActive).FirstOrDefaultAsync();
                if (query != null)
                {
                    response.SetError(OperationMessages.PlayerAllreadyGangMember);
                    info.AddInfo(OperationMessages.PlayerAllreadyGangMember);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (await _context.Gang.AnyAsync(l => l.Name == req.Data.Name && l.IsActive))
                {
                    response.SetError(OperationMessages.GangAllreadyExist);
                    info.AddInfo(OperationMessages.GangAllreadyExist);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (await _context.Gang.AnyAsync(l => l.ShortName == req.Data.ShortName && l.IsActive))
                {
                    response.SetError(OperationMessages.GangShortNameTaken);
                    info.AddInfo(OperationMessages.GangShortNameTaken);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var spendMoneyRes = await DbService.SpendGangCreateMoney(token, req.Info);
                if (spendMoneyRes != null && !spendMoneyRes.HasError)
                {
                    var gang = new Gang()
                    {
                        ShortName = req.Data.ShortName,
                        Name = req.Data.Name,
                        Description = req.Data.Description,
                        OwnerId = user.Id,
                        OwnerName = user.Username,
                        GangEntryTypeId = (int)GangEntryType.FreeForAll,
                        MemberCount = 1
                    };
                    await _context.AddAsync(gang);
                    await _context.SaveChangesAsync();
                    var memberType = new MemberType()
                    {
                        Name = "Member",
                        GangId = gang.Id,
                        PoolScore = 2
                    };
                    var ownerType = new MemberType()
                    {
                        Name = "Owner",
                        GangId = gang.Id,
                        CanAcceptMember = true,
                        CanDistributeMoney = true,
                        CanKick = true,
                        CanMemberChangeType = true,
                        GateManager = true,
                        CanDestroyGang = true,
                        CanEditGang = true,
                        IsActive = true,
                        PoolScore = 2
                    };                    
                    
                    var vpType = new MemberType()
                    {
                        Name = "Vice President",
                        GangId = gang.Id,
                        CanAcceptMember = true,
                        CanDistributeMoney = true,
                        CanKick = true,
                        CanMemberChangeType = true,
                        GateManager = true,
                        CanDestroyGang = false,
                        CanEditGang = false,
                        IsActive = true,
                        PoolScore = 2
                    };                    
                    var generalType = new MemberType()
                    {
                        Name = "General",
                        GangId = gang.Id,
                        CanAcceptMember = true,
                        CanDistributeMoney = false,
                        CanKick = true,
                        CanMemberChangeType = false,
                        GateManager = true,
                        CanDestroyGang = false,
                        CanEditGang = false,
                        IsActive = true,
                        PoolScore = 2
                    };                    
                    var captainType = new MemberType()
                    {
                        Name = "Captain",
                        GangId = gang.Id,
                        CanAcceptMember = true,
                        CanDistributeMoney = false,
                        CanKick = false,
                        CanMemberChangeType = false,
                        GateManager = false,
                        CanDestroyGang = false,
                        CanEditGang = false,
                        IsActive = true,
                        PoolScore = 2
                    };
                    await _context.AddAsync(memberType);
                    await _context.AddAsync(ownerType);
                    await _context.AddAsync(vpType);
                    await _context.AddAsync(generalType);
                    await _context.AddAsync(captainType);
                    await _context.SaveChangesAsync();

                    var gangMember = new GangMember()
                    {
                        MemberTypeId = ownerType.Id,
                        UserId = user.Id,
                        UserName = user.Username,
                        Power = 0//todo: power hesaplaması yapılacak
                    };
                    await _context.AddAsync(gangMember);
                    await _context.SaveChangesAsync();
                    await CreateGangChat(new BaseRequest<Guid>() { Info = req.Info, Data = gang.Id }, user);
                    response.SetSuccess();
                    info.AddInfo(OperationMessages.Success);
                    _logger.LogInformation(info.ToString());
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

        public async Task<TDResponse> AcceptGangInvitation(BaseRequest<GangInvitationResponse> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "AcceptGangInvitation");
            try
            {
                if (req.Data == null)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var newsGuid = new Guid(req.Data.NewsId);
                var news = await _context.News
                    .Where(l => l.Id == newsGuid && l.IsActive && l.IsCollected == null && l.TypeId==(int)NewsType.GangInvitation).FirstOrDefaultAsync();
                if (news == null)
                {
                    response.SetError(OperationMessages.GangInviteTimeout);
                    info.AddInfo(OperationMessages.GangInviteTimeout);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                news.IsCollected = req.Data.Accept;
                if (news.IsCollected==false)
                {
                    await _context.SaveChangesAsync();
                    response.SetSuccess();
                    return response;
                }
                var query = await _context.GangMember.Where(l => l.UserId == user.Id && l.MemberType.Gang.IsActive&& l.IsActive).FirstOrDefaultAsync();
                if (query != null)
                {
                    response.SetError(OperationMessages.PlayerAllreadyGangMember);
                    info.AddInfo(OperationMessages.PlayerAllreadyGangMember);
                    _logger.LogInformation(info.ToString());
                    return response;
                }



                var gangGuid = new Guid(news.AGangId);
                var invitedGang = await _context.Gang.Where(l => l.Id == gangGuid).FirstOrDefaultAsync();
                if (invitedGang==null)
                {
                    response.SetError(OperationMessages.GangInviteTimeout);
                    info.AddInfo(OperationMessages.GangInviteTimeout);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (invitedGang.MemberCount==invitedGang.Capacity)
                {
                    response.SetError(OperationMessages.GangCapacityFull);
                    info.AddInfo(OperationMessages.GangCapacityFull);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var memberTypeId = await _context.MemberType.Where(l => l.GangId == gangGuid && l.Name == "Member")
                    .FirstOrDefaultAsync();
                if (memberTypeId==null)
                {
                    response.SetError(OperationMessages.GangInviteTimeout);
                    info.AddInfo(OperationMessages.GangInviteTimeout+"--");
                    _logger.LogInformation(info.ToString());
                    return response; 
                }
                var gangMember = new GangMember()
                {
                    MemberTypeId =memberTypeId.Id ,
                    UserId = user.Id,
                    UserName = user.Username,
                    Power = 0//todo: power hesaplaması yapılacak
                };
                invitedGang.MemberCount++;
                await _context.AddAsync(gangMember);
                await _context.SaveChangesAsync();
                await JoinGangChat(new BaseRequest<Guid>() { Info = req.Info, Data = invitedGang.Id }, user);
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
        private async Task<TDResponse> CreateGangChat(BaseRequest<Guid> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "CreateGangChat");

            try
            {
                var gang = await _context.Gang.Where(l => l.Id == req.Data).FirstOrDefaultAsync();

                var chatRoom = new ChatRoom()
                {
                    ChatRoomTypeId = (int)ChatRoomTypeEnum.GangChat,
                    CreatedDate = DateTimeOffset.UtcNow,
                    IsActive = true,
                    LastChangeDate = DateTimeOffset.UtcNow,
                    Name = req.Data.ToString()
                };
                await _context.AddAsync(chatRoom);
                await _context.SaveChangesAsync();

                var chatRoomMember = new ChatRoomMember()
                {
                    ChatRoomId = chatRoom.Id,
                    IsActive = true,
                    JoinedRoomDate = DateTimeOffset.UtcNow,
                    LastSeen=DateTimeOffset.UtcNow,
                    UserId=user.Id,
                    Username=user.Username
                };
                await _context.AddAsync(chatRoomMember);
                await _context.SaveChangesAsync();
                Player.SendGangChatId(user.Id, chatRoom.Id.ToString());

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;
        }
        public async Task<TDResponse> SendGangInvitation(BaseRequest<long> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "SendGangInvitation");
            try
            {
                if (req == null)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var query = await _context.GangMember
                    .Include(l => l.MemberType).ThenInclude(l => l.Gang)
                    .Where(l => l.UserId == user.Id && l.MemberType.Gang.IsActive&& l.IsActive).FirstOrDefaultAsync();
                var queryForInvitation = await _context.GangMember.Where(l => l.UserId == req.Data && l.MemberType.Gang.IsActive&& l.IsActive).FirstOrDefaultAsync();
                if (queryForInvitation != null)
                {
                    response.SetError(OperationMessages.PlayerAllreadyGangMember);
                    info.AddInfo(OperationMessages.PlayerAllreadyGangMember);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (query == null)
                {
                    response.SetError(OperationMessages.PlayerIsNotInGangMember);
                    info.AddInfo(OperationMessages.PlayerIsNotInGangMember);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (!query.MemberType.CanAcceptMember)
                {
                    response.SetError(OperationMessages.PlayerNotHavePermission);
                    info.AddInfo(OperationMessages.PlayerNotHavePermission);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var gangInvitations = new News()
                {
                    Title = "Gang Invitation",
                    Detail = "-",
                    Date = DateTimeOffset.Now,
                    AGangId = query.MemberType.Gang.Id.ToString(),
                    AGangAvatarId = query.MemberType.Gang.AvatarId,
                    AGangName = $"[{query.MemberType.Gang.ShortName}]{query.MemberType.Gang.Name}",
                    UserId = req.Data,
                    AUserId = user.Id,
                    AUsername = user.Username,
                    AUserAvatar = GetOtherPlayersBaseInfo(user.Id).Result.AvatarId??0,
                    IsActive = true,
                    Seen = false,
                    TypeId = (int)NewsType.GangInvitation,
                    
                };
                await _context.AddAsync(gangInvitations);
                await _context.SaveChangesAsync();
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());


                Player.SendNewsRefreshNeeded(req.Data);



            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }
        public async Task<TDResponse<GangInfo>> GetGangInfo(BaseRequest<long?> req, UserDto user)
        {
            TDResponse<GangInfo> response = new TDResponse<GangInfo>();
            var info = InfoDetail.CreateInfo(req, "GetGangInfo");
            try
            {
                if (req.Data == (long)FakeId.TutorialEnemy)
                {
                    response.Data = new GangInfo()
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000000"),
                        Capacity = 10,
                        Description = "We will drink your blood with our bare hands. Leave us alone!",
                        MemberCount = 5,
                        Name = "Lucky",
                        Power = 9999,
                        ShortName = "UGR",
                        AvatarId = "1.1.2",
                        GangEntryTypeId=(int)GangEntryType.InviteOnly,
                        Owner = new GangMemberInfo()
                        {
                            Power = 666,
                            MemberTypeName = "Owner",
                            UserName = "US. D",
                            UserId = (long)FakeId.USD,
                            MemberTypeId = "00000000-0000-0000-0000-000000000000"
                        },
                        MemberType = null
                    };
                    return response;
                }
                var userId = req.Data ?? user.Id;
                var isOwnGang = req.Data == null;
                var c = await _context.GangMember
                    .Include(l => l.MemberType).ThenInclude(l => l.Gang)
                    .Where(l => l.UserId == userId && l.MemberType.Gang.IsActive&& l.IsActive).FirstOrDefaultAsync();
                if (c == null)
                {
                    response.Data = null;
                    response.SetSuccess(OperationMessages.Success);
                    return response;
                }
                var owner = await _context.GangMember
                    .Include(l => l.MemberType).ThenInclude(l => l.Gang)
                    .Where(l => l.UserId == c.MemberType.Gang.OwnerId && l.MemberType.Gang.IsActive&& l.IsActive).FirstOrDefaultAsync();
                if (c.UserId==user.Id)
                {
                    c.UserName = user.Username;
                    var playerBaseInfo = GetOtherPlayersBaseInfo(user.Id).Result;
                    c.Power = playerBaseInfo.Power;
                    c.MemberType.Gang.Power =
                        _context.GangMember
                            .Where(l => l.MemberType.GangId == c.MemberType.GangId && l.UserId!=c.UserId&& l.IsActive).Sum(l=>l.Power);
                    c.MemberType.Gang.Power += c.Power;
                }

                if (owner.UserId==user.Id)
                {
                    owner.MemberType.Gang.OwnerName = user.Username;
                }

                await _context.SaveChangesAsync();

                response.Data = new GangInfo()
                {
                    Id = c.MemberType.Gang.Id,
                    Capacity = c.MemberType.Gang.Capacity,
                    Description = c.MemberType.Gang.Description,
                    MemberCount = c.MemberType.Gang.MemberCount,
                    Name = c.MemberType.Gang.Name,
                    Power = c.MemberType.Gang.Power,
                    ShortName = c.MemberType.Gang.ShortName,
                    AvatarId = c.MemberType.Gang.AvatarId,
                    GangEntryTypeId=c.MemberType.Gang.GangEntryTypeId,
                    Owner = new GangMemberInfo()
                    {
                        Power = owner.Power,
                        MemberTypeName = owner.MemberType.Name,
                        UserName = owner.UserName,
                        UserId = owner.UserId,
                        MemberTypeId = owner.MemberTypeId.ToString()
                    },
                    MemberType = isOwnGang ? new MemberTypeDTO()
                    {
                        Id = c.MemberType.Id.ToString(),
                        Name = c.MemberType.Name,
                        CanKick = c.MemberType.CanKick,
                        GateManager = c.MemberType.GateManager,
                        CanAcceptMember = c.MemberType.CanAcceptMember,
                        CanDistributeMoney = c.MemberType.CanDistributeMoney,
                        CanDestroyGang = c.MemberType.CanDestroyGang,
                        CanEditGang = c.MemberType.CanEditGang,
                        CanMemberChangeType = c.MemberType.CanMemberChangeType,
                        PoolScore = c.MemberType.PoolScore
                        
                    }:null
                    
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
        public async Task<TDResponse<GangInfo>> GetGangInfoForRally(BaseRequest<long> req)
        {
            TDResponse<GangInfo> response = new TDResponse<GangInfo>();
            var info = InfoDetail.CreateInfo(req, "GetGangInfoForRally");
            try
            {
                var userId = req.Data;
                var c = await _context.GangMember
                    .Include(l => l.MemberType).ThenInclude(l => l.Gang)
                    .Where(l => l.UserId == userId && l.MemberType.Gang.IsActive&& l.IsActive).FirstOrDefaultAsync();
                if (c == null)
                {
                    response.Data = null;
                    response.SetSuccess(OperationMessages.Success);
                    return response;
                }
                var owner = await _context.GangMember
                    .Include(l => l.MemberType).ThenInclude(l => l.Gang)
                    .Where(l => l.UserId == c.MemberType.Gang.OwnerId && l.MemberType.Gang.IsActive&& l.IsActive).FirstOrDefaultAsync();
                response.Data = new GangInfo()
                {
                    Id = c.MemberType.Gang.Id,
                    Capacity = c.MemberType.Gang.Capacity,
                    Description = c.MemberType.Gang.Description,
                    MemberCount = c.MemberType.Gang.MemberCount,
                    Name = c.MemberType.Gang.Name,
                    Power = c.MemberType.Gang.Power,
                    ShortName = c.MemberType.Gang.ShortName,
                    AvatarId = c.MemberType.Gang.AvatarId,
                    Owner = new GangMemberInfo()
                    {
                        Power = owner.Power,
                        MemberTypeName = owner.MemberType.Name,
                        UserName = owner.UserName,
                        UserId = owner.UserId,
                        MemberTypeId = owner.MemberTypeId.ToString()
                    }
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
        public async Task<TDResponse> EditGang(BaseRequest<GangEditDTO> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "EditGang");
            try
            {
                var gangGuid = new Guid(req.Data.Id);
                var gangMember = await _context.GangMember
                    .Include(l => l.MemberType).ThenInclude(l => l.Gang)
                    .Where(l => l.UserId == user.Id && l.MemberType.Gang.IsActive && l.MemberType.Gang.Id==gangGuid&& l.IsActive).FirstOrDefaultAsync();
                if (gangMember == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (gangMember.MemberType.Name=="Owner" || gangMember.MemberType.CanEditGang)
                {
                    var z = await _context.Gang.Where(l =>
                        l.Id != gangGuid &&
                        (
                            l.Name == req.Data.Name ||
                            l.Description == req.Data.Description ||
                            l.ShortName == req.Data.ShortName
                        )
                    ).FirstOrDefaultAsync();
                    if (z!=null)
                    {
                        response.SetError(OperationMessages.DuplicateRecord);
                        info.AddInfo(OperationMessages.DuplicateRecord);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                    gangMember.MemberType.Gang.Description = req.Data.Description;
                    gangMember.MemberType.Gang.ShortName = req.Data.ShortName;
                    gangMember.MemberType.Gang.Name = req.Data.Name;
                    gangMember.MemberType.Gang.AvatarId = req.Data.AvatarId;
                    gangMember.MemberType.Gang.GangEntryTypeId = req.Data.GangEntryTypeId;
                    await _context.SaveChangesAsync();
                    response.SetSuccess();
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                
                response.SetError(OperationMessages.PlayerNotHavePermission);
                info.AddInfo(OperationMessages.PlayerNotHavePermission);
                _logger.LogInformation(info.ToString());
                return response;
                

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;
        }
        public async Task<TDResponse> KickMember(BaseRequest<long> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "KickMember");
            try
            {
                var gangMember = await _context.GangMember
                    .Include(l => l.MemberType).ThenInclude(l => l.Gang)
                    .Where(l => l.UserId == user.Id && l.MemberType.Gang.IsActive && l.IsActive).FirstOrDefaultAsync();
                
                if (gangMember == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                if (gangMember.MemberType.Name=="Owner" || gangMember.MemberType.CanKick || gangMember.UserId == req.Data)
                {
                    var kickedBoy = await _context.GangMember
                        .Where(l => l.UserId == req.Data && l.MemberType.Name != "Owner"&& l.IsActive)
                        .FirstOrDefaultAsync();
                    if (kickedBoy == null)
                    {
                        response.SetError(OperationMessages.PlayerNotHavePermission);
                        info.AddInfo(OperationMessages.PlayerNotHavePermission);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }

                    kickedBoy.IsActive = false;
                    var chatRoomMember = await _context.ChatRoomMember
                        .Where(l => l.UserId == kickedBoy.UserId &&
                                    l.ChatRoom.ChatRoomTypeId == (int)ChatRoomTypeEnum.GangChat && l.IsActive).FirstOrDefaultAsync();
                    if (chatRoomMember!=null)
                    {
                        chatRoomMember.IsActive = false;
                    }
                    gangMember.MemberType.Gang.MemberCount-- ;
                    await _context.SaveChangesAsync();
                    response.SetSuccess();
                    info.AddInfo(OperationMessages.Success);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                
                response.SetError(OperationMessages.PlayerNotHavePermission);
                info.AddInfo(OperationMessages.PlayerNotHavePermission);
                _logger.LogInformation(info.ToString());
                return response;
                

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;
        }
        public async Task<TDResponse> DestroyGang(BaseRequest req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "DestroyGang");
            try
            {
                var gangMember = await _context.GangMember
                    .Include(l => l.MemberType).ThenInclude(l => l.Gang)
                    .Where(l => l.UserId == user.Id && l.MemberType.Gang.IsActive&& l.IsActive ).FirstOrDefaultAsync();
                
                if (gangMember == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                if (gangMember.MemberType.Name=="Owner" || gangMember.MemberType.CanDestroyGang)
                {
                    var chatRoom=await _context.ChatRoomMember
                        .Where(l => l.UserId == user.Id &&
                                    l.ChatRoom.ChatRoomTypeId == (int)ChatRoomTypeEnum.GangChat).Select(l => l.ChatRoom)
                        .FirstOrDefaultAsync();
                    chatRoom.IsActive = false;
                    var chatRoomMembers =
                        await _context.ChatRoomMember.Where(l => l.ChatRoomId == chatRoom.Id).ToListAsync();
                    chatRoomMembers.ForEach(l=>l.IsActive=false);

                    gangMember.MemberType.Gang.IsActive = false;
                    var gangMembersTypes =await _context.MemberType.Where(l => l.GangId == gangMember.MemberType.GangId)
                        .ToListAsync();
                    gangMembersTypes.ForEach(l=>l.IsActive=false);
                    var gangMembers = await _context.GangMember
                        .Where(l => l.MemberType.GangId == gangMember.MemberType.GangId).ToListAsync();
                    gangMembers.ForEach(l=>l.IsActive=false);
                    await _context.SaveChangesAsync();
                    response.SetSuccess();
                    info.AddInfo(OperationMessages.Success);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                
                response.SetError(OperationMessages.PlayerNotHavePermission);
                info.AddInfo(OperationMessages.PlayerNotHavePermission);
                _logger.LogInformation(info.ToString());
                return response;
                

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;
        }
        public async Task<TDResponse<List<GangMemberInfo>>> GetGangMembers(BaseRequest<string> req, UserDto user)
        {
            TDResponse<List<GangMemberInfo>> response = new TDResponse<List<GangMemberInfo>>();
            var info = InfoDetail.CreateInfo(req, "GetGangInfo");
            try
            {
                if (req.Data == null)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var gangId = new Guid(req.Data);
                var query = await _context.GangMember
                    .Include(l => l.MemberType)
                    .Where(l => l.MemberType.Gang.Id == gangId && l.MemberType.Gang.IsActive && l.MemberType.Name != "Owner"&& l.IsActive)
                    .OrderByDescending(l => l.Power).ThenBy(l => l.UserName)
                    .Select(l => new GangMemberInfo()
                    {
                        Power = l.Power,
                        MemberTypeName = l.MemberType.Name,
                        UserName = l.UserName,
                        UserId = l.UserId,
                        MemberTypeId = l.MemberTypeId.ToString()
                        
                    }).ToListAsync();
                response.Data = query;
                response.SetSuccess();
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;
        }
        public async Task<TDResponse<List<MemberTypeDTO>>> GetGangMemberTypes(BaseRequest req, UserDto user)
        {
            TDResponse<List<MemberTypeDTO>> response = new TDResponse<List<MemberTypeDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetGangInfo");
            try
            {
                var gangId =await _context.GangMember
                    .Include(l=>l.MemberType).ThenInclude(l=>l.Gang)
                    .Where(l => l.UserId == user.Id&& l.IsActive).Select(l=>l.MemberType.Gang.Id).FirstOrDefaultAsync();
                var query = await _context.MemberType
                    .Where(l => l.Gang.Id == gangId && l.Gang.IsActive)
                    .Select(l => new MemberTypeDTO()
                    {
                        Id = l.Id.ToString(),
                        Name = l.Name,
                        CanKick = l.CanKick,
                        GateManager = l.GateManager,
                        CanAcceptMember = l.CanAcceptMember,
                        CanDistributeMoney = l.CanDistributeMoney,
                        CanDestroyGang = l.CanDestroyGang,
                        CanEditGang = l.CanEditGang,
                        CanMemberChangeType = l.CanMemberChangeType,
                        PoolScore = l.PoolScore
                    }).ToListAsync();
                response.Data = query;
                response.SetSuccess();
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;
        }
        public async Task<TDResponse> SetGangMemberType(BaseRequest<List<MemberTypeDTO>> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "SetGangMemberType");
            try
            {
                foreach (var mem in req.Data)
                {
                    var memberTypeId = new Guid(mem.Id);
                    var query = await _context.MemberType
                        .Where(l => l.Id == memberTypeId && l.IsActive).FirstOrDefaultAsync();
                    if (query.Name=="Owner")
                    {
                        continue;
                    }
                    query.Name = mem.Name;
                    query.CanKick = mem.CanKick;
                    query.GateManager = mem.GateManager;
                    query.CanAcceptMember = mem.CanAcceptMember;
                    query.CanDistributeMoney = mem.CanDistributeMoney;
                    query.CanMemberChangeType = mem.CanMemberChangeType;
                    query.CanDestroyGang = mem.CanDestroyGang;
                    query.CanEditGang = mem.CanEditGang;
                    await _context.SaveChangesAsync();
                    response.SetSuccess();
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
        public async Task<TDResponse> AddGangMemberType(BaseRequest<MemberTypeDTO> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "AddGangMemberType");
            try
            {
                var gangId = await _context.GangMember.Include(l=>l.MemberType)
                    .Where(l => l.UserId == user.Id&& l.IsActive).Select(l => l.MemberType.GangId)
                    .FirstOrDefaultAsync();
                if (gangId==null)
                {
                    response.SetError(OperationMessages.PlayerNotHavePermission);
                    info.AddInfo(OperationMessages.PlayerNotHavePermission);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (await _context.MemberType.Where(l=>l.GangId==gangId && l.Name == req.Data.Name).AnyAsync())
                {
                    response.SetError(OperationMessages.DuplicateRecord);
                    info.AddInfo(OperationMessages.DuplicateRecord);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                var ent = new MemberType()
                {
                    Name = req.Data.Name,
                    CanKick = req.Data.CanKick,
                    GateManager = req.Data.GateManager,
                    CanAcceptMember = req.Data.CanAcceptMember,
                    CanDistributeMoney = req.Data.CanDistributeMoney,
                    CanDestroyGang = req.Data.CanDestroyGang,
                    CanMemberChangeType = req.Data.CanMemberChangeType,
                    PoolScore = req.Data.PoolScore,
                    GangId =gangId,
                    CanEditGang = req.Data.CanEditGang,
                    IsActive = true
                };

                _context.Add(ent);
                await _context.SaveChangesAsync();
                response.SetSuccess();
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;
        }
        public async Task<TDResponse> ChangeGangMemberType(BaseRequest<List<ChangeGangMemberTypeRequest>> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "ChangeGangMemberType");
            try
            {
                foreach (var changed in req.Data)
                {
                    var memberTypeId = new Guid(changed.GangMemberTypeId);
                    var query = await _context.MemberType
                        .Where(l => l.Id == memberTypeId).FirstOrDefaultAsync();

                    var gangMember =
                        await _context.GangMember.Where(l => l.UserId == changed.UserId&& l.IsActive).FirstOrDefaultAsync();
                    if (query!=null&& gangMember!=null)
                    {
                        gangMember.MemberTypeId = memberTypeId;
                        await _context.SaveChangesAsync();
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
        public async Task<TDResponse> SetMemberTypePool(BaseRequest<List<SetMemberTypePoolRequest>> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "SetMemberTypePool");
            try
            {
                var canManageMoney = await _context.GangMember
                    .Include(l=>l.MemberType)
                    .Where(l => l.UserId == user.Id && l.MemberType.IsActive&& l.IsActive)
                    .Select(l=>l.MemberType.CanDistributeMoney)
                    .FirstOrDefaultAsync();
                if (!canManageMoney)
                {
                    response.SetError(OperationMessages.PlayerNotHavePermission);
                    info.AddInfo(OperationMessages.PlayerNotHavePermission);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                var totalPoolScore = req.Data.Sum(l => l.PoolScore);
                if (totalPoolScore != 10 )
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                foreach (var changed in req.Data)
                {
                    var memberTypeId = new Guid(changed.MemberTypeId);
                    var query = await _context.MemberType
                        .Where(l => l.Id == memberTypeId).FirstOrDefaultAsync();

                    if (query!=null)
                    {
                        query.PoolScore = changed.PoolScore;
                        await _context.SaveChangesAsync();
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
        public async Task<TDResponse> SendGangApplication(BaseRequest<string> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "SendGangApplication");
            try
            {

                var gangId = new Guid(req.Data);
                var gang = await _context.Gang.Where(l => l.IsActive && l.Id == gangId).FirstOrDefaultAsync();
                if (gang==null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (gang.GangEntryTypeId == (int)GangEntryType.FreeForAll)
                {
                    if (gang.Capacity>gang.MemberCount)
                    {
                        var gangMember = await _context.GangMember
                            .Include(l=>l.MemberType).ThenInclude(l=>l.Gang)
                            .Where(l => l.UserId == user.Id && l.MemberType.IsActive && l.MemberType.Gang.IsActive&& l.IsActive)
                            .FirstOrDefaultAsync();
                        if (gangMember != null)
                        {
                            response.SetError(OperationMessages.PlayerAllreadyGangMember);
                            info.AddInfo(OperationMessages.PlayerAllreadyGangMember);
                            _logger.LogInformation(info.ToString());
                            return response;
                        }
                
                        var memberTypeId = await _context.MemberType.Where(l => l.GangId == gang.Id && l.Name == "Member")
                            .FirstOrDefaultAsync();
                        if (memberTypeId==null)
                        {
                            response.SetError(OperationMessages.GangInviteTimeout);
                            info.AddInfo(OperationMessages.GangInviteTimeout);
                            _logger.LogInformation(info.ToString());
                            return response; 
                        }
                        await _context.AddAsync(new GangMember()
                        {
                            Power = 0,
                            UserName = user.Username,
                            UserId = user.Id,
                            MemberTypeId = memberTypeId.Id
                        });
                        memberTypeId.Gang.MemberCount++;
                        await _context.SaveChangesAsync();
                        response.SetSuccess();
                        info.AddInfo(OperationMessages.Success);
                        _logger.LogInformation(info.ToString());
                        return response;


                    }
                    else
                    {
                        response.SetError(OperationMessages.GangCapacityFull);
                        info.AddInfo(OperationMessages.GangCapacityFull);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                }

                if (gang.GangEntryTypeId==(int)GangEntryType.InviteOnly)
                {
                    response.SetError(OperationMessages.CantJoinGangWithApplication);
                    info.AddInfo(OperationMessages.CantJoinGangWithApplication);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var now = DateTimeOffset.UtcNow;
                var exist = await _context.GangApplication.Where(l =>
                    l.GangId == gangId && l.UserId == user.Id && now - l.Date < TimeSpan.FromDays(30)).FirstOrDefaultAsync();
                if (exist!=null)
                {
                    response.SetError(OperationMessages.ProcessAllreadyExist);
                    info.AddInfo(OperationMessages.ProcessAllreadyExist);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var userInfo = GetOtherPlayersBaseInfo(user.Id).Result;
                Console.WriteLine(JsonConvert.SerializeObject(userInfo));
                
                var baseLevelRanked = GetBaseLevelRankedByUserId(user.Id).Result;
                Console.WriteLine(JsonConvert.SerializeObject(baseLevelRanked));
                var killTroopRanked = GetKillTroopRankedByUserId(user.Id).Result;
                Console.WriteLine(JsonConvert.SerializeObject(killTroopRanked));
                var lootedScrapRanked = GetLootedScrapRankedByUserId(user.Id).Result;
                Console.WriteLine(JsonConvert.SerializeObject(lootedScrapRanked));
                var defenseKill = GetDefenseKillRankedByUserId(user.Id).Result;
                Console.WriteLine(JsonConvert.SerializeObject(defenseKill));
                var coord = DbService.GetUserCoordinate(user.Id).Result.Data ?? "" ;
                Console.WriteLine("^^"+coord);
                var ent = new GangApplication()
                {
                    Date = now,
                    GangId = gangId,
                    UserId = user.Id,
                    Username = user.Username,
                    Coordinate = coord,
                    UserAvatarId = userInfo?.AvatarId ?? 0,
                    Rank1 = baseLevelRanked.OwnRanked.ToString(),
                    Rank2 = killTroopRanked.OwnRanked.ToString(),
                    Rank3 = lootedScrapRanked.OwnRanked.ToString(),
                    Rank4 = defenseKill.OwnRanked.ToString(),
                };
                var allExist = await _context.GangApplication.Where(l => l.UserId == user.Id && l.GangId == gangId)
                    .ToListAsync();
                _context.RemoveRange(allExist);
                await _context.SaveChangesAsync();
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
                
        public async Task<TDResponse> AcceptGangApplication(BaseRequest<ApplicationAcceptRequest> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "AcceptGangApplication");
            try
            {

                var gangAppId = new Guid(req.Data.ApplicationId);
                var gangApp = await _context.GangApplication
                    .Include(l=>l.Gang)
                    .Where(l => l.Id == gangAppId).FirstOrDefaultAsync();
                if (gangApp==null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (!req.Data.IsAccept)
                {
                    _context.Remove(gangApp);
                    await _context.SaveChangesAsync();

                    response.SetSuccess();
                    info.AddInfo(OperationMessages.Success);
                    _logger.LogInformation(info.ToString());
                }
                
                var gangMember = await _context.GangMember
                    .Include(l=>l.MemberType).ThenInclude(l=>l.Gang)
                    .Where(l => l.UserId == gangApp.UserId && l.MemberType.IsActive && l.MemberType.Gang.IsActive&& l.IsActive)
                    .FirstOrDefaultAsync();
                if (gangMember != null)
                {
                    response.SetError(OperationMessages.PlayerAllreadyGangMember);
                    info.AddInfo(OperationMessages.PlayerAllreadyGangMember);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                
                var memberTypeId = await _context.MemberType.Where(l => l.GangId == gangApp.GangId && l.Name == "Member")
                    .FirstOrDefaultAsync();
                if (memberTypeId==null)
                {
                    response.SetError(OperationMessages.GangInviteTimeout);
                    info.AddInfo(OperationMessages.GangInviteTimeout);
                    _logger.LogInformation(info.ToString());
                    return response; 
                }

                if (memberTypeId.Gang.MemberCount==memberTypeId.Gang.Capacity)
                {
                    response.SetError(OperationMessages.GangCapacityFull);
                    info.AddInfo(OperationMessages.GangCapacityFull);
                    _logger.LogInformation(info.ToString());
                    return response; 
                }

                await _context.AddAsync(new GangMember()
                {
                    Power = 0,
                    UserName = gangApp.Username,
                    UserId = gangApp.UserId,
                    MemberTypeId = memberTypeId.Id
                });
                memberTypeId.Gang.MemberCount++;
                _context.Remove(gangApp);
                await _context.SaveChangesAsync();

                var acceptNews = new News()
                {
                    Title = "Your Gang Application Has Been Accepted",
                    Detail = "-",
                    Date = DateTimeOffset.Now,
                    AGangId = memberTypeId.Gang.Id.ToString(),
                    AGangAvatarId = memberTypeId.Gang.AvatarId,
                    AGangName = $"[{memberTypeId.Gang.ShortName}]{memberTypeId.Gang.Name}",
                    UserId = gangApp.UserId,
                    AUserId = user.Id,
                    AUsername = user.Username,
                    AUserAvatar = GetOtherPlayersBaseInfo(user.Id).Result.AvatarId ?? 0,
                    IsActive = true,
                    Seen = false,
                    TypeId = (int)NewsType.GangApplicationDone,
                };
                await _context.AddAsync(acceptNews);
                await _context.SaveChangesAsync();
                Player.SendNewsRefreshNeeded(gangApp.UserId);

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
        
        public async Task<TDResponse<Paging<GangInfo>>> GetGangs(BaseRequest<int> req, UserDto user)
        {
            TDResponse<Paging<GangInfo>> response = new TDResponse<Paging<GangInfo>>();
            var info = InfoDetail.CreateInfo(req, "GetGangs");
            try
            {
                response.Data = new Paging<GangInfo>();
                response.Data.PageIndex = req.Data;
                
                response.Data.PagingData = await _context.Gang
                    .Where(l=>l.IsActive)
                    .OrderByDescending(l => l.Name).ThenBy(l => l.Id)
                    .Skip(req.Data*10)
                    .Take(10)
                    .Select(l=>new GangInfo()
                    {
                        Capacity = l.Capacity,
                        Description = l.Description,
                        Id = l.Id,
                        Name = l.Name,
                        Owner = new GangMemberInfo()
                        {
                            Power = l.Power,
                            UserId = l.OwnerId,
                            UserName = l.OwnerName,
                            MemberTypeName = "Owner",
                        },
                        Power = l.Power,
                        AvatarId = l.AvatarId,
                        MemberCount = l.MemberCount,
                        ShortName = l.ShortName,
                        GangEntryTypeId = l.GangEntryTypeId
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
        public async Task<TDResponse<Paging<GangApplicationDTO>>> GetGangApplications(BaseRequest<int> req, UserDto user)
        {
            TDResponse<Paging<GangApplicationDTO>> response = new TDResponse<Paging<GangApplicationDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetGangApplications");
            try
            {
                var gangId = await _context.GangMember
                    .Include(l=>l.MemberType).ThenInclude(l=>l.Gang)
                    .Where(l => l.UserId == user.Id&& l.IsActive && l.MemberType.Gang.IsActive && l.MemberType.IsActive)
                    .Select(l => l.MemberType.GangId).FirstOrDefaultAsync();
                response.Data = new Paging<GangApplicationDTO>();
                response.Data.PageIndex = req.Data;
                
                response.Data.PagingData = await _context.GangApplication
                    .Where(l=>l.GangId==gangId)
                    .OrderByDescending(l => l.Date).ThenBy(l => l.Id)
                    .Skip(req.Data*10)
                    .Take(10)
                    .Select(l=>new GangApplicationDTO()
                    {
                        Id = l.Id.ToString(),
                        Date = l.Date.ToString(),
                        Rank1 = l.Rank1,
                        Coordinate = l.Coordinate,
                        Rank2 = l.Rank2,
                        Rank3 = l.Rank3,
                        Username = l.Username,
                        UserId = l.UserId,
                        Rank4 = l.Rank4,
                        UserAvatarId = l.UserAvatarId
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
        


        #region Private Functions

                
        private static async Task<PlayerBaseInfoDTO> GetOtherPlayersBaseInfo(long userId)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                { return true; }; //TODO: Prodda silinmeli

            using (HttpClient client = new HttpClient(handler))
            {
                var response = client.PostAsync(new Uri(Player.PlayerBaseUrl + "/api/PlayerBase/GetOtherPlayersBaseInfo"),
                    new StringContent(JsonConvert.SerializeObject(
                        new BaseRequest<long>()
                        {
                            Data = userId,
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
                    var res = JsonConvert.DeserializeObject<TDResponse<PlayerBaseInfoDTO>>(content)?.Data;
                    return res;
                }
                return null;
            }
        }
        private static async Task<LeaderBoardItem> GetBaseLevelRankedByUserId(long userId)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                { return true; }; //TODO: Prodda silinmeli

            using (HttpClient client = new HttpClient(handler))
            {
                var response = client.PostAsync(new Uri(Player.PlayerBaseUrl + "/api/PlayerBase/GetBaseLevelRankedByUserId"),
                    new StringContent(JsonConvert.SerializeObject(
                        new BaseRequest<long>()
                        {
                            Data = userId,
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
                    var res = JsonConvert.DeserializeObject<TDResponse<LeaderBoardItem>>(content)?.Data;
                    return res;
                }
                return null;
            }
        }
        private static async Task<LeaderBoardItem> GetKillTroopRankedByUserId(long userId)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                { return true; }; //TODO: Prodda silinmeli

            using (HttpClient client = new HttpClient(handler))
            {
                var response = client.PostAsync(new Uri(Player.PlayerBaseUrl + "/api/PlayerBase/GetKillTroopRankedByUserId"),
                    new StringContent(JsonConvert.SerializeObject(
                        new BaseRequest<long>()
                        {
                            Data = userId,
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
                    var res = JsonConvert.DeserializeObject<TDResponse<LeaderBoardItem>>(content)?.Data;
                    return res;
                }
                return null;
            }
        }
        private static async Task<LeaderBoardItem> GetLootedScrapRankedByUserId(long userId)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                { return true; }; //TODO: Prodda silinmeli

            using (HttpClient client = new HttpClient(handler))
            {
                var response = client.PostAsync(new Uri(Player.PlayerBaseUrl + "/api/PlayerBase/GetLootedScrapRankedByUserId"),
                    new StringContent(JsonConvert.SerializeObject(
                        new BaseRequest<long>()
                        {
                            Data = userId,
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
                    var res = JsonConvert.DeserializeObject<TDResponse<LeaderBoardItem>>(content)?.Data;
                    return res;
                }
                return null;
            }
        }
        private static async Task<LeaderBoardItem> GetDefenseKillRankedByUserId(long userId)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                { return true; }; //TODO: Prodda silinmeli

            using (HttpClient client = new HttpClient(handler))
            {
                var response = client.PostAsync(new Uri(Player.PlayerBaseUrl + "/api/PlayerBase/GetDefenseKillRankedByUserId"),
                    new StringContent(JsonConvert.SerializeObject(
                        new BaseRequest<long>()
                        {
                            Data = userId,
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
                    var res = JsonConvert.DeserializeObject<TDResponse<LeaderBoardItem>>(content)?.Data;
                    return res;
                }
                return null;
            }
        }
        private async Task<TDResponse> JoinGangChat(BaseRequest<Guid> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "JoinGangChat");

            try
            {
                var guidId = req.Data.ToString();
                var gangChatRoom = await _context.ChatRoom.Where(l => l.ChatRoomTypeId == (int)ChatRoomTypeEnum.GangChat && l.Name == guidId).FirstOrDefaultAsync();
                if (gangChatRoom==null)
                {
                    response.SetError(OperationMessages.GangInviteTimeout);
                    info.AddInfo(OperationMessages.GangInviteTimeout+"--");
                    _logger.LogInformation(info.ToString());
                    return response; 
                }
                var chatRoomMember = new ChatRoomMember()
                {
                    ChatRoomId =gangChatRoom.Id,
                    IsActive = true,
                    JoinedRoomDate = DateTimeOffset.UtcNow,
                    LastSeen=DateTimeOffset.UtcNow,
                    UserId=user.Id,
                    Username=user.Username
                };
                await _context.AddAsync(chatRoomMember);
                await _context.SaveChangesAsync();
                Player.SendGangChatId(user.Id, gangChatRoom.Id.ToString());

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
