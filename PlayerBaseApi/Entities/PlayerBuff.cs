using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class PlayerBuff
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int BuffId { get; set; }
        public DateTimeOffset StartDate{ get; set; }
        public DateTimeOffset EndDate { get; set; }

        [ForeignKey("BuffId")]
        public Buff Buff { get; set; }
    }
}
