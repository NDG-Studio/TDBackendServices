using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class PlayerItem
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
