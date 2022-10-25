﻿using System.ComponentModel.DataAnnotations;

namespace MapApi.Entities
{
    public class Gate
    {
        [Key]
        public int Id { get; set; }
        public int TroopCount { get; set; }
        public int GangId { get; set; }
        public int GateStateId { get; set; }
        public int PassPricePerUnit { get; set; }
    }
}
