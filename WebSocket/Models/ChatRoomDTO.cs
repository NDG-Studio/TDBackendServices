namespace WebSocket.Models
{
    public class ChatRoomDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int ChatRoomTypeId { get; set; }
        public string LastChangeDate { get; set; }
    }
}
