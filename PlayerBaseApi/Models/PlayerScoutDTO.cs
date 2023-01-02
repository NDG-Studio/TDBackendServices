namespace PlayerBaseApi.Models;

public class PlayerScoutDTO
{
    public int Id { get; set; }
    public long UserId { get; set; }
    public int ScoutLevelId { get; set; }
    public int SpyCount { get; set; }
    public string? TrainingDoneDate { get; set; }
    public int InTrainingCount { get; set; }
    public ScoutLevelDTO ScoutLevel { get; set; }
}