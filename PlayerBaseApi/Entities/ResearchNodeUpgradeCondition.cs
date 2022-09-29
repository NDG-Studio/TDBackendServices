using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class ResearchNodeUpgradeCondition
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Conditionın geçerli olduğu seviyeye ve nodea ulaşmak için property
        /// </summary>
        public int ResearchNodeUpgradeNecessariesId { get; set; }

        /// <summary>
        /// Yükseltme için olması gereken leveli belirtilen ResearchNode
        /// <br/>
        /// Not: ResearchNodeId null değilse BuildingTypeId null olmalı
        /// </summary>
        public int? ResearchNodeId { get; set; }

        /// <summary>
        /// Yükseltme için olması gereken leveli belirtilen BuildingType
        /// <br/>
        /// Not: BuildingTypeId null değilse ResearchNodeId null olmalı
        /// </summary>
        public int? BuildingTypeId { get; set; }

        /// <summary>
        /// ResearchNodeId / BuildingTypeId de idsi verilen node/building 'in olması gereken level
        /// </summary>
        public int PrereqLevel { get; set; }

        [ForeignKey("ResearchNodeUpgradeNecessariesId")]
        public ResearchNodeUpgradeNecessaries ResearchNodeUpgradeNecessaries { get; set; }

        [ForeignKey("BuildingTypeId")]
        public BuildingType? BuildingType { get; set; }

        [ForeignKey("ResearchNodeId")]
        public ResearchNode? ResearchNode { get; set; }

    }
}
