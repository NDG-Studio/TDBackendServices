using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class Hero
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Story { get; set; }
        public string ThumbnailUrl { get; set; }
        public string BackgroundPictureUrl { get; set; }
        public string ThemeColor { get; set; }
        public int MaxLevel { get; set; }
        public bool IsApe { get; set; }
        public bool IsActive { get; set; }
    }
}
