namespace WebSocket.Models
{
    public class NewsDTO
    {
        public int TypeId { get; set; } // enum
        public string? Title { get; set; } //all
        public string? Detail { get; set; } //all
        public int? Casualities { get; set; } //wv,wd,wdv,wdd
        public int? Prisoners { get; set; } //wv,wdv
        public int? Wounded { get; set; }   //wv,wd,wdv,wdd
        public int? LostResource { get; set; } //wd,wdd
        public string? GainedResources { get; set; } //lootrun =>  type of LootRunDoneInfoDTO
        public bool Seen { get; set; }//all
        public string Date { get; set; }//all
    }
}
