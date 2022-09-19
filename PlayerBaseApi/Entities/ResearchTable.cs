using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class ResearchTable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }

    }
}
