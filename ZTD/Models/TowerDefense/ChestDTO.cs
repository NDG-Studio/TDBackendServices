
namespace ZTD.Models
{
    public class ChestDTO
    {
        public int Id { get; set; }
        public int ChestTypeId { get; set; }
        public int Rarity { get; set; }
        public int MainItemMinCount { get; set; }
        public int MainItemMaxCount { get; set; }
        public int OtherItemMaxCount { get; set; }
        public int OtherItemMimCount { get; set; }
        public string OpenDuration { get; set; }
        public int InstantOpenGemCount { get; set; }
        
    }
}
