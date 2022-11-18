using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class TutorialQuest
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int StageId { get; set; } = 1;
        public int StageOrderId { get; set; } = 1;
        public bool IsActive { get; set; } = true;
    }
}