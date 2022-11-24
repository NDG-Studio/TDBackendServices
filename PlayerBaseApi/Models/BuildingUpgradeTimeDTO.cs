
namespace PlayerBaseApi.Models
{
    public class BuildingUpgradeTimeDTO
    {
        public int Level { get; set; }
        public TimeSpan UpgradeDuration { get; set; }
        public int ScrapCount { get; set; }
        public List<BuildingUpgradeConditionDTO> Conditions { get; set; } = new List<BuildingUpgradeConditionDTO>();
    }
}
