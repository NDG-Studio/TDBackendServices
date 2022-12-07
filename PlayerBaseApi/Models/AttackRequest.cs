namespace PlayerBaseApi.Models;

public class AttackRequest
{
    public long TargetUserId { get; set; }
    public int AttackerTroopCount { get; set; }
    public int AttackerHeroId { get; set; }
    public double Distance { get; set; }
}