namespace PlayerBaseApi.Models
{
    public class CollectTroopResponse
    {
        public TimeSpan CollectDuration { get; set; }
        public int TroopTrainingPerHour { get; set; }
        public int CollectedTroops { get; set; }
        public TimeSpan BarrackFullDuration { get; set; }
    }
}
