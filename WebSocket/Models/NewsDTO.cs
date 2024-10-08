﻿using Riptide;

namespace WebSocket.Models
{
    public class NewsDTO
    {
        public string Id { get; set; }
        public int TypeId { get; set; }//enum
        public string? Title { get; set; } //all
        public string? Detail { get; set; } //all
        public string? GainedResources { get; set; } //lootrun =>  type of LootRunDoneInfoDTO
        public long? AUserId { get; set; }
        public int? AHeroId { get; set; }
        public string? AHeroName { get; set; }
        public int? ACombatPower { get; set; } 
        public string? AUsername { get; set; }  
        public int? AUserAvatar { get; set; }
        public string? ACoord { get; set; }  
        public string? TCoord { get; set; }
        public string? AGangAvatarId { get; set; } = "";
        public string? AGangId { get; set; }  
        public string? AGangName { get; set; } 
        public string? TGangAvatarId { get; set; } = "";
        public string? TGangId { get; set; } 
        public string? TGangName { get; set; } //-gangname
        public long? TUserId { get; set; } //targetid
        public int? TCombatPower { get; set; } //targetid
        public string? TUsername { get; set; } //-tardgetusername
        public int? TUserAvatar { get; set; }  
        public string? ProcessDate { get; set; } //ProcessDate
        public int? TTroop { get; set; } //troopcount
        public int? TWall { get; set; } //walllevel
        public int? TScrap { get; set; } //scrapcount
        public int? ATroop { get; set; }//totaltroop-attacker-defenser
        public int? AWounded { get; set; } //wounded
        public int? TWounded { get; set; } //wounded
        public int? APrisoner { get; set; } //prisoner
        public int? TPrisoner { get; set; } //prisoner
        public int? ADead { get; set; }//dead
        public int? TDead { get; set; }//dead
        public int? WarLoot { get; set; }//scrap
        public byte? VictorySide { get; set; }//scrap
        public string Date { get; set; }
        public bool? IsCollected { get; set; } //isCollected
        public bool Seen { get; set; }//all
        public bool IsActive { get; set; }//all
    }
}
