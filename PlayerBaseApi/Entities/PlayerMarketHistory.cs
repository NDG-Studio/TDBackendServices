using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class PlayerMarketHistory
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int MarketItemId { get; set; }
        public int Count { get; set; }
        public int BeforeGemCount { get; set; }
        public int AfterGemCount { get; set; }
        public int BeforeScrapCount { get; set; }
        public int AfterScrapCount { get; set; }
        public DateTimeOffset PurchaseDate  { get; set; }

        [ForeignKey("MarketItemId")]
        public MarketItem MarketItem { get; set; }
    }
}
