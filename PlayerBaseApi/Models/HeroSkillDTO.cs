namespace PlayerBaseApi.Models
{
    public class HeroSkillDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PlaceId { get; set; }
        public int MaksLevel { get; set; }
        public bool IsPassiveSkill { get; set; }
        public string TumbnailUrl { get; set; }
        public int Level { get; set; }
        public int NextLevelBuffId { get; set; }
        public int BuffId { get; set; }
    }
}
