namespace WebSocket.Models;

public class ChangeGangMemberTypeRequest
{
    public long UserId { get; set; }
    public string GangMemberTypeId { get; set; }
}