namespace ZTD.Models;

public class AddWavePartRequest
{
    public string P { get; set; }
    public int ChapterOrder { get; set; }
    public int LevelOrder { get; set; }
    public int WaveOrder { get; set; }
    public double IntervalTime { get; set; }
    public int EnemyId { get; set; }
    public int EnemyLevel { get; set; }
    public int Count { get; set; }
    
    public int Difficulty { get; set; } = 1;
}