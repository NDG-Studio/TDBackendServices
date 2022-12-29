namespace PlayerBaseApi.Models
{
    public class PlayerTroopInfoDTO
    {
        public int TroopCount { get; set; } = 0;
        // public List<TroopUnitDTO> InsideTroops { get; set; } = new List<TroopUnitDTO>();
        public int TrainingPerHour { get; set; } = 100;
        public TimeSpan MaxDuration { get; set; } = TimeSpan.FromHours(12);
        public string? LastTroopCollect { get; set; }
        public int? OutsideTroops { get; set; } = 0;
        // public List<TroopUnitDTO> OutSideTroops { get; set; } = new List<TroopUnitDTO>();
    }    
    public class PlayerTroopInfoDTOv2
    {
        public List<TroopUnitDTO> InsideTroops { get; set; } = new List<TroopUnitDTO>();
        public int TrainingPerHour { get; set; } = 100;
        public TimeSpan MaxDuration { get; set; } = TimeSpan.FromHours(12);
        public string? LastTroopCollect { get; set; }
        public int TroopCount { get; set; } = 0;
        public List<TroopUnitDTO> OutSideTroops { get; set; } = new List<TroopUnitDTO>();
    }
}
