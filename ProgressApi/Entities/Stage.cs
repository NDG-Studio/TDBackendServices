using System.ComponentModel.DataAnnotations;

namespace ProgressApi.Entities
{
    public class Stage
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Username length must be lower than 50 character!")]
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
