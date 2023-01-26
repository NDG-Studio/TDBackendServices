using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class GateInfo
    {
        [Key]
        public int Id { get; set; }
        public int GateId { get; set; }
        public string? GangId { get; set; }
        public string? GangAvatarId { get; set; } = "";
        public string? GangName { get; set; }
        public string? GangShortName { get; set; }
        public int? TotalTroopCount { get; set; }
        public int? GateStateEnum { get; set; }
        public int PassPricePerUnit { get; set; } = 0;
        public bool IsActive { get; set; } = true;
    }
}