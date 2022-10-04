using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class BuildingUpgradeTime
    {
        [Key]
        public int Id { get; set; }
        public int BuildingTypeId { get; set; }
        public int Level { get; set; }
        public TimeSpan UpgradeDuration { get; set; }
        public int ScrapCount { get; set; }

        [ForeignKey("BuildingTypeId")]
        public BuildingType BuildingType { get; set; }
    }
}
 