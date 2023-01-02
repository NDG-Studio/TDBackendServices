namespace SharedLibrary.Models
{
    public class InteractionsDTO
    {
        public List<AttackInfoDTO> ActiveAttackList { get; set; } = new List<AttackInfoDTO>();
        public List<ScoutInfoDTO> ActiveScoutList { get; set; } = new List<ScoutInfoDTO>();
        public List<RallyDTO> ActiveRallyList { get; set; } = new List<RallyDTO>();
        public List<SupportUnitDTO> ActiveSupportUnitList { get; set; } = new List<SupportUnitDTO>();
    }
}