using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class TalentTreeNodeLevel
    {
        [Key]
        public int Id { get; set; }
        public int TalentTreeNodeId { get; set; }
        public int BuffId { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }

        [ForeignKey("TalentTreeNodeId")]
        public TalentTreeNode TalentTreeNode { get; set; }        
        
        [ForeignKey("BuffId")]
        public Buff Buff { get; set; }
    }
}
