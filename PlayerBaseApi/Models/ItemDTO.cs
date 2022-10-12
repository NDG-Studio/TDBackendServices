namespace PlayerBaseApi.Models
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ItemTypeName { get; set; }
        public bool? IsConsumable { get; set; }
    }
}
