using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace SharedLibrary.Models.Loot
{
    public class LootRunDoneInfoDTO
    {
        public int ScrapCount { get; set; }
        public int BluePrintCount { get; set; }
        public int GemCount { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }


/// <summary>
/// Return Json Serialized object
/// </summary>
/// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }


    }
}
