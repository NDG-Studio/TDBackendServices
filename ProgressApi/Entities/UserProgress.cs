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
        public int? FailCount { get; set; }
        public int? KillCount { get; set; }
        public int? EndGameScore { get; set; }
        public string? Ip { get; set; }
        public string? DeviceId { get; set; }
        public DateTimeOffset LevelStartTime { get; set; }
        public DateTimeOffset LevelEndTime { get; set; }

        [ForeignKey("StageId")]
        public Stage? Stage { get; set; }

    }
}
