using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class BaseRequest<T>
    {
        public T? Data { get; set; } = default;
        public InfoDto? Info { get; set; } = null;

        public void SetInfo(string action)
        {
            if (Info == null)
            {
                return;
            }
            Info.Action = action;
            Info.AdditionalInfo = string.Empty;
            Info.Body = JsonConvert.SerializeObject(Data, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.None
            }).ToString();
            Info.Created = DateTimeOffset.Now;
        }

        public void SetUser(long? userId)
        {
            if (Info == null)
            {
                return;
            }
            Info.UserId = userId;
        }

        public void AddInfo(string exInfo)
        {
            if (Info == null)
            {
                return;
            }
            if (Info.AdditionalInfo==null)
            {
                Info.AdditionalInfo = string.Empty;
            }
            Info.AdditionalInfo += "\n --"+ exInfo;
        }

    }
}
