using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Models
{
    public class LevelChestChanceDTO
    {
        public int Id { get; set; }
        public int ChestId { get; set; }
        public int LevelId { get; set; }
        public int ChanceMultiplier { get; set; }
    }
}
