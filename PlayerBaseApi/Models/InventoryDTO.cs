namespace PlayerBaseApi.Models
{
    public class InventoryDTO
    {
        public List<PlayerItemDTO> Resources { get; set; } = new List<PlayerItemDTO>();
        public List<PlayerItemDTO> SpeedUps { get; set; } = new List<PlayerItemDTO>();
        public List<PlayerItemDTO> Buffs { get; set; } = new List<PlayerItemDTO>();
        public List<PlayerItemDTO> Others { get; set; } = new List<PlayerItemDTO>();

    }
}
