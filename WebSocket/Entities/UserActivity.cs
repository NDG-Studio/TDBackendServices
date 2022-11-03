using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSocket.Entities
{
    public class UserActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public long UserId { get; set; }
        public DateTimeOffset LastNewsCheck { get; set; }
        public DateTimeOffset LastConnection { get; set; }
        public bool IsConnectedNow { get; set; }
    }
}
