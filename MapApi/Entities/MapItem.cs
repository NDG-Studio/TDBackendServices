﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapApi.Entities
{
    public class MapItem
    {
        [Key]
        public int Id { get; set; }
        public long? UserId { get; set; } = null;
        public int? GateId { get; set; } = null;
        public string UserName { get; set; }
        public int AreaId { get; set; }
        public int BaseLevel { get; set; } = 1;
        public int MapItemTypeId { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public bool IsApe { get; set; }

        [ForeignKey("AreaId")]
        public Area Area { get; set; }        

        [ForeignKey("MapItemTypeId")]
        public MapItemType MapItemType { get; set; }
        
        [ForeignKey("GateId")]
        public Gate? Gate { get; set; }
    }
}
