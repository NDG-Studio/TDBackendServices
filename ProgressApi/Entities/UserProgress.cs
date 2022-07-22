using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgressApi.Entities
{
    public class UserProgress
    {
        [Key]
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public int? StageId { get; set; }
        public string? Ip { get; set; }
        public string? DeviceId { get; set; }
        public int StarCount { get; set; }
        public double Score { get; set; }
        public double ScrapValue { get; set; }
        public double BarrierHealth { get; set; }
        public DateTimeOffset StageStartTime { get; set; }
        public double Time { get; set; }

        [ForeignKey("StageId")]
        public Stage? Stage { get; set; }

    }
}
