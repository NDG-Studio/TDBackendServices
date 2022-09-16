namespace PlayerBaseApi.Models
{
    public class PlayerHeroDTO
    {
        public int HeroId { get; set; }
        public long Exp { get; set; }
        public int CurrentLevel { get; set; }
        public int TalentPoint { get; set; }
        public int SkillPoint { get; set; }
        public string? EndDate { get; set; }
        public HeroDTO Hero { get; set; }
    }
}
