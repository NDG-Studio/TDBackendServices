using System.ComponentModel.DataAnnotations;

namespace MapApi.Entities
{
    public class Zone
    {
        [Key]
        public int Id { get; set; }
        public int XMin { get; set; }
        public int XMax { get; set; }
        public int YMin { get; set; }
        public int YMax { get; set; }
    }
}
