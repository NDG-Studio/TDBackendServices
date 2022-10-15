using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgressApi.Entities
{
    public class UserTowerPlace
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int WaveId { get; set; }
        public int PlaceId { get; set; }
        public int TowerLevelId { get; set; }
        
        [ForeignKey("TowerLevelId")]
        public TowerLevel TowerLevel { get; set; }
        
        [ForeignKey("WaveId")]
        public Wave Wave{ get; set; }
        
    }
}
