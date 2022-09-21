using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class PlayerPrison
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int PrisonLevelId { get; set; }
        public int PrisonerCount { get; set; }
        public DateTimeOffset? TrainingDoneDate { get; set; }
        public int InTrainingPrisonerCount { get; set; }

        [ForeignKey("PrisonLevelId")]
        public PrisonLevel PrisonLevel { get; set; }

    }
}
