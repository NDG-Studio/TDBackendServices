using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class PlayerTDReward
    {
        [Key]
        public int Id { get; set; }
        public int WaveId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
