using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class PlayerTDRewardHistory
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
        public int WaveId { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
