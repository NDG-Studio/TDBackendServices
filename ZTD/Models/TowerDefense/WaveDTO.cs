namespace ZTD.Models
{
    public class WaveDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public double EntryTime { get; set; }
        public double EntryInterval { get; set; }
        public int EntryPoint { get; set; }
        
        public List<WavePartDTO> WaveParts { get; set; }
    }
}
