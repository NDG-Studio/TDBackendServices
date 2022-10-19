namespace PlayerBaseApi.Models
{
    /// <summary>
    /// SpeedUp kullanmak icin olusturulan input classi
    /// </summary>
    public class SpeedUpRequest
    {
        /// <summary>
        /// kullanilacak speedup iteminin idsi
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// kullanilacak sayi
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// kullanilacak islemin ayirt edici idsi bknz:(researchnodeid,buildingtypeid)
        /// </summary>
        public int GenericId { get; set; }
    }
}
