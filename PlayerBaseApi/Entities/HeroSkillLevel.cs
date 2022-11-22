
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class HeroSkillLevel
    {
        [Key]
        public int Id { get; set; }
        public int BuffId { get; set; }
        public int HeroSkillId { get; set; }
        public int Level { get; set; }
        public int Cost { get; set; } = 1;
        
        [ForeignKey("HeroSkillId")]
        public HeroSkill HeroSkill { get; set; }        
        
        [ForeignKey("BuffId")]
        public Buff Buff { get; set; }
    }
}
