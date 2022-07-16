
using Newtonsoft.Json;

namespace SharedLibrary.Models
{
    public class InfoDto
    {
        public string? Ip { get; set; } = String.Empty;
        public string DeviceId { get; set; } = String.Empty;
        public long? UserId { get; set; } = 0;
        public string? DeviceType { get; set; }
        public string? DeviceModel { get; set; }
        public string? OsVersion { get; set; }
        public string? AppVersion { get; set; }
        public DateTimeOffset? Created { get; set; }
        public string? AdditionalInfo { get; set; }
        public double? Duration { get; set; }
        public string? Action { get; set; }
        public string? Body { get; set; }

        public InfoDto(string? ip, long? userId, string? deviceId, string? deviceType, string? deviceModel, string? osVersion, string? appVersion, string? additionalInfo)
        {
            Ip = ip ?? "";
            DeviceId = deviceId ?? "";
            UserId = userId ?? 0;
            DeviceType = deviceType;
            DeviceModel = deviceModel;
            OsVersion = osVersion;
            AppVersion = appVersion;
            Created = DateTimeOffset.Now;
            AdditionalInfo = additionalInfo;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.None
            }).ToString();
        }

        public static InfoDto GetFromString(string value)
        {
            var x = JsonConvert.DeserializeObject<InfoDto>(value);
            return x;
        }
    }
}
