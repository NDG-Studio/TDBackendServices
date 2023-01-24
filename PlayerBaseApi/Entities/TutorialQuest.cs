using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class TutorialQuest
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderId { get; set; } = 1;
        public int? ParentId { get; set; } = null;
        
        public bool IsActive { get; set; } = true;
        
        [ForeignKey("ParentId")]
        public TutorialQuest? Parent { get; set; }
    }
}