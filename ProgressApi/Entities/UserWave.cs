using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgressApi.Entities
{
    public class UserWave
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int WaveId { get; set; }
        public int TotalCoin { get; set; }
        public int BarierHealth { get; set; }

        [ForeignKey("WaveId")]
        public Wave Wave { get; set; }
    }
}
