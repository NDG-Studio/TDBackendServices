﻿using System.ComponentModel.DataAnnotations;
using SharedLibrary.Models;

namespace ProgressApi.Models
{
    public class ProgressDTO
    {
        public List<TowerProgressDTO> TowerProgressList { get; set; } = new List<TowerProgressDTO>();
        public int WaveId { get; set; }
        public int SpentCoin { get; set; }
        public int GainedCoin { get; set; }
        public int TotalCoin { get; set; }
        public double Time { get; set; }
        public int BarrierHealth { get; set; }
        public List<EnemyKillDTO> EnemyKillList { get; set; } = new List<EnemyKillDTO>();
        public List<UserTowerPlaceDTO> TowerPlaceList { get; set; } = new List<UserTowerPlaceDTO>();

    }
}
