namespace PlayerBaseApi.Models
{
    public class BuildingUpgradeConditionDTO
    {
        /// <summary>
        /// Yükseltme için olması gereken leveli belirtilen BuildingType'in idsi
        /// <br/>
        /// </summary>
        public int? PrereqBuildingTypeId { get; set; }    
        
        /// <summary>
        /// Yükseltme için olması gereken leveli belirtilen BuildingType'in name'i
        /// <br/>
        /// </summary>
        public int? PrereqBuildingTypeName { get; set; }        

        /// <summary>
        /// PrereqBuildingTypeId de idsi verilen building 'in olması gereken level
        /// </summary>
        public int PrereqLevel { get; set; }
    }
}
