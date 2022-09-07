using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class BuildingType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxLevel { get; set; }
        public bool IsActive { get; set; }
    }
}
