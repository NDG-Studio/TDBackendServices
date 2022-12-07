namespace SharedLibrary.Models;

public class AttackInfoDTO
{
    public long Id { get; set; }
    public int AttackerTroopCount { get; set; }
    public int AttackerHeroId { get; set; }
    public long AttackerUserId { get; set; }
    public long DefenserUserId { get; set; }
    public byte? WinnerSide { get; set; } 
    public string? ArriveDate { get; set; } = null;
    public string? ComeBackDate { get; set; } = null;
    public string? ResultData { get; set; } = null;
    public bool IsActive { get; set; } = true;
}