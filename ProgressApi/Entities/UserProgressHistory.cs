using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgressApi.Entities
{
    public class UserProgressHistory
    {
        [Key]
        public long Id { get; set; }
        public long? UserId { get; set; }
        public int? WaveId { get; set; }
        public int SpentCoin { get; set; }
        public int GainedCoin { get; set; }
        public int TotalCoin { get; set; }
        public int BarrierHealth { get; set; }
        public DateTimeOffset WaveStartTime { get; set; }
        public DateTimeOffset WaveEndTime { get; set; }

        [ForeignKey("WaveId")]
        public Wave? Wave { get; set; }

    }
}
