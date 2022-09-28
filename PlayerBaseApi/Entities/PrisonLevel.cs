using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class PrisonLevel
    {
        [Key]
        public int Id { get; set; }
        public int BuffId { get; set; } = 1;
        public int Level { get; set; }
        public TimeSpan TrainingDurationPerUnit  { get; set; }
        public double TrainingCostPerUnit  { get; set; }
        public double ExecutionEarnPerUnit  { get; set; }
        public int MaxPrisonerCount  { get; set; }

        [ForeignKey("BuffId")]
        public Buff Buff { get; set; }

    }
}
