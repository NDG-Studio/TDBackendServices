using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class PlayerChest
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int ChestId { get; set; }
        public DateTimeOffset? OpenStartDate { get; set; } = null;
        public DateTimeOffset? OpenFinishDate { get; set; } = null;
        public int UsedGem { get; set; } = 0;
        public string? GainedItems { get; set; } = null;
        public int? SlotPlace { get; set; } = null;
        
        [ForeignKey("ChestId")]
        public Chest Chest { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
