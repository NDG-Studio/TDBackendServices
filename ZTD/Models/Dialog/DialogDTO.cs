namespace ZTD.Models
{
    public class DialogDTO
    {
        public int PlaceId { get; set; }
        public int HeroId { get; set; }
        public string AnimId { get; set; }
        public string TypeName { get; set; }
        public List<string> Texts { get; set; }

    }
}
