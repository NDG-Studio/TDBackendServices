
namespace ZTD.Models
{
    public class PlayerChestDTO
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public int ChestId { get; set; }
        public string? OpenStartDate { get; set; } = null;
        public string? OpenFinishDate { get; set; } = null;
        public int UsedGem { get; set; } = 0;
        public string? GainedItems { get; set; } = null;
        public int? SlotPlace { get; set; } = null;
    }
}
