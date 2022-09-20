using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PlayerBaseApi.Entities
{
    public class PlayerHeroSkillLevel
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int HeroSkillLevelId { get; set; }

        [ForeignKey("HeroSkillLevelId")]
        public HeroSkillLevel HeroSkillLevel { get; set; }      
    }
}
