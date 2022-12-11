namespace PlayerBaseApi.Models
{
    public class PlayerTroopInfoDTO
    {
        public int TroopCount { get; set; } = 0;
        public int TrainingPerHour { get; set; } = 100;
        public TimeSpan MaxDuration { get; set; } = TimeSpan.FromHours(12);
        public string? LastTroopCollect { get; set; }
        public int? OutsideTroops { get; set; } = 0;
    }
}
