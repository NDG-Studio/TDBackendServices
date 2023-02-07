using System.ComponentModel.DataAnnotations;

namespace ZTD.Entities
{
    public class Enemy
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual List<EnemyLevel> EnemyLevels { get; set; }

    }
}
