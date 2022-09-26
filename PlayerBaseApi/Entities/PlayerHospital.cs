using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class PlayerHospital
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int HospitalLevelId { get; set; }
        public int InjuredCount { get; set; }
        public DateTimeOffset? HealingDoneDate { get; set; }
        public int InHealingCount { get; set; }

        [ForeignKey("HospitalLevelId")]
        public HospitalLevel HospitalLevel { get; set; }
    }
}
