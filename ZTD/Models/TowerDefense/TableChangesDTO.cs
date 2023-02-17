namespace ZTD.Models
{
    public class TableChangesDTO
    {
        public int Id { get; set; }
        public int TableEnum { get; set; }
        public string LastChangeDate { get; set; } = string.Empty;
    }
}