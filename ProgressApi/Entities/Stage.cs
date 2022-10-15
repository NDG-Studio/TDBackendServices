using System.ComponentModel.DataAnnotations;

namespace ProgressApi.Entities
{
    public class Stage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string SceneId { get; set; } = string.Empty;
        public int Coin { get; set; }
        public bool IsActive { get; set; }
    }
}
