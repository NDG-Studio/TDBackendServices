using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class UserTowerPlaceHistory
    {
        [Key]
        public int Id { get; set; }
        public long UserProgressHistoryId { get; set; }
        public int PlaceId { get; set; }
        public int TowerLevelId { get; set; }
        
        [ForeignKey("TowerLevelId")]
        public TowerLevel TowerLevel { get; set; }
        
        [ForeignKey("UserProgressHistoryId")]
        public UserProgressHistory UserProgressHistory { get; set; }
        
    }
}