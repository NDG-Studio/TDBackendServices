using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities;

public class UserTdStatus
{
    [Key]
    public int Id { get; set; }

    public long UserId { get; set; }
    public int GemCount { get; set; }
    public long TotalGainedGemCount { get; set; }
    public long TotalGainedScrapCount { get; set; }
    public int ResearchPoint { get; set; }
    public long TotalGainedResearchPoint { get; set; }
    public long BuildedTowerCount { get; set; }
    public long UpgradedTowerCount { get; set; }
    public long RemovedTowerCount { get; set; }
    public long KilledEnemyCount { get; set; }
    public int TdLevelId { get; set; }
    
    
    [ForeignKey("UserId")]
    public User User { get; set; }
    
    [ForeignKey("TdLevelId")]
    public Level Level { get; set; }
}