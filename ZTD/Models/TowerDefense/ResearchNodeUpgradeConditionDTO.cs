namespace ZTD.Models
{
    public class ResearchNodeUpgradeConditionDTO
    {
        public int Id { get; set; }

        /// <summary>
        /// Condition bilgisi verilen researchnodelevel
        /// <br/>
        /// </summary>
        public int ResearchNodeLevelId { get; set; }

        /// <summary>
        /// Yükseltme için olması gereken leveli belirtilen ResearchNode
        /// <br/>
        /// </summary>
        public int PrereqResearchNodeId { get; set; }
        
        /// <summary>
        /// ResearchNodeId de idsi verilen node 'un olması gereken level
        /// </summary>
        public int PrereqLevel { get; set; }


    }
}
