namespace PlayerBaseApi.Models
{
    public class CollectBaseResponse
    {
        public TimeSpan CollectDuration { get; set; }
        public int ResourceProductionPerHour { get; set; }
        public int CollectedResource { get; set; }
        public TimeSpan BaseFullDuration { get; set; }
    }
}
