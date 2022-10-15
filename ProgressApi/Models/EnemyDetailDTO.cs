namespace ProgressApi.Models
{
    public class EnemyDetailDTO
    {

        public int EnemyLevelId { get; set; }
        public double Health { get; set; }
        public double Armor { get; set; }
        public double Speed { get; set; }
        public int Coin { get; set; }
        public int BarierDamageAmount { get; set; }
    }
}
