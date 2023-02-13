namespace ZTD.Models
{
    public class ChestTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        /// <summary>
        /// bknz: ItemTypeEnum
        /// </summary>
        public int MainItemType { get; set; }

        public List<ChestDTO> Chests { get; set; }
    }
}
