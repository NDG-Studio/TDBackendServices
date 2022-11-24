using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class BuildingUpgradeCondition
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Yukseltilecek binanin idsi
        /// <br/>
        /// </summary>
        public int? BuildingId { get; set; }

        /// <summary>
        /// Kosulun ait oldugu bina leveli
        /// <br/>
        /// </summary>
        public int? BuildingLevel { get; set; }

        /// <summary>
        /// Yükseltme için olması gereken leveli belirtilen BuildingType
        /// <br/>
        /// </summary>
        public int? PrereqBuildingTypeId { get; set; }

        /// <summary>
        /// PrereqBuildingTypeId de idsi verilen building 'in olması gereken level
        /// </summary>
        public int PrereqLevel { get; set; }

        [ForeignKey("BuildingId")]
        public BuildingType? BuildingType { get; set; }

        [ForeignKey("PrereqBuildingTypeId")]
        public BuildingType? PrereqBuildingType { get; set; }

    }
}
