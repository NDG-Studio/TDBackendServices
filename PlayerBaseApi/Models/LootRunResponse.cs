namespace PlayerBaseApi.Models
{
    public class LootRunResponse
    {
        public List<PlayerHeroLootDTO> ActiveLootRuns { get; set; } = new List<PlayerHeroLootDTO>();
        public List<LootRunDoneInfoDTO> GainedLootRuns{ get; set; } =new List<LootRunDoneInfoDTO>();
    }
}
