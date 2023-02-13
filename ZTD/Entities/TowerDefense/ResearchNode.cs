using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class ResearchNode
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlaceId { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; }
        
        public virtual List<ResearchNodeLevel> ResearchNodeLevels { get; set; }
    }
}