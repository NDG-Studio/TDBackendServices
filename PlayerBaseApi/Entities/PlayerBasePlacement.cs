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
        public double CoordX { get; set; }
        public double CoordY { get; set; }
        //public string GenericCode { get; set; } //Todo:duvar icin model ismi verilecek 

        [ForeignKey("BuildingTypeId")]
        public BuildingType BuildingType { get; set; }
        
    }
}
