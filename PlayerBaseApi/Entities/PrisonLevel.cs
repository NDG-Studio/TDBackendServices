using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class PrisonLevel
    {
        [Key]
        public int Id { get; set; }
        public int Level { get; set; }
        public TimeSpan TrainingDurationPerUnit  { get; set; }
        public double TrainingCostPerUnit  { get; set; }
        public double ExecutionEarnPerUnit  { get; set; }
        public int MaxPrisonerCount  { get; set; }

    }
}
