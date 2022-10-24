using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class PlayerTroop
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int TroopCount { get; set; }=0;
        public int TrainingPerHour { get; set; } = 100;
        public TimeSpan MaxDuration { get; set; }= TimeSpan.FromHours(12);
        public DateTimeOffset LastTroopCollect { get; set; }
    }
}
