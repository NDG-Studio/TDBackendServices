using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class PlayerTalentTreeNode
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int TalentTreeNodeId { get; set; }
        public int Level { get; set; }

        [ForeignKey("TalentTreeNodeId")]
        public TalentTreeNode TalentTreeNode { get; set; }

    }
}
