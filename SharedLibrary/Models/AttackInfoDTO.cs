namespace SharedLibrary.Models;

public class AttackInfoDTO
{
    public long Id { get; set; }
    public int? AttackerPower { get; set; } = 0;
    public int? DefenserPower { get; set; } = 0;
    public int AttackerTroopCount { get; set; }
    public int AttackerHeroId { get; set; }
    public long AttackerUserId { get; set; }
    public int AttackerAvatarId { get; set; }
    public string AttackerUsername { get; set; }
    public int DefenserAvatarId { get; set; }
    public long DefenserUserId { get; set; }
    public string DefenserUsername { get; set; }
    public byte? WinnerSide { get; set; } 
    public string? ArriveDate { get; set; } = null;
    public string? ComeBackDate { get; set; } = null;
    public string? ResultData { get; set; } = null;
    public bool IsActive { get; set; } = true;
}