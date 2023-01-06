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
        public int Power { get; set; } = 0;
        public string? Description { get; set; } = "";
        public int? BuffId { get; set; } = null;


        [ForeignKey("BuffId")] 
        public Buff? Buff { get; set; } = null;

        [ForeignKey("BuildingTypeId")]
        public BuildingType BuildingType { get; set; }
    }
}
 