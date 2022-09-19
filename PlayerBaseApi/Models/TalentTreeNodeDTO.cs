namespace PlayerBaseApi.Models
{
    public class TalentTreeNodeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BuffId { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public int Capacity { get; set; }
        public int CurrentLevel { get; set; }
    }
}
