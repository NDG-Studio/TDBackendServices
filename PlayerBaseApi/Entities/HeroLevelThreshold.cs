using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class HeroLevelThreshold
    {
        [Key]
        public int Id { get; set; }
        public int HeroId { get; set; }
        public int Level { get; set; }
        public long Experience { get; set; }

        [ForeignKey("HeroId")]
        public Hero Hero { get; set; }
    }
}
