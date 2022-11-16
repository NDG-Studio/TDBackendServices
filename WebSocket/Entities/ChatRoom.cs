using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSocket.Entities
{
    public class ChatRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ChatRoomTypeId { get; set; }//ChatRoomTypeEnum
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LastChangeDate { get; set; }
        public bool IsActive { get; set; }
    }
}
