namespace PlayerBaseApi.Models;

public class SupportUnitRequest
{
    public long TargetUserId { get; set; }
    public int SenderTroopCount { get; set; }
    public int SenderHeroId { get; set; }
    public double Distance { get; set; }
}