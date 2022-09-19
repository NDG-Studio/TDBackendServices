using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PlayerBaseApi.Entities
{
    public class ResearchNodeUpgradeNecessaries
    {
        [Key]
        public int Id { get; set; }
        public int ResearchNodeId { get; set; }
        public int UpgradeLevel { get; set; }
        public TimeSpan Duration { get; set; }
        public int ScrapCount { get; set; }
        public int BluePrintCount { get; set; }

        [ForeignKey("ResearchNodeId")]
        public ResearchNode ResearchNode { get; set; }
    }
}
