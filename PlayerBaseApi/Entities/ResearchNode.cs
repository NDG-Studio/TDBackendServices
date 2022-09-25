using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class ResearchNode
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int ResearchTableId { get; set; }
        public int PlaceId { get; set; }
        public int BuffId { get; set; }
        public string ThumbnailUrl { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("ResearchTableId")]
        public ResearchTable ResearchTable { get; set; }

        [ForeignKey("BuffId")]
        public Buff Buff { get; set; }
    }
}
