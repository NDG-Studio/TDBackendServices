namespace PlayerBaseApi.Models
{
    public class UseHeroExperienceRequest
    {
        public int HeroId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public bool Buy { get; set; }=false;
    }
}
