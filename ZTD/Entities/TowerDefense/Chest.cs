using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class Chest
    {
        [Key]
        public int Id { get; set; }
        public int ChestTypeId { get; set; }
        public int Rarity { get; set; }
        public int MainItemMinCount { get; set; }
        public int MainItemMaxCount { get; set; }
        public int OtherItemMaxCount { get; set; }
        public int OtherItemMimCount { get; set; }
        public TimeSpan OpenDuration { get; set; }
        public int InstantOpenGemCount { get; set; }
        public bool IsActive { get; set; } = true;


        [ForeignKey("ChestTypeId")]
        public ChestType ChestType { get; set; }
        
    }
}
