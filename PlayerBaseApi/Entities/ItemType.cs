using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class ItemType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemCategoryId { get; set; }
        public bool IsConsumable { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("ItemCategoryId")]
        public ItemCategory ItemCategory { get; set; }
    }
}
