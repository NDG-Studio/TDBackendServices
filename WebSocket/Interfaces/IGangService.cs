﻿using SharedLibrary.Models;
using WebSocket.Models;

namespace WebSocket.Interfaces
{
    public interface IGangService
    {
        Task<TDResponse> CreateGang(BaseRequest<CreateGangRequest> req, UserDto user, string token);
        Task<TDResponse<GangInfo>> GetGangInfo(BaseRequest<long?> req, UserDto user);
        Task<TDResponse<GangInfo>> GetGangInfoForRally(BaseRequest<long> req);
        Task<TDResponse<List<GangMemberInfo>>> GetGangMembers(BaseRequest<string> req, UserDto user);
        Task<TDResponse<List<MemberTypeDTO>>> GetGangMemberTypes(BaseRequest req, UserDto user);
        Task<TDResponse> SetGangMemberType(BaseRequest<MemberTypeDTO> req, UserDto user);
        Task<TDResponse> AddGangMemberType(BaseRequest<MemberTypeDTO> req, UserDto user);
        Task<TDResponse> ChangeGangMemberType(BaseRequest<List<ChangeGangMemberTypeRequest>> req, UserDto user);
        Task<TDResponse> SetMemberTypePool(BaseRequest<List<SetMemberTypePoolRequest>> req, UserDto user);
        Task<TDResponse> SendGangApplication(BaseRequest<string> req, UserDto user);
        Task<TDResponse> SendGangInvitation(BaseRequest<long> req, UserDto user);
        Task<TDResponse> AcceptGangInvitation(BaseRequest<GangInvitationResponse> req, UserDto user);
        Task<TDResponse> KickMember(BaseRequest<long> req, UserDto user);
        Task<TDResponse> EditGang(BaseRequest<GangEditDTO> req, UserDto user);
    }
}
