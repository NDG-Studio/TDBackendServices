﻿namespace ProgressApi.Models
{
    public class StageStatusDTO
    {
        public int? StageId { get; set; }
        public string StageName { get; set; }
        public string StageCode { get; set; }
        public int StarCount { get; set; }
        public double Score { get; set; }
    }
}
