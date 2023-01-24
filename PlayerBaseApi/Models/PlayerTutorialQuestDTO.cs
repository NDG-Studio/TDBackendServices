namespace PlayerBaseApi.Models
{
    public class PlayerTutorialQuestDTO
    {
        public int Id { get; set; }
        public string TutorialQuestName { get; set; }
        public int OrderId { get; set; }
        public bool IsDone { get; set; } = false;
        public bool IsClaim { get; set; } = false;
        public int? ParentId { get; set; } = null;


        public List<TutorialQuestGiftDTO> GiftList { get; set; }
    }
}
