using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class PlayerHeroLoot
    {
        [Key]
        public int Id { get; set; }
        public int PlayerHeroId { get; set; }
        public int LootLevelId { get; set; }
        public DateTimeOffset OperationEndDate { get; set; }
        public string GainedResources { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("PlayerHeroId")]
        public PlayerHero PlayerHero { get; set; }

        [ForeignKey("LootLevelId")]
        public LootLevel LootLevel { get; set; }
        
    }
}
