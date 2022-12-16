namespace SharedLibrary.Models;

public class RallyPartDTO
{
    public long Id { get; set; }
    public long RallyId { get; set; }
    public int TroopCount { get; set; }
    public int HeroId { get; set; }
    public long UserId { get; set; }
    public string Username { get; set; }
    public string? ArriveDate { get; set; } = null;
    public string? ComeBackDate { get; set; } = null;
    public int WoundedTroop { get; set; }
    public int DeadTroop { get; set; }
    public int SenderAvatarId { get; set; }
    public int  BarracksLevel { get; set; }
    public int WallLevel { get; set; }
    public int LootedScrap { get; set; }
    public int PrisonerCount { get; set; }
    public bool IsActive { get; set; } = true;
}