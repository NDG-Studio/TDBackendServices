namespace ProgressApi.Models
{
    public class UserTDInfoDTO
    {
        public int WaveId { get; set; }
        public StageDTO Stage { get; set; }
        public int WaveOrderId { get; set; }
        public int TotalCoin { get; set; }
        public int BarrierHealth { get; set; }
        public List<UserTowerStatusDTO> UserTowerStatusList { get; set; } = new List<UserTowerStatusDTO>();
        public List<WaveDetailDTO> WaveDetailList { get; set; } = new List<WaveDetailDTO>();
        public List<CreatableTowerDTO> CreatableTowerList { get; set; } = new List<CreatableTowerDTO>();

    }
}
