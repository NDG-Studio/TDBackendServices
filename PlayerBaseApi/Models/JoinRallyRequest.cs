namespace PlayerBaseApi.Models
{
    public class JoinRallyRequest
    {
        public int RallyId { get; set; }
        public int AttackerTroopCount { get; set; }
        public int AttackerHeroId { get; set; }
        public double Distance { get; set; }
    }
}