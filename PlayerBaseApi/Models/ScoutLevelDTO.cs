namespace PlayerBaseApi.Models;

public class ScoutLevelDTO
{
    public int Id { get; set; }
    public int Level { get; set; }
    public TimeSpan TrainingDurationPerUnit { get; set; }
    public double TrainingCostPerUnit { get; set; }
}