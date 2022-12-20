using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSocket.Entities;

public class GangApplication
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public long UserId { get; set; }
    public int UserAvatarId { get; set; }
    public string Username { get; set; }
    public string Coordinate { get; set; }
    public string Rank1 { get; set; }
    public string Rank2 { get; set; }
    public string Rank3 { get; set; }
    public string Rank4 { get; set; }
    public Guid GangId { get; set; }
    public DateTimeOffset Date { get; set; }
    
    [ForeignKey("GangId")]
    public Gang Gang { get; set; }
}