namespace ProgressApi.Models
{
    public class CreatableTowerDTO
    {
        public TowerDTO Tower { get; set; }
        public List<TowerLevelDTO> TowerLevelList { get; set; }
    }
}
