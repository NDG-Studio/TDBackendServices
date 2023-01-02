namespace PlayerBaseApi.Models;

public class ScoutRequest
{
    public long TargetUserId { get; set; }
    public double Distance { get; set; }
}
public class ScoutRequestV2
{
    public long TargetUserId { get; set; }
    public int SpyCount { get; set; } = 0;
    public double Distance { get; set; }
}