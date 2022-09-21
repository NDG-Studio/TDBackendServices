using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class PlayerTroop
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int TroopCount { get; set; }
    }
}
