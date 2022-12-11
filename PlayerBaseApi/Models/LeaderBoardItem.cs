namespace PlayerBaseApi.Models
{
    public class LeaderBoardItem
    {
        public string Username { get; set; } = "";
        public long UserId { get; set; } = 0;
        public long Value { get; set; } = 0;
        public long OwnRanked { get; set; } = 0;
    }
}

