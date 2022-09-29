namespace PlayerBaseApi.Models
{
    public class ResearchNodeUpgradeNecessariesDTO
    {
        public int UpgradeLevel { get; set; }
        public TimeSpan Duration { get; set; }
        public int ScrapCount { get; set; }
        public int BluePrintCount { get; set; }
        public List<ResearchNodeUpgradeConditionDTO> ResearchNodeUpgradeConditionList { get; set; }
    }
}
