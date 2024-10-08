﻿using System.ComponentModel.DataAnnotations;
using SharedLibrary.Models;

namespace ZTD.Models
{
    public class ProgressDTO
    {
        public List<TowerProgressDTO> TowerProgressList { get; set; } = new List<TowerProgressDTO>();
        public int LevelId { get; set; }
        public int SpentCoin { get; set; }
        public int GainedCoin { get; set; }
        public int TotalCoin { get; set; }
        public int StarCount { get; set; }
        public double TimeSecond { get; set; }
        public string WaveStartTime { get; set; }
        public int BarrierHealth { get; set; }
        public List<EnemyKillDTO> EnemyKillList { get; set; } = new List<EnemyKillDTO>();
    }
}
