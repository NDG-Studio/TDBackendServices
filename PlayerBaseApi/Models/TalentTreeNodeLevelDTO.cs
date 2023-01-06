namespace PlayerBaseApi.Models
{
    public class TalentTreeNodeLevelDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public BuffDTO Buff { get; set; }
    }
}
