﻿namespace PlayerBaseApi.Models
{
    public class PlayerHeroLootDTO
    {
        public string OperationEndDate { get; set; }
        public string OperationStartDate { get; set; }
        public string AutoLootRunEndDate { get; set; }
        public HeroDTO Hero { get; set; }
    }
}
