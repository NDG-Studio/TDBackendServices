namespace PlayerBaseApi.Models
{
    public class PlayerPrisonDTO
    {
        public int PrisonerCount { get; set; }
        public string? TrainingDoneDate { get; set; }
        public int InTrainingPrisonerCount { get; set; }
        public PrisonLevelDTO PrisonLevel { get; set; }

    }
}
