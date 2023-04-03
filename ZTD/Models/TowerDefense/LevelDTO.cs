namespace ZTD.Models
{
    public class LevelDTO : LevelInfoDTO
    {
        public int Coin { get; set; }
        public int BarrierHealth { get; set; }
        public int ChapterId { get; set; }
        public List<WaveDTO> Waves { get; set; } = new List<WaveDTO>();
        public List<CreatableTowerDTO> CreatableTowerList { get; set; } = new List<CreatableTowerDTO>();
        public List<LevelChestChanceDTO> LevelChestChances { get; set; } = new List<LevelChestChanceDTO>();
        public List<LevelGiftDTO> LevelGifts { get; set; }
    }
    
    public class LevelInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderId { get; set; }
        public int SceneId { get; set; } = 1;
        public int UserStar { get; set; }
        public int LevelStarCondition { get; set; }
        public int Difficulty { get; set; } = 1;
    }
}
