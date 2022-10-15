namespace ProgressApi.Models
{
    public class WaveDetailDTO
    {
        public int PlaceId { get; set; }
        public double EntryTime { get; set; }
        public double EntryInterval { get; set; }
        public int EntryPoint { get; set; }
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public int EnemyNumber { get; set; }
        public int EnemyLevel { get; set; }

        public EnemyDetailDTO EnemyDetail { get; set; }
    }
}
