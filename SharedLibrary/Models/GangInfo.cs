namespace SharedLibrary.Models
{
    public class GangInfo
    {
        public Guid Id { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Power { get; set; }
        public GangMemberInfo Owner { get; set; }
        public int Capacity { get; set; }
        public int AvatarId { get; set; } = 0;
        public int MemberCount { get; set; }
        public int GangEntryTypeId { get; set; } 
    }
}