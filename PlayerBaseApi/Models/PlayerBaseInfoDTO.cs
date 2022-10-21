namespace PlayerBaseApi.Models
{
    public class PlayerBaseInfoDTO
    {
        public long UserId { get; set; }
        public string Username { get; set; } = "";
        public int BaseLevel { get; set; } = 1;
        public int Scraps { get; set; } = 0;
        public int Gems { get; set; } = 0;
        public int Fuel { get; set; } = 0;
        public int RareHeroCards { get; set; } = 0;
        public int EpicHeroCards { get; set; } = 0;
        public int LegendaryHeroCards { get; set; } = 0;
        public int BluePrints { get; set; } = 0;
        public string LastBaseCollect { get; set; } = "";
    }
}
