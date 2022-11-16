using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSocket.Entities
{
    public class ChatMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid ChatRoomMemberId { get; set; }
        public string Text { get; set; }
        public string Extention { get; set; }
        public int ExtentionTypeId { get; set; }
        public DateTimeOffset SendedDate { get; set; }

        [ForeignKey("ChatRoomMemberId")]
        public ChatRoomMember ChatRoomMember { get; set; }
    }
}
