using System.ComponentModel.DataAnnotations;
using SharedLibrary.Models;

namespace ZTD.Models
{
    public class TowerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TowerLevelDTO> TowerLevels { get; set; }

    }
}
