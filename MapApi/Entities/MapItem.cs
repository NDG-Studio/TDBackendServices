using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapApi.Entities
{
    public class MapItem
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public int AreaId { get; set; }
        public int MapItemTypeId { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        [ForeignKey("AreaId")]
        public Area Area { get; set; }

        [ForeignKey("MapItemTypeId")]
        public MapItemType MapItemType { get; set; }
    }
}
