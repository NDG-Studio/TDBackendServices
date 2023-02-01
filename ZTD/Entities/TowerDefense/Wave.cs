using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class Wave
    {
        [Key]
        public int Id { get; set; }
        public int LevelId { get; set; }
        public int OrderId { get; set; }
        public double EntryTime { get; set; }
        public double EntryInterval { get; set; }
        public int EntryPoint { get; set; }
        
        [ForeignKey("LevelId")]
        public Level Level { get; set; }

        public virtual List<WavePart> WaveParts { get; set; }

    }
}
