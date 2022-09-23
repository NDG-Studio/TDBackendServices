using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class Buff
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        /// <summary>
        /// Heronun lootta Gem getirme sansı
        /// </summary>
        public double LootGemChance { get; set; } = 0;

        /// <summary>
        /// Heronun lootta BluePrint getirme sansı
        /// </summary>
        public double LootBluePrintChance { get; set; } = 0;

        /// <summary>
        /// Heronun lootta Scrap getirme sansı
        /// </summary>
        public double LootScrapChance { get; set; } = 0;

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
        /// Heronun lootdan gelme süresi için katsayı 
        /// <br/>
        /// <br/>
        /// Not: Default sayı Gözcü binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double LootDurationMultiplier { get; set; } = 0;        
        
        /// <summary>
        /// Heronun lootdan gelme süresi için katsayı 
        /// <br/>
        /// <br/>
        /// Not: Default sayı Gözcü binasının leveline bağlı olarak değişiyor
        /// </summary>
        public double LootCapacity{ get; set; } = 0;

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
    }
}
