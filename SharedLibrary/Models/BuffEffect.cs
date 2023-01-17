namespace SharedLibrary.Models
{
    public class BuffEffect
    {
    
        #region BUILDING BUFFS

        /// <summary>
        /// Bina yükseltme işleminin  UpgradeDuration katsayısı
        /// <br/>
        /// <br/>
        /// Not: Default değer BuildingUpgradeTime tablosunda belirlenmektedir
        /// </summary>
        public double BuildingUpgradeDurationMultiplier { get; set; } = 0;

        /// <summary>
        /// Bina yükseltme işleminin  ScrapCount katsayısı
        /// <br/>
        /// <br/>
        /// Not: Default değer BuildingUpgradeTime tablosunda belirlenmektedir
        /// </summary>
        public double BuildingUpgradeCostMultiplier { get; set; } = 0;

        #endregion

        #region LOOT BUFFS

        /// <summary>
        /// Heronun lootta getirdiği Gemlerin katsayısı 
        /// <br/>
        /// <br/>
        /// Not: Default sayı Gözcü binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double LootGemMultiplier { get; set; } = 0;

        /// <summary>
        /// Heronun lootta getirdiği BluePrintlerin katsayısı 
        /// <br/>
        /// <br/>
        /// Not: Default sayı Gözcü binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double LootBluePrintMultiplier { get; set; } = 0;

        /// <summary>
        /// Heronun lootta getirdiği Scraplerin katsayısı 
        /// <br/>
        /// <br/>
        /// Not: Default sayı Gözcü binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double LootScrapMultiplier { get; set; } = 0;

        /// <summary>
        /// Heronun lootta getirdiği herşeyin maksimum gelme ihtimaline etkisi
        /// <br/>
        /// <br/>
        /// Not: Default sayı 0.001
        /// </summary>
        public double LootPerfectRunMultiplier { get; set; } = 0;

        /// <summary>
        /// Heronun lootdan gelme süresi için katsayı 
        /// <br/>
        /// <br/>
        /// Not: Default sayı Gözcü binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double LootDurationMultiplier { get; set; } = 0;

        /// <summary>
        /// Heronun lootdan gelirken getirebileceği maksimum resource sayısı
        /// </summary>
        public double LootCapacity { get; set; } = 0;

        #endregion

        #region PRISON BUFFS

        /// <summary>
        /// Hapishanenin esir kapasitesi için katsayı
        /// <br/>
        /// <br/>
        /// Not: Default sayı Prison binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double PrisonCapacityMultiplier { get; set; } = 0;

        /// <summary>
        /// Hapishanedeki esirlerin ana bina üretimine etki eden katsayısı
        /// <br/>
        /// <br/>
        /// Not: Default sayı yok gerekirse sonradan eklenebilir
        /// </summary>
        public double PrisonCostMultiplier { get; set; } = 0;

        /// <summary>
        /// Esirlerin askere dönüşüm süreci için için katsayı
        /// <br/>
        /// <br/>
        /// Not: Default sayı Prison binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double PrisonTrainingDurationMultiplier { get; set; } = 0;

        #endregion

        #region SPY BUFFS

        /// <summary>
        /// Spy uretimi suresi icin katsayi
        /// </summary>
        public double SpyProductionTimeMultiplier { get; set; }
        
        /// <summary>
        /// if Spy Faker active this is the multiplier
        /// </summary>
        public double SpyFakerMultiplier { get; set; } = 0;

        /// <summary>
        /// if Spy Protection active this prop will be true
        /// </summary>
        public bool SpyProtectionActive { get; set; } = false;

        #endregion

        #region WAR BUFFS
        
        /// <summary>
        /// Savasta hayatta kalan trooplarin scrap tasima capasitesini arttirir
        /// </summary>
        public double TroopCapacityMultiplier { get; set; } = 0;

        #endregion

        #region TROOP TRAINING BUFFS

        /// <summary>
        /// Troop Training Per Hour Multiplier
        /// </summary>
        public double TroopTrainingMultiplier { get; set; } = 0;

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

        public double HeroDamageMultiplier { get; set; } //sadece savas
        public double HeroMarchingSpeedMultiplier { get; set; } //sadece savas
        public double HeroHpMultiplier { get; set; } //sadece savas
        public double HeroExpMultiplier { get; set; } //lootrun,savas,rally,reinforce,defense
        public double TroopDamageMultiplier { get; set; } //sadece savas
        public double EnemyTroopDamageMultiplier { get; set; } //sadece savas
        public double TroopDefenseMultiplier { get; set; } //sadece savas
        public double TroopHpMultiplier { get; set; } //sadece savas
        //public double TroopAttackSpeed { get; set; } //sadece savas
        public double TroopMarchingSpeedMultiplier { get; set; } //sadece savas (heronunki ile aynı iş)
        
        public double SupportUnitTroopCapacity { get; set; } = 0; //support unit (get max)
        public int GangMemberCapacity { get; set; } = 0;


        public double SupportUnitTroopCapacityMultiplier { get; set; } //support unit
        public double NeutralUnitCoinMultiplier { get; set; } //war with neutral
        public double TeleportCostMultiplier { get; set; } //base
        public double HealingCostMultiplier { get; set; } //hospital
        public double PrisonerTrainCostMultiplier { get; set; } //prison
        public double PrisonerExecutionIncomeMultiplier { get; set; } //prsion
        public double BeingPrisonerMultiplier { get; set; } //war
        public double GettingPrisonerMultiplier { get; set; } //war
        public double CityWallDefenseMultiplier { get; set; } //war
        public double ResearchSpeedMultiplier { get; set; } //research
        public double ResearchCostMultiplier { get; set; } //research


        public double AllTowerDamageMultiplier { get; set; } //td
        public double AllTowerAttackSpeedMultiplier { get; set; } //td
        public double TowerBuildCostMultiplier { get; set; } //td
        public double TowerRangeMultiplier { get; set; } //td
        public double TowerKillCoinMultiplier { get; set; } //td
        public int TowerId { get; set; } = 0;
        public int TowerLevel { get; set; } = 0;

        public List<TowerLevelPair> TowerLevelPairs { get; set; } = new List<TowerLevelPair>();


        #region TalentParameters

        public int TroopHitCount { get; set; } //war AttackChance,DamageDiffrence,DamageDiffrenceNeutral
        public int EveryTroopsHitCount { get; set; } //war AttackChance,DamageDiffrence,DamageDiffrenceNeutral
        public int HeroHitCount { get; set; } //war AttackChance,DamageDiffrence,DamageDiffrenceNeutral
        public double AttackChance { get; set; } //war TroopHitCount,HeroHitCount,DamageDiffrence,DamageDiffrenceNeutral
        public double TroopBelowHealth { get; set; } //war,DamageDiffrence,DamageDiffrenceNeutral
        public double HeroBelowHealth { get; set; } //war,DamageDiffrence,DamageDiffrenceNeutral
        public int DamageDiffrence { get; set; } //war,TroopHitCount,HeroHitCount,AttackChance,TroopBelowHealth
        public int DamageDiffrenceNeutral { get; set; } //war,TroopHitCount,HeroHitCount,AttackChance,TroopBelowHealth
        public double HeroLevelDamageMultiplier { get; set; } //war only troops level bazlı damage
        
        public double HealChance { get; set; } //war,HealChanceTroopCount
        public double HealChanceTroopCount { get; set; } //war,HealChance
        public double HeroSkillUseTroopGainHealth { get; set; } //war
        public double OtherGangDefenseMultiplier { get; set; } //war
        public double OtherGangDamageMultiplier { get; set; } //war
        public double BaseDefenseMultiplier { get; set; } //war
        public double NeutralDefenseMultiplier { get; set; } //war
        public double NeutralDamageMultiplier { get; set; } //war
        public double SkillDamageDefense { get; set; } //war
        public double SkillDamage { get; set; } //war HeroBelowHealth
        public List<string> FirstTimeDamage { get; set; } = new List<string>(); //war 'second,damagebuff'
        public double CriticDamageChance { get; set; } //war
        public double CriticDamage { get; set; } //war
        public double AfterCriticHeal { get; set; } //war 
        public int AfterActiveSkillImmuneSecond { get; set; } //war
        public double RallyReturnSpeed { get; set; } //war
        public double AttackReturnSpeed { get; set; } //war
        public double AfterBattleHealth { get; set; } //war
        public double ActiveSkillCooldownDuration { get; set; } //war
        
        
        
        

        #endregion
        

        #endregion


    }    
}
