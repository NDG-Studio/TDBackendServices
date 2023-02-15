using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class PlayerTableSync
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int TableChangesId { get; set; }
        public DateTimeOffset LastSyncDate { get; set; }=DateTimeOffset.UtcNow;
        
        [ForeignKey("UserId")] public User User { get; set; }
        [ForeignKey("TableChangesId")] public TableChanges TableChanges { get; set; }
    }
}