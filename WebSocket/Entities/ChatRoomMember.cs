using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSocket.Entities
{
    public class ChatRoomMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid ChatRoomId { get; set; }
        public long UserId { get; set; }
        public string Username { get; set; }
        public DateTimeOffset LastSeen { get; set; }
        public DateTimeOffset JoinedRoomDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("ChatRoomId")]
        public ChatRoom ChatRoom { get; set; }

    }
}
