using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class BuildingUpdateTime
    {
        [Key]
        public int Id { get; set; }
        public int BuildingTypeId { get; set; }
        public int Level { get; set; }
        public TimeSpan UpdateDuration { get; set; }

        [ForeignKey("BuildingTypeId")]
        public BuildingType BuildingType { get; set; }
    }
}
 