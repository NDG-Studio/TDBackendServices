namespace SharedLibrary.Models;

public class ScoutInfoDTO
{
        public long Id { get; set; }
        public long SenderUserId { get; set; }
        public string? SenderUserName { get; set; }
        public long TargetUserId { get; set; }
        public string? TargetUserName { get; set; }

        public string? ArrivedDate { get; set; } = null;
        public string? ComeBackDate { get; set; } = null;
        public string? ScoutedData { get; set; } = null;
        public bool IsActive { get; set; } = true;
}

