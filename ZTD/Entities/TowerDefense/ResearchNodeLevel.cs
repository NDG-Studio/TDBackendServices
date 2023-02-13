using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class ResearchNodeLevel
    {
        [Key]
        public int Id { get; set; }
        public int ResearchNodeId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Level { get; set; } = 1;
        public int BluePrintCount { get; set; } = 1;
        public string BuffValue { get; set; } = string.Empty;

        [ForeignKey("ResearchNodeId")]
        public ResearchNode ResearchNode { get; set; }

        public virtual List<ResearchNodeUpgradeCondition> Conditions { get; set; }
    }
}