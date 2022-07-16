using System.ComponentModel.DataAnnotations;

namespace IdentityApi.Entities
{
    public class Log
    {
        [Key]
        public long Id { get; set; }
        public string? Ip { get; set; }
        public string? DeviceId { get; set; }
        public string? DeviceType { get; set; }
        public string? DeviceModel { get; set; }
        public string? OsVersion { get; set; }
        public string? AppVersion { get; set; }
        public long? UserId { get; set; }
        public string Values { get; set; } = string.Empty;
        public DateTimeOffset Created { get; set; } = DateTimeOffset.MinValue;
        public string? TimeMs { get; set; }
    }
}