using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class PlayerHero
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public long Exp { get; set; }
        public int CurrentLevel { get; set; }
        public int TalentPoint { get; set; }
        public int SkillPoint { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
