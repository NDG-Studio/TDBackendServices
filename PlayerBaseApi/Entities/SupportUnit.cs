using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLibrary.Enums;

namespace PlayerBaseApi.Entities;

public class SupportUnit
{
    [Key] 
    public long Id { get; set; } = 0;
    public long HostUserId { get; set; } = 0;
    public int HostAvatarId { get; set; } = 0;
    public string HostUsername { get; set; }
    public string ClientUsername { get; set; }
    public long ClientUserId { get; set; } = 0;
    public int ClientAvatarId { get; set; } = 0;
    public string? ClientCoord { get; set; } = null;
    public string? HostCoord { get; set; } = null;
    public int HeroId { get; set; } = 0;
    public string HeroName { get; set; }
    public int TroopCount { get; set; } = 0;
    public int Wounded { get; set; } = 0;
    public int Dead { get; set; } = 0;
    public DateTimeOffset? ArrivedDate { get; set; } = null;
    public DateTimeOffset? ComeBackDate { get; set; } = null;
    public DateTimeOffset? SendedDate { get; set; } = null;
    public int State { get; set; } = (int)SupportUnitState.Pending;
    public bool IsActive { get; set; }
    
    [ForeignKey("HeroId")]
    public Hero Hero { get; set; }
    
}