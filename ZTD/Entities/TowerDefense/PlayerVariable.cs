using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class PlayerVariable
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int GemCount { get; set; }
        public int ResearchPoint { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
