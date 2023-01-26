using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSocket.Entities;

public class DonationHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public long UserId { get; set; }
    public int ScrapCount { get; set; }
    public Guid GangId { get; set; }
    public DateTimeOffset DonationDate { get; set; }
    public bool IsSuccess { get; set; } = false;
    [ForeignKey("GangId")]
    public Gang Gang { get; set; }
    
}