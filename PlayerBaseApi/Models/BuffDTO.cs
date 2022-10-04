namespace PlayerBaseApi.Models
{
    public class BuffDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";



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
        /// Esirlerin askere dönüşümünde kullanılacak kaynak için katsayı
        /// <br/>
        /// <br/>
        /// Not: Default sayı Prison binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double PrisonTrainingCostMultiplier { get; set; } = 0;

        /// <summary>
        /// Esirlerin askere dönüşüm süreci için için katsayı
        /// <br/>
        /// <br/>
        /// Not: Default sayı Prison binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double PrisonTrainingDurationMultiplier { get; set; } = 0;

        /// <summary>
        /// Esirlerin idamında kazanılan kaynaklar için katsayı
        /// <br/>
        /// <br/>
        /// Not: Default sayı Prison binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double PrisonExecutionEarnMultiplier { get; set; } = 0;

        /// <summary>
        /// Base üretimi için katsayı
        /// </summary>
        public double BaseResourceMultiplier { get; set; } = 0;
    }
}
