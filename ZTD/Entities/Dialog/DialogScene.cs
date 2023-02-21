using System.ComponentModel.DataAnnotations;

namespace ZTD.Entities
{
    public class DialogScene
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public virtual List<Dialog> Dialogs { get; set; } = new List<Dialog>();
    }
}
