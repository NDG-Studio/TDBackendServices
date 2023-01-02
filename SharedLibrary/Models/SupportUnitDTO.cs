using SharedLibrary.Enums;

namespace SharedLibrary.Models;

public class SupportUnitDTO
{
    public long Id { get; set; } = 0;
    public long HostUserId { get; set; } = 0;
    public int HostAvatarId { get; set; } = 0;
    public string HostCoord { get; set; }
    public string ClientCoord { get; set; }
    public string HostUsername { get; set; }
    public string ClientUsername { get; set; }
    public long ClientUserId { get; set; } = 0;
    public int ClientAvatarId { get; set; } = 0;
    public int HeroId { get; set; } = 0;
    public string HeroName { get; set; }
    public int TroopCount { get; set; } = 0;
    public int Wounded { get; set; } = 0;
    public int Dead { get; set; } = 0;
    public string? ArrivedDate { get; set; } = null;
    public string? ComeBackDate { get; set; } = null;
    public string? SendedDate { get; set; } = null;
    public int State { get; set; } = (int)SupportUnitState.Pending;
    public bool IsActive { get; set; }
}