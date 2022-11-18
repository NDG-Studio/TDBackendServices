using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class TutorialQuestsGift
    {
        [Key]
        public int Id { get; set; }
        public int TutorialQuestId { get; set; } = 1;
        public int ItemId { get; set; } = 1;
        public int Count { get; set; } = 1;
        public bool IsActive { get; set; }=true;
        
        [ForeignKey("ItemId")]
        public Item Item { get; set; }   
        
        [ForeignKey("TutorialQuestId")]
        public TutorialQuest TutorialQuest { get; set; }
    }
}