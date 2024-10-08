namespace SharedLibrary.Models;

public class ScoutInfoDTO
{
        public long Id { get; set; }
        public long SenderUserId { get; set; }
        public int? SenderAvatarId { get; set; } = 0;
        public int? TargetAvatarId { get; set; } = 0;
        public string? SenderUserName { get; set; }
        public long TargetUserId { get; set; }
        public string? TargetUserName { get; set; }

        public string? ArrivedDate { get; set; } = null;
        public string? ComeBackDate { get; set; } = null;
        public string? ScoutedData { get; set; } = null;
        public int AttackerSpyCount { get; set; } = 0;
        public int DefenserSpyCount { get; set; } = 0;
        public int DefenserDeadSpyCount { get; set; } = 0;
        public int AttackerDeadSpyCount { get; set; } = 0;
        public bool IsActive { get; set; } = true;
}

