namespace PlayerBaseApi.Models
{
    public class LootRunPredictionInfo
    {
        public int MinScrapCount { get; set; }
        public double ScrapHeroLevelBonus { get; set; }
        public int MaxScrapCount { get; set; }
        public int MinBluePrintCount { get; set; }
        public double BlueprintDoubleChance { get; set; }
        public int MinGemCount { get; set; }
        public int MaxGemCount { get; set; }
        public TimeSpan LootDuration { get; set; }
    }
}
