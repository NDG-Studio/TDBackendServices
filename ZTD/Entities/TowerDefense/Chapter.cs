using System.ComponentModel.DataAnnotations;

namespace ZTD.Entities
{
    public class Chapter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string OrderId { get; set; } = string.Empty;
        public string SceneId { get; set; } = string.Empty;
        public int TotalStar  { get; set; } = 0;
        public bool IsActive { get; set; }
        public virtual List<Level> Levels { get; set; }
    }
}
