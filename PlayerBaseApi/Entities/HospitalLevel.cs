using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class HospitalLevel
    {
        [Key]
        public int Id { get; set; }
        public int Level { get; set; }
        public TimeSpan HealingDurationPerUnit { get; set; }
        public double HealingCostPerUnit { get; set; }
        public int HospitalCapacity { get; set; }
    }
}
