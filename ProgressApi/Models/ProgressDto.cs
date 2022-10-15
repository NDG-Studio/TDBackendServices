using System.ComponentModel.DataAnnotations;
using SharedLibrary.Models;

namespace ProgressApi.Models
{
    public class ProgressDto
    {
        public List<TowerProgressDto> TowerProgressList { get; set; } = new List<TowerProgressDto>();
        public int StageId { get; set; }
        public int StarCount { get; set; }
        public double Score { get; set; }
        public double ScrapValue { get; set; }
        public double Time { get; set; }
        public string? WaveStartTime { get; set; }
        public double BarrierHealth { get; set; }
        public List<EnemyKillDto> ZombieKillList { get; set; } = new List<EnemyKillDto>();

    }
}
