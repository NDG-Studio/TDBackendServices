namespace PlayerBaseApi.Models
{
    public class CreateRallyRequest
    {
        public long TargetUserId { get; set; }
        public int AttackerTroopCount { get; set; }
        public int AttackerHeroId { get; set; }
        public int RallyStartAfterMinute { get; set; }
        public double Distance { get; set; }
    }
}