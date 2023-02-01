using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities;

public class WavePart
{
    [Key]
    public int Id { get; set; }
    public int WaveId { get; set; }
    public int EnemyLevelId { get; set; }
    public int Count { get; set; }
    
    [ForeignKey("WaveId")]
    public Wave Wave { get; set; }
    
}