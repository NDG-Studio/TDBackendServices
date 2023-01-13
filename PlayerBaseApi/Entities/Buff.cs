using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class Buff
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        #region BUILDING BUFFS

        /// <summary>[usable]
        /// Bina yükseltme işleminin  UpgradeDuration katsayısı
        /// <br/>
        /// <br/>
        /// Not: Default değer BuildingUpgradeTime tablosunda belirlenmektedir
        /// </summary>
        public double BuildingUpgradeDurationMultiplier { get; set; } = 0;

        /// <summary>[usable]
        /// /// Bina yükseltme işleminin  ScrapCount katsayısı
        /// <br/>
        /// <br/>
        /// Not: Default değer BuildingUpgradeTime tablosunda belirlenmektedir
        /// </summary>
        public double BuildingUpgradeCostMultiplier { get; set; } = 0;

        #endregion

        #region LOOT BUFFS

        /// <summary>[usable]
        /// Heronun lootta getirdiği Gemlerin katsayısı 
        /// <br/>
        /// <br/>
        /// Not: Default sayı Gözcü binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double LootGemMultiplier { get; set; } = 0;

        /// <summary>[usable]
        /// Heronun lootta getirdiği BluePrintlerin katsayısı 
        /// <br/>
        /// <br/>
        /// Not: Default sayı Gözcü binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double LootBluePrintMultiplier { get; set; } = 0;

        /// <summary>[usable]
        /// Heronun lootta getirdiği Scraplerin katsayısı 
        /// <br/>
        /// <br/>
        /// Not: Default sayı Gözcü binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double LootScrapMultiplier { get; set; } = 0;

        /// <summary>[notusable]
        /// Heronun lootta getirdiği herşeyin maksimum gelme ihtimaline etkisi
        /// <br/>
        /// <br/>
        /// Not: Default sayı 0.001
        /// </summary>
        public double LootPerfectRunMultiplier { get; set; } = 0;

        /// <summary>[usable]
        /// Heronun lootdan gelme süresi için katsayı 
        /// <br/>
        /// <br/>
        /// Not: Default sayı Gözcü binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double LootDurationMultiplier { get; set; } = 0;

        /// <summary>[notusable]
        /// Heronun lootdan gelirken getirebileceği maksimum resource sayısı
        /// </summary>
        public double LootCapacity { get; set; } = 0;

        #endregion

        #region PRISON BUFFS

        /// <summary>[usable]
        /// Hapishanenin esir kapasitesi için katsayı
        /// <br/>
        /// <br/>
        /// Not: Default sayı Prison binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double PrisonCapacityMultiplier { get; set; } = 0;

        /// <summary>[usable]
        /// Hapishanedeki esirlerin ana bina üretimine etki eden katsayısı
        /// <br/>
        /// <br/>
        /// Not: Default sayı yok gerekirse sonradan eklenebilir
        /// </summary>
        public double PrisonCostMultiplier { get; set; } = 0;

        /// <summary>[usable]
        /// Esirlerin askere dönüşüm süreci için için katsayı
        /// <br/>
        /// <br/>
        /// Not: Default sayı Prison binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double PrisonTrainingDurationMultiplier { get; set; } = 0;

        #endregion

        #region SPY BUFFS

        /// <summary>[usable]
        /// Spy uretimi suresi icin katsayi
        /// </summary>
        public double SpyProductionTimeMultiplier { get; set; } = 0;
        
        /// <summary>
        /// if Spy Faker active this is the multiplier
        /// </summary>
        public double SpyFakerMultiplier { get; set; } = 0;

        /// <summary>[deleted]
        /// if Spy Protection active this prop will be true
        /// </summary>
        public bool SpyProtectionActive { get; set; } = false;

        #endregion

        #region WAR BUFFS
        
        /// <summary>
        /// Savasta hayatta kalan trooplarin scrap tasima capasitesini arttirir
        /// </summary>"
        public double TroopScrapCapacityMultiplier { get; set; } = 0;
        
        /// <summary>
        /// Barracktaki maks asker sayisi (Get Max)
        /// </summary>"
        public double BarrackTroopCapacity { get; set; } = 0;        
        
        /// <summary>
        /// Gang maks member (Get Max)
        /// </summary>"
        public int GangMemberCapacity { get; set; } = 0;

        #endregion

        #region TROOP TRAINING BUFFS

        /// <summary>
        /// Troop Training Per Hour Multiplier
        /// </summary>
        public double TroopTrainingMultiplier { get; set; } = 0;
        
        /// <summary>
        /// Base troop power (Get Max)
        /// </summary>
        public double BaseTroopPower { get; set; } = 0;        

        #endregion


        /// <summary>
        /// Base üretimi için katsayı
        /// </summary>
        public double ScrapProductionSpeedMultiplier { get; set; } = 0;

        /// <summary>
        /// City Shield Duration buff
        /// </summary>
        public bool CityShieldActive { get; set; } = false;
        
        /// <summary>
        /// Auto LootRun Duration buff
        /// </summary>
        public bool AutoLootRunActive { get; set; } = false;

        #region NewParameters

        public double HeroDamageMultiplier { get; set; } = 0; //sadece savas
        public double HeroMarchingSpeedMultiplier { get; set; } = 0; //sadece savas
        public double HeroHpMultiplier { get; set; } = 0; //sadece savas
        public double HeroExpMultiplier { get; set; } = 0; //lootrun,savas,rally,reinforce,defense
        public double TroopDamageMultiplier { get; set; } = 0; //sadece savas
        public double EnemyTroopDamageMultiplier { get; set; } = 0; //sadece savas
        public double TroopDefenseMultiplier { get; set; } = 0; //sadece savas
        public double TroopHpMultiplier { get; set; } = 0; //sadece savas
        //public double TroopAttackSpeed { get; set; } //sadece savas
        public double TroopMarchingSpeedMultiplier { get; set; } = 0; //sadece savas (heronunki ile aynı iş)
        public double LootRunCapacityMultiplier { get; set; } = 0; //maksimumuna % ekle
        public double LootRunDurationMultiplier { get; set; } = 0; //maksimumuna % ekle


        public double SupportUnitTroopCapacity { get; set; } = 0; //support unit (get max)
        public double SupportUnitTroopCapacityMultiplier { get; set; } = 0; //support unit
        public double NeutralUnitCoinMultiplier { get; set; } = 0; //war with neutral
        public double TeleportCostMultiplier { get; set; } = 0; //base
        public double HealingCostMultiplier { get; set; } = 0; //hospital
        public double PrisonerTrainCostMultiplier { get; set; } = 0; //prison
        public double PrisonerExecutionIncomeMultiplier { get; set; } = 0; //prsion
        public double BeingPrisonerMultiplier { get; set; } = 0; //war
        public double GettingPrisonerMultiplier { get; set; } = 0; //war
        public double CityWallDefenseMultiplier { get; set; } = 0; //war
        public double ResearchSpeedMultiplier { get; set; } = 0; //research
        public double ResearchCostMultiplier { get; set; } = 0; //research


        public double AllTowerDamageMultiplier { get; set; } = 0; //td
        public double AllTowerAttackSpeedMultiplier { get; set; } = 0; //td
        public double TowerBuildCostMultiplier { get; set; } = 0; //td
        public double TowerRangeMultiplier { get; set; } = 0; //td
        public double TowerKillCoinMultiplier { get; set; } = 0; //td
        public int? TowerId { get; set; } = null;
        public int? TowerLevel { get; set; } = null;


        #region TalentParameters

        public int TroopHitCount { get; set; } //war AttackChance,DamageDiffrence,DamageDiffrenceNeutral
        public int EveryTroopsHitCount { get; set; } //war AttackChance,DamageDiffrence,DamageDiffrenceNeutral
        public int HeroHitCount { get; set; } //war AttackChance,DamageDiffrence,DamageDiffrenceNeutral
        public double AttackChance { get; set; } = 0; //war TroopHitCount,HeroHitCount,DamageDiffrence,DamageDiffrenceNeutral
        public double TroopBelowHealth { get; set; } = 0; //war,DamageDiffrence,DamageDiffrenceNeutral
        public double HeroBelowHealth { get; set; } = 0; //war,DamageDiffrence,DamageDiffrenceNeutral
        public int DamageDiffrence { get; set; } //war,TroopHitCount,HeroHitCount,AttackChance,TroopBelowHealth
        public int DamageDiffrenceNeutral { get; set; } //war,TroopHitCount,HeroHitCount,AttackChance,TroopBelowHealth
        public double HeroLevelDamageMultiplier { get; set; } = 0; //war only troops level bazlı damage
        
        public double HealChance { get; set; } = 0; //war,HealChanceTroopCount
        public double HealChanceTroopCount { get; set; } = 0; //war,HealChance
        public double HeroSkillUseTroopGainHealth { get; set; } = 0; //war
        public double OtherGangDefenseMultiplier { get; set; } = 0; //war
        public double OtherGangDamageMultiplier { get; set; } = 0; //war
        public double BaseDefenseMultiplier { get; set; } = 0; //war
        public double NeutralDefenseMultiplier { get; set; } = 0; //war
        public double NeutralDamageMultiplier { get; set; } = 0; //war
        public double SkillDamageDefense { get; set; } = 0; //war
        public double SkillDamage { get; set; } = 0; //war HeroBelowHealth
        public string? FirstTimeDamage { get; set; } = null; //war 'second,damagebuff'
        public double CriticDamageChance { get; set; } = 0; //war
        public double CriticDamage { get; set; } = 0; //war
        public double AfterCriticHeal { get; set; } = 0; //war 
        public int AfterActiveSkillImmuneSecond { get; set; } = 0; //war
        public double RallyReturnSpeed { get; set; } = 0; //war
        public double AttackReturnSpeed { get; set; } = 0; //war
        public double AfterBattleHealth { get; set; } = 0; //war
        public double ActiveSkillCooldownDuration { get; set; } = 0; //war
        
        
        
        

        #endregion
        

        #endregion


    }
}
