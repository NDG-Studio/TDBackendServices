namespace ZTD.Models
{
    public class ResearchNodeUpgradeConditionDTO
    {
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


    }
}
