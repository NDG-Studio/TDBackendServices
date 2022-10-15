using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgressApi.Entities
{
    public class EnemyKill
    {
        [Key]
        public long Id { get; set; }
        public long UserProgressHistoryId { get; set; }
        public int EnemyLevelId { get; set; }
        public int DeadCount { get; set; }

        [ForeignKey("EnemyLevelId")]
        public EnemyLevel EnemyLevel { get; set; }

        [ForeignKey("UserProgressHistoryId")]
        public UserProgressHistory UserProgressHistory { get; set; }
    }
}
