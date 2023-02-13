using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class ResearchNodeUpgradeCondition
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Yükseltme için olması gereken leveli belirtilen ResearchNode
        /// <br/>
        /// </summary>
        public int ResearchNodeId { get; set; }

        /// <summary>
        /// ResearchNodeId de idsi verilen node 'un olması gereken level
        /// </summary>
        public int PrereqLevel { get; set; }

        [ForeignKey("ResearchNodeId")]
        public ResearchNode ResearchNode { get; set; }

    }
}
