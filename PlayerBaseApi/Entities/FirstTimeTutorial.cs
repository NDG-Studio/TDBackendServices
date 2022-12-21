using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerBaseApi.Entities
{
    public class FirstTimeTutorial
    {
        [Key] 
        public int Id { get; set; }
        public long UserId { get; set; }
        public string Action { get; set; }
        public int State { get; set; }
    }
}

