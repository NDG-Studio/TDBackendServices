using System.ComponentModel.DataAnnotations;
using SharedLibrary.Enums;

namespace PlayerBaseApi.Entities;

public class Rally
{
    [Key]
    public long Id { get; set; }
    public long TargetUserId { get; set; }
    public string? TargetGangId { get; set; }
    public string? TargetGangAvatarId { get; set; } = "";
    public string? TargetGangName { get; set; }
    
    public string? LeaderGangId { get; set; }
    public string? LeaderGangAvatarId { get; set; } = "";
    public string? LeaderGangName { get; set; }
    public int TargetAvatarId { get; set; } = 0;
    public int LeaderAvatarId { get; set; } = 0;
    public long LeaderUserId { get; set; }
    public string? TargetUsername { get; set; }
    public string? LeaderUsername { get; set; }
    public string? TargetUserCoord { get; set; }
    public string? LeaderUserCoord { get; set; }
    public int? TargetsWoundedTroop { get; set; }
    public int? ATotalWoundedTroop { get; set; }
    public int? TargetBarracksLevel { get; set; }
    public int? LootedScrap { get; set; }
    public int? TargetScrap { get; set; }
    public int? TargetsTroop { get; set; }
    public int? ATotalTroop { get; set; }
    public int? PrisonerCount { get; set; }
    public int? TargetWallLevel { get; set; }
    public int? TargetsDeadTroop { get; set; }
    public int? ATotalDeadTroop { get; set; }
    public byte? WinnerSide { get; set; } = (byte)AttackSideEnum.Defenser;
    public DateTimeOffset? RallyStartDate { get; set; } = null;
    public DateTimeOffset? WarDate { get; set; } = null;
    public DateTimeOffset? ComeBackDate { get; set; } = null;
    public DateTimeOffset Date { get; set; }
    public bool IsActive { get; set; } = true;
    public virtual ICollection<RallyPart> RallyParts { get; set; }
}