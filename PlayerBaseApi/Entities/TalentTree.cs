using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class TalentTree
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroundUrl { get; set; }
        public string ThemeColor{ get; set; }
    }
}
