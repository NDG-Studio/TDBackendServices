using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class Dialog
    {
        [Key]
        public int Id { get; set; }
        public int HeroId { get; set; }
        public int DialogSceneId { get; set; }
        public string AnimId { get; set; }
        public int PlaceId { get; set; }
        public string Text { get; set; }

        [ForeignKey("DialogSceneId")]
        public DialogScene DialogScene { get; set; }

        [ForeignKey("HeroId")]
        public Hero Hero { get; set; }
    }
}
