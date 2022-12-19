namespace WebSocket.Models;

public class GangEditDTO
{
    public string Id { get; set; }
    public string ShortName { get; set; } = String.Empty;
    public string Name { get; set; }
    public string Description { get; set; }
    public int AvatarId { get; set; } = 0;
    public int GangEntryTypeId { get; set; } = 1;
}