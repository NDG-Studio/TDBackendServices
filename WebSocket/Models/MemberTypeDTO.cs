namespace WebSocket.Models;

public class MemberTypeDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool CanMemberChangeType { get; set; }=false;
    public bool CanKick { get; set; }=false;
    public bool CanDestroyGang { get; set; } = false;
    public bool CanEditGang { get; set; } = false;
    public bool GateManager { get; set; } = false;
    public bool CanDistributeMoney { get; set; } = false;
    public bool CanAcceptMember { get; set; } = false;
    public int PoolScore { get; set; } = 0;
}