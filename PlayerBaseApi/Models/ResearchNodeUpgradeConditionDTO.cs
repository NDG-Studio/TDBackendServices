namespace PlayerBaseApi.Models
{
    public class ResearchNodeUpgradeConditionDTO
    {
        /// <summary>
        /// Yükseltme için olması gereken leveli belirtilen ResearchNode
        /// <br/>
        /// Not: ResearchNodeId null değilse BuildingTypeId null olmalı
        /// </summary>
        public string? ResearchNodeName { get; set; }
        /// <summary>
        /// Yükseltme için olması gereken leveli belirtilen BuildingType
        /// <br/>
        /// Not: BuildingTypeId null değilse ResearchNodeId null olmalı
        /// </summary>
        public string? BuildingTypeName { get; set; }

        /// <summary>
        /// Condition ile alakalı görsel
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// ResearchNodeId / BuildingTypeId de idsi verilen node/building 'in olması gereken level
        /// </summary>
        public int PrereqLevel { get; set; }
    }
}
