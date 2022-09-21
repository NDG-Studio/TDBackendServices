namespace PlayerBaseApi.Models
{
    public class PrisonLevelDTO
    {
        public int Level { get; set; }
        public TimeSpan TrainingDurationPerUnit { get; set; }
        public double TrainingCostPerUnit { get; set; }
        public double ExecutionEarnPerUnit { get; set; }
        public int MaxPrisonerCount { get; set; }
    }
}
