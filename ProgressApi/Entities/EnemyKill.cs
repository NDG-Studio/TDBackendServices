using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgressApi.Entities
{
    public class EnemyKill
    {
        [Key]
        public long Id { get; set; }
        public long UserProgressId { get; set; }
        public int EnemyId { get; set; }
        public long DeadCount { get; set; }

        [ForeignKey("EnemyId")]
        public Enemy Enemy { get; set; }

        [ForeignKey("UserProgressId")]
        public UserProgressHistory UserProgress { get; set; }
    }
}
