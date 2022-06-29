using System.ComponentModel.DataAnnotations;
using SharedLibrary.Models;

namespace ProgressApi.Models
{

    public class ProgressDto
    {
        public int? StageId { get; set; }
        public int? FailCount { get; set; }
        public int? KillCount { get; set; }
        public int? EndGameScore { get; set; }
        public string? DeviceId { get; set; }
        public string? LevelStartTime { get; set; }
        public string? LevelEndTime { get; set; }

    }
}
