using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class PlayerTalentTreeNode
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int TalentTreeNodeLevelId { get; set; }
        public int Level { get; set; }

        [ForeignKey("TalentTreeNodeLevelId")]
        public TalentTreeNodeLevel TalentTreeNodeLevel { get; set; }

    }
}
