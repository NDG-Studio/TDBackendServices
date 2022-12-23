using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class PlayerBaseInfo
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public string Username { get; set; } = "";        
        public string? Bio { get; set; } = "";        
        public int? AvatarId { get; set; } = 0;
        public int BaseLevel { get; set; } = 1;
        public int Scraps { get; set; } = 0;
        public int Gems { get; set; } = 0;
        public int RareHeroCards { get; set; } = 0;
        public int EpicHeroCards { get; set; } = 0;
        public int LegendaryHeroCards { get; set; } = 0;
        public int BluePrints { get; set; } = 0;
        public int Fuel { get; set; } = 0;
        public int Power { get; set; } = 0;
        public int KillCount { get; set; } = 0;
        public int LootedScrap { get; set; } = 0;
        public int DefenseKillCount { get; set; } = 0;
        public DateTimeOffset LastBaseCollect { get; set; }
        public TimeSpan BaseFullDuration { get; set; }
        public bool IsApe { get; set; } = false;

        /// <summary>
        /// Saatte üretilen resource sayısı
        /// </summary>
        public int ResourceProductionPerHour { get; set; }

    }
}
