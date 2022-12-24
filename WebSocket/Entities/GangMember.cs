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
        public string UserName { get; set; }
        public long Power { get; set; } = 0;
        public Guid MemberTypeId { get; set; }
        public bool IsActive { get; set; } = true;


        [ForeignKey("MemberTypeId")]
        public MemberType MemberType { get; set; }



    }
}