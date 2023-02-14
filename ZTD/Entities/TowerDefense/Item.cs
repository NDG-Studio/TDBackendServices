using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Value1 { get; set; }
        /// <summary>
        /// ItemTypeEnum
        /// </summary>
        public int ItemTypeId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
