using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class PlayerTutorialQuest
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int TutorialQuestId { get; set; }
        public bool IsDone { get; set; } = false;
        public bool IsClaim { get; set; } = false;

        [ForeignKey("TutorialQuestId")]
        public TutorialQuest TutorialQuest{ get; set; }
    }
}