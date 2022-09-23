using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class HeroLevelThreshold
    {
        [Key]
        public int Id { get; set; }
        public int HeroId { get; set; }
        public int BuffId { get; set; } = 1;
        public int Level { get; set; }
        public long Experience { get; set; }

        [ForeignKey("HeroId")]
        public Hero Hero { get; set; }
        
        [ForeignKey("BuffId")]
        public Buff Buff { get; set; }
    }
}
