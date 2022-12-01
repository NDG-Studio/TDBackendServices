namespace PlayerBaseApi.Models;

public class ScoutDTO
{
    public long SenderUserId { get; set; }
    public long TargetUserId { get; set; }
    public string? ArrivedDate { get; set; } = null;
    public string? ComeBackDate { get; set; } = null;
    public string ScoutedData { get; set; } = null;
    public bool IsActive { get; set; } = true;
}