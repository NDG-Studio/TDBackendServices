namespace ZTD.Models
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Value1 { get; set; }
            
        /// <summary>
        /// ItemTypeEnum
        /// </summary>
        public int ItemTypeId { get; set; }
    }
}

