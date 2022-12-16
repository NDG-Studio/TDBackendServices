using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLibrary.Enums;

namespace PlayerBaseApi.Entities;

public class RallyPart
{
    [Key]
    public long Id { get; set; }
    public long RallyId { get; set; }
    public int TroopCount { get; set; }
    public int HeroId { get; set; }
    public long UserId { get; set; }
    public string Username { get; set; }
    public DateTimeOffset? ArriveDate { get; set; } = null;
    public DateTimeOffset? ComeBackDate { get; set; } = null;
    public int WoundedTroop { get; set; }
    public int DeadTroop { get; set; }
    public int SenderAvatarId { get; set; }
    public int  BarracksLevel { get; set; }
    public int WallLevel { get; set; }
    public int LootedScrap { get; set; }
    public int PrisonerCount { get; set; }
    public bool IsActive { get; set; } = true;
    
    [ForeignKey("RallyId")]
    public Rally Rally { get; set; }
    
}