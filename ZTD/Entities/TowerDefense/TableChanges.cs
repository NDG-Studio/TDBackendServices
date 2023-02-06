using System.ComponentModel.DataAnnotations;

namespace ZTD.Entities
{
    public class TableChanges
    {
        [Key]
        public int Id { get; set; }
        public string TableName { get; set; }
        public int TableEnum { get; set; }
        public DateTimeOffset LastChangeDate { get; set; }=DateTimeOffset.UtcNow;
    }
}