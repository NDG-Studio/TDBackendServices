using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class PlayerResearchNode
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int ResearchNodeId { get; set; }
        public int CurrentLevel { get; set; }
        public DateTimeOffset? UpdateEndDate { get; set; } = null;

        [ForeignKey("ResearchNodeId")]
        public ResearchNode ResearchNode { get; set; }

    }
}
