namespace PlayerBaseApi.Models
{
    public class BuildingUpgradeTimeDTO
    {
        public int Level { get; set; }
        public TimeSpan UpgradeDuration { get; set; }
        public int ScrapCount { get; set; }
    }
}
