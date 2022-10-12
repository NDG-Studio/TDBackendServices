using System.ComponentModel.DataAnnotations;

namespace PlayerBaseApi.Entities
{
    public class DialogScene
    {
        [Key]
        public int Id { get; set; }
        public string DialogSceneCode { get; set; }
    }
}
