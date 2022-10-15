using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgressApi.Entities
{
    public class TowerLevel
    {
        [Key]
        public int Id { get; set; }
        public int Level { get; set; }
        public int TowerId { get; set; }
        public double Damage { get; set; }
        public double FireRate { get; set; }
        public int Price { get; set; }
        public int Range { get; set; }


        [ForeignKey("TowerId")]
        public Tower Tower { get; set; }
    }
}
