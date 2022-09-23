namespace PlayerBaseApi.Models
{
    public class HeroLevelThresholdDTO
    {
        public int HeroId { get; set; }
        public int Level { get; set; }
        public long Experience { get; set; }
        public BuffDTO Buff { get; set; }

    }
}
