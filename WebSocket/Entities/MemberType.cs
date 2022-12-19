using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSocket.Entities
{
    public class MemberType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool CanMemberChangeType { get; set; }=false;
        public bool CanKick { get; set; }=false;
        public bool GateManager { get; set; } = false;
        public bool CanDistributeMoney { get; set; } = false;
        public bool CanAcceptMember { get; set; } = false;
        public bool CanDestroyGang { get; set; } = false;
        public bool CanEditGang { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public Guid GangId { get; set; }

        [ForeignKey("GangId")]
        public Gang Gang { get; set; }



    }
}