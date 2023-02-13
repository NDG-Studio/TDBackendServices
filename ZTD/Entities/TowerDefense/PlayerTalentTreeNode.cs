using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#pragma warning disable CS1591
namespace ZTD.Entities
{
    public class PlayerResearchNodeLevel
    {

        [Key] public int Id { get; set; }
        public long UserId { get; set; }
        public int ResearchNodeLevelId { get; set; }
        
        [ForeignKey("ResearchNodeLevelId")] public ResearchNodeLevel ResearchNodeLevel { get; set; } = new ResearchNodeLevel();
        [ForeignKey("UserId")] public User User { get; set; } = new User();
    }
}
