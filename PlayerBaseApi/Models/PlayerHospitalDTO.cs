namespace PlayerBaseApi.Models
{
    public class PlayerHospitalDTO
    {
        public int InjuredCount { get; set; }
        public string? HealingDoneDate { get; set; }
        public int InHealingCount { get; set; }
        public HospitalLevelDTO HospitalLevel { get; set; }
    }
}
