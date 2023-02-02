using System.ComponentModel.DataAnnotations;

namespace ZTD.Entities
{
    public class Tower
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual List<TowerLevel> TowerLevels { get; set; }
    }
}
