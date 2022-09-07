using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MapApi.Entities
{
    public class Area
    {
        [Key]
        public int Id { get; set; }
        public int ZoneId { get; set; }
        public int XMin { get; set; }
        public int XMax { get; set; }
        public int YMin { get; set; }
        public int YMax { get; set; }

        [ForeignKey("ZoneId")]
        public Zone Zone { get; set; }
    }
}
