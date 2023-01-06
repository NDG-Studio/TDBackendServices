
namespace PlayerBaseApi.Models
{
    public class BuildingUpgradeTimeDTO
    {
        public int Level { get; set; }
        public TimeSpan UpgradeDuration { get; set; }
        public int ScrapCount { get; set; }
        public int Power { get; set; } = 0;
        public int OldPower { get; set; } = 0;
        public string? OldDescription { get; set; } = "";
        public List<BuildingUpgradeConditionDTO> Conditions { get; set; } = new List<BuildingUpgradeConditionDTO>();
    }
}
