using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class HeroSkill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PlaceId { get; set; }
        public int HeroId { get; set; }
        public int MaksLevel { get; set; }
        public bool IsPassiveSkill { get; set; }
        public string TumbnailUrl { get; set; }

        [ForeignKey("HeroId")]
        public Hero Hero { get; set; }

    }
}
