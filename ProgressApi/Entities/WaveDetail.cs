using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgressApi.Entities
{
    public class WaveDetail
    {
        [Key]
        public int Id { get; set; }
        public int WaveId { get; set; }
        public int PlaceId { get; set; }
        public double EntryTime { get; set; }
        public double EntryInterval { get; set; }
        public int EntryPoint { get; set; }
        public int EnemyId { get; set; }
        public int EnemyNumber { get; set; }
        public int EnemyLevel { get; set; }

        [ForeignKey("EnemyId")]
        public Enemy Enemy { get; set; }        
        
        [ForeignKey("WaveId")]
        public Wave Wave { get; set; }

    }
}
