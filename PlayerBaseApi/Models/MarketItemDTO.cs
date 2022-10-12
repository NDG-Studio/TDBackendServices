namespace PlayerBaseApi.Models
{
    public class MarketItemDTO
    {
        public int Id { get; set; }
        public int MaxCount { get; set; }=0;
        public int GemPrice { get; set; } = 0;
        public int ScrapPrice { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public ItemDTO Item { get; set; }
    }
}
