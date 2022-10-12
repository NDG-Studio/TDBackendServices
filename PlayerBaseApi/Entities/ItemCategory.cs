using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class ItemCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
