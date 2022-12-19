namespace WebSocket.Models;

public class SetMemberTypePoolRequest
{
    public string MemberTypeId { get; set; }
    public int PoolScore { get; set; } = 0;
}