using System.ComponentModel.DataAnnotations;

namespace ProgressApi.Entities
{
    public class Enemy
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }
}
