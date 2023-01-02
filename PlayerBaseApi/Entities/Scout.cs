using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities;

public class Scout
{
    [Key]
    public long Id { get; set; }
    public long SenderUserId { get; set; }
    public long TargetUserId { get; set; }
    public int AttackerSpyCount { get; set; } = 0;
    public int DefenserSpyCount { get; set; } = 0;
    public int DefenserDeadSpyCount { get; set; } = 0;
    public int AttackerDeadSpyCount { get; set; } = 0;
    public string? SenderUsername { get; set; }
    public string? TargetUsername { get; set; }
    public DateTimeOffset? ArrivedDate { get; set; } = null;
    public DateTimeOffset? ComeBackDate { get; set; } = null;
    public string? ScoutedData { get; set; } = null;
    public bool IsActive { get; set; } = true;
}