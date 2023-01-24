namespace PlayerBaseApi.Models
{
    public class DoneTutorialQuestRequest
    {
        public bool IsClaim { get; set; } = false;
        public int QuestId { get; set; }
    }
}

