namespace PlayerBaseApi.Models
{
    public class HospitalLevelDTO
    {
        public int Level { get; set; }
        public TimeSpan HealingDurationPerUnit { get; set; }
        public double HealingCostPerUnit { get; set; }
        public int HospitalCapacity { get; set; }
    }
}
