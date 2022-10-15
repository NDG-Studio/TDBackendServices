using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgressApi.Entities
{
    public class Wave
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int StageId { get; set; }

        [ForeignKey("StageId")]
        public Stage Stage { get; set; }

    }
}
