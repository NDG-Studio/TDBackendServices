namespace PlayerBaseApi.Models
{
    public class GateInfoDTO
    {
        public int GateId { get; set; }
        public string? GangId { get; set; }
        public string? GangAvatarId { get; set; } = "";
        public string? GangName { get; set; }
        public string? GangShortName { get; set; }
        public int? TotalTroopCount { get; set; }
        public int? GateStateEnum { get; set; }
    }
}

