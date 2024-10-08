namespace SharedLibrary.Models;

public class AttackResultData
{
    public int TargetsWoundedTroop { get; set; }
    public int AttackersWoundedTroop { get; set; }
    public int AttackersDeadTroop { get; set; }
    public int? AttackerPower { get; set; } = 0;
    public int? DefenserPower { get; set; } = 0;
    public int TargetsDeadTroop { get; set; }
    public int TargetsTroop { get; set; }
    public string TargetUsername { get; set; }
    public long TargetUserId { get; set; }
    public int SenderAvatarId { get; set; }
    public int TargetAvatarId { get; set; }
    public long SenderUserId { get; set; }
    public string SenderUsername { get; set; }
    public int  BarracksLevel { get; set; }
    public int WallLevel { get; set; }
    public int LootedScrap { get; set; }
    public int DefenserScrap { get; set; }
    public int PrisonerCount { get; set; }
    
}