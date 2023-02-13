using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class ChestType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        /// <summary>
        /// bknz: ItemTypeEnum
        /// </summary>
        public int MainItemType { get; set; }
        public bool IsActive { get; set; } = true;


        public virtual List<Chest> Chests { get; set; }
    }
}
