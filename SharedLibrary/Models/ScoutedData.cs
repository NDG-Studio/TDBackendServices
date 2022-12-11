namespace SharedLibrary.Models
{
    
    public class ScoutedData
    {
        public int TroopCount { get; set; }
        public string TargetUsername { get; set; }
        public long TargetUserId { get; set; }
        public long SenderUserId { get; set; }
        public string SenderUsername { get; set; }
        public int  BarracksLevel { get; set; }
        public int ScrapCount { get; set; }
        public int WallLevel { get; set; }
    }
}