using Newtonsoft.Json;
using Riptide;

namespace WebSocket.Helpers
{
    public static class MessageExtentions
    {
        public static T GetModel<T>(this Message msg)
        {
            var json = msg.GetString();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void AddModel(this Message msg, object? model)
        {
            msg.AddString(JsonConvert.SerializeObject(model));
        }
    }
}
