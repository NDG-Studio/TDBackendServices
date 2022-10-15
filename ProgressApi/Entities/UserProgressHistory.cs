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
        public double ScrapValue { get; set; }
        public double BarrierHealth { get; set; }
        public DateTimeOffset WaveStartTime { get; set; }
        public DateTimeOffset WaveEndTime { get; set; }

        [ForeignKey("WaveId")]
        public Wave? Wave { get; set; }

    }
}
