using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class TalentTreeNode
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int HeroId { get; set; }
        public int TalentTreeId { get; set; }
        public int PlaceId { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("HeroId")]
        public Hero Hero { get; set; }

        [ForeignKey("TalentTreeId")]
        public TalentTree TalentTree { get; set; }
    }
}
