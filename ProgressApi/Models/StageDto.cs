using System.ComponentModel.DataAnnotations;
using SharedLibrary.Models;

namespace ProgressApi.Models
{
    public class StageDTO
    {
        public string Name { get; set; }
        public int OrderId { get; set; }
        public string SceneId { get; set; } = string.Empty;

    }
}
