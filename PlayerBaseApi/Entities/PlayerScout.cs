using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class PlayerScout
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int ScoutLevelId { get; set; }
        public int SpyCount { get; set; }
        public DateTimeOffset? TrainingDoneDate { get; set; }
        public int InTrainingCount { get; set; }

        [ForeignKey("ScoutLevelId")]
        public ScoutLevel ScoutLevel { get; set; }
    }
}
