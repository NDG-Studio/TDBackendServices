namespace SharedLibrary.Models
{
    public class GangMemberInfo
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string MemberTypeName { get; set; }
        public long Power { get; set; } = 0;
    }
}
