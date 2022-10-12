namespace PlayerBaseApi.Models
{
    public class MarketDTO
    {
        public List<MarketItemDTO> Resources { get; set; }=new List<MarketItemDTO>();
        public List<MarketItemDTO> SpeedUps { get; set; }= new List<MarketItemDTO>();
        public List<MarketItemDTO> Buffs { get; set; } = new List<MarketItemDTO>();
        public List<MarketItemDTO> Others { get; set; } = new List<MarketItemDTO>();
    }
}
