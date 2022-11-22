using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class MarketItem
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int MaxCount { get; set; }
        public int GemPrice { get; set; } = 0;
        public int ScrapPrice { get; set; } = 0;
        public int MarketOrderId { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
