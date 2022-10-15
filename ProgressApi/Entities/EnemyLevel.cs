using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgressApi.Entities
{
    public class EnemyLevel
    {
        [Key]
        public int Id { get; set; }
        public int Level { get; set; }
        public int EnemyId { get; set; }
        public double Health { get; set; }
        public double Armor { get; set; }
        public double Speed { get; set; }
        public int Coin { get; set; }
        public int BarierDamageAmount { get; set; }


        [ForeignKey("EnemyId")]
        public Enemy Enemy { get; set; }
    }
}
