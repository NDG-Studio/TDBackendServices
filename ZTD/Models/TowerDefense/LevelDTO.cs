namespace ZTD.Models
{
    public class LevelDTO : LevelInfoDTO
    {
        public int Coin { get; set; }
        public int BarrierHealth { get; set; }
        public int ChapterId { get; set; }
        public List<WaveDTO> Waves { get; set; } = new List<WaveDTO>();
        public List<CreatableTowerDTO> CreatableTowerList { get; set; } = new List<CreatableTowerDTO>();
    }
    
    public class LevelInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderId { get; set; }
        public int UserStar { get; set; }
        public int LevelStarCondition { get; set; }
    }
}
