namespace PlayerBaseApi.Models
{
    public class PlayerTutorialQuestDTO
    {
        public int TutorialQuestId { get; set; }
        public int StageId { get; set; }
        public int StageOrderId { get; set; }
        public bool IsDone { get; set; } = false;
        public bool IsClaim { get; set; } = false;
    }
}
