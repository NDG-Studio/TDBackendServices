using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class UserProgressHistory
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
        public int LevelId { get; set; }
        public int SpentCoin { get; set; }
        public int GainedCoin { get; set; }
        public int TotalCoin { get; set; }
        public int BarrierHealth { get; set; }
        public DateTimeOffset WaveStartTime { get; set; }
        public DateTimeOffset WaveEndTime { get; set; }
        public int GainedStar { get; set; } = 0;

        [ForeignKey("LevelId")]
        public Level Level { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
