using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class PlayerBasePlacement
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
        public int BuildingTypeId { get; set; }
        public int BuildingLevel { get; set; }
        public DateTimeOffset? UpdateEndDate { get; set; } = null;
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        [ForeignKey("BuildingTypeId")]
        public BuildingType BuildingType { get; set; }
        
    }
}
