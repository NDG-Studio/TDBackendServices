using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityApi.Entities
{
    public class UserToken
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Token { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
