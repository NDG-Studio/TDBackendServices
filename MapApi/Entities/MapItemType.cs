using System.ComponentModel.DataAnnotations;

namespace MapApi.Entities
{
    public class MapItemType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
