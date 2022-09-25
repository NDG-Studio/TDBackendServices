using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PlayerBaseApi.Entities
{
    public class LootLevel
    {
        [Key]
        public int Id { get; set; }
        public int MinScrapCount { get; set; }
        public int MaxScrapCount { get; set; }
        public int MinBlueprintCount { get; set; }
        public int MaxBlueprintCount { get; set; }
        public int MinGemCount { get; set; }
        public int MaxGemCount { get; set; }
        public TimeSpan LootDuration { get; set; }
    }
}
