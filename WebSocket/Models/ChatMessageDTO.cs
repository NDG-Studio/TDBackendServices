namespace WebSocket.Models
{
    public class ChatMessageDTO
    {
        public string Id { get; set; }
        public long SenderUserId { get; set; }
        public string SenderUsername { get; set; }
        public string SenderIsActive { get; set; }
        public string Text { get; set; }
        public string Extention { get; set; }
        public int ExtentionTypeId { get; set; }
        public DateTimeOffset SendedDate { get; set; }
    }
}
