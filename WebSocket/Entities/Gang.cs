using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSocket.Entities
{
    public class Gang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string ShortName { get; set; } = String.Empty;
        public string Name { get; set; }
        public string Description { get; set; }
        public long OwnerId { get; set; }
        public string OwnerName { get; set; }
        public long ScrapPool { get; set; } = 0;
        /// <summary>
        /// Henuz kullanilmiyor
        /// </summary>
        public int Level { get; set; } = 1;
        public int Capacity { get; set; } = 10;
        public int MemberCount { get; set; } = 10;
        public int RaidCapacity { get; set; } = 3;
        public long Power { get; set; } = 0;
        public bool IsActive { get; set; } = true;



    }
}
