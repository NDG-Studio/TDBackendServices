using PlayerBaseApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Models
{
    public class PlayerItemDTO
    {
        public ItemDTO Item { get; set; }
        public int Count { get; set; }
    }
}
