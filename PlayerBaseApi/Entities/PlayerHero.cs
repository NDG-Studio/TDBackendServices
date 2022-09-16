using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class PlayerHero
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int HeroId { get; set; }
        public long Exp { get; set; }
        public int CurrentLevel { get; set; }
        public int TalentPoint { get; set; }
        public int SkillPoint { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        [ForeignKey("HeroId")]
        public Hero Hero { get; set; }
    }
}
