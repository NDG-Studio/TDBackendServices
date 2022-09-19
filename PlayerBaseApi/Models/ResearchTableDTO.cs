namespace PlayerBaseApi.Models
{
    public class ResearchTableDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }
        public List<ResearchNodeDTO> Nodes { get; set; }
    }
}
