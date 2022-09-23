using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PlayerBaseApi.Entities
{
    public class LootLevel
    {
        [Key]
        public int Id { get; set; }
        public int ScrapCount { get; set; }
        public int BlueprintCount { get; set; }
        public int GemCount { get; set; }
        public TimeSpan LootDuration { get; set; }
    }
}
