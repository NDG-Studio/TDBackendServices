using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgressApi.Entities
{
    public class ZombieKill
    {
        [Key]
        public long Id { get; set; }
        public long UserProgressId { get; set; }
        public long ZombieId { get; set; }
        public long DeadCount { get; set; }

        [ForeignKey("ZombieId")]
        public Zombie Zombie { get; set; }
        [ForeignKey("UserProgressId")]
        public UserProgress UserProgress { get; set; }
    }
}
