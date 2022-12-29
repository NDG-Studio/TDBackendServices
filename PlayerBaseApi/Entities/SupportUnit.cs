using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlayerBaseApi.Enums;

namespace PlayerBaseApi.Entities;

public class SupportUnit
{
    [Key] 
    public long Id { get; set; } = 0;
    public long HostUserId { get; set; } = 0;
    public long ClientUserId { get; set; } = 0;
    public int HeroId { get; set; } = 0;
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