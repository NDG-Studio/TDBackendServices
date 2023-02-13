namespace ZTD.Models
{
    public class ResearchNodeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlaceId { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; }
        
        public List<ResearchNodeLevelDTO> ResearchNodeLevels { get; set; }
    }
}