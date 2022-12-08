namespace PlayerBaseApi.Models
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Value1 { get; set; }
        public int? Value2 { get; set; }
        public string? ItemTypeName { get; set; }
        public bool? IsConsumable { get; set; }
    }
}
