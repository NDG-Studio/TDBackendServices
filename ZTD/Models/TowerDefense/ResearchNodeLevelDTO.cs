namespace ZTD.Models
{
    public class ResearchNodeLevelDTO
    {
        public int Id { get; set; }
        public int ResearchNodeId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Level { get; set; } = 1;
        public int BluePrintCount { get; set; } = 1;
        public string BuffValue { get; set; } = string.Empty;

        public List<ResearchNodeUpgradeConditionDTO> Conditions { get; set; }
    }
}