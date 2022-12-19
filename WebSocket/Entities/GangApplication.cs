using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSocket.Entities;

public class GangApplication
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public long UserId { get; set; }
    public Guid GangId { get; set; }
    public DateTimeOffset Date { get; set; }
    
    [ForeignKey("GangId")]
    public Gang Gang { get; set; }
}