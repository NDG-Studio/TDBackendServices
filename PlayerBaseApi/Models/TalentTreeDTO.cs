namespace PlayerBaseApi.Models
{
    public class TalentTreeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroundUrl { get; set; }
        public string ThemeColor { get; set; }
        public List<TalentTreeNodeDTO> NodeList { get; set; }
    }
}
