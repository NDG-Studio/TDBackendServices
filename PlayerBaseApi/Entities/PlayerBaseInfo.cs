using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class PlayerBaseInfo
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public string Username { get; set; } = "";
        public int BaseLevel { get; set; } = 1;
        public int Scraps { get; set; } = 0;
        public int Gems { get; set; } = 0;
        public int HeroCards { get; set; } = 0;
        public int BluePrints { get; set; } = 0;
        public DateTimeOffset LastBaseCollect { get; set; }

    }
}
