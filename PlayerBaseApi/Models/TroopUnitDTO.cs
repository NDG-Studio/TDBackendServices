using PlayerBaseApi.Enums;

namespace PlayerBaseApi.Models
{
    public class TroopUnitDTO
    {
        public long? Id { get; set; } = null;
        public long? TUserId { get; set; }= null;
        public string? TUserName { get; set; }= null;
        public string? Coord { get; set; } = null;
        public int TUserAvatarId { get; set; } = 0;
        public int TroopCount { get; set; } = 0;
        public int? HeroId { get; set; }= null;
        public string? HeroName { get; set; }= null;
        public string? ArrivedDate { get; set; }= null;
        public string? ComebackDate { get; set; }= null;
        public int? TroopType { get; set; } = (int)TroopTypeEnum.Attack;
    }
}
