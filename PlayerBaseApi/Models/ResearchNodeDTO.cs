namespace PlayerBaseApi.Models
{
    public class ResearchNodeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int PlaceId { get; set; }
        public int BuffId { get; set; }
        public string ThumbnailUrl { get; set; }
        public int CurrentLevel { get; set; }
        public string UpdateEndDate { get; set; }
        public BuffDTO Buff { get; set; }
    }
}
