using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSocket.Entities
{
    public class GangMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public long UserId { get; set; }
        public Guid MemberTypeId { get; set; }

        
        [ForeignKey("MemberTypeId")]
        public MemberType MemberType { get; set; }



    }
}