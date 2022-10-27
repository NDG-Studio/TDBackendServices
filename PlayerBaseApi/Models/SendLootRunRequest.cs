namespace PlayerBaseApi.Models
{
    public class SendLootRunRequest
    {
        public int HeroId { get; set; }
        public bool AutoLootRun { get; set; }
    }
}
