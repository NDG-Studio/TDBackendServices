namespace SharedLibrary.Models
{
    public class InteractionsDTO
    {
        public List<AttackInfoDTO> ActiveAttackList { get; set; } = new List<AttackInfoDTO>();
        public List<ScoutInfoDTO> ActiveScoutList { get; set; } = new List<ScoutInfoDTO>();
    }
}