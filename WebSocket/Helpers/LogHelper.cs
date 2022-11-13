using Microsoft.Extensions.Logging;
using SharedLibrary.Helpers;
using SharedLibrary.Models;

namespace WebSocket.Helpers
{
    public static class LogHelper
    {
        public static void SocketLog(this ILogger logger, string message)
        {
            var newDetail = new InfoDetail();
            newDetail.Ip = "00000";
            newDetail.Action = "__SOCKET__";
            newDetail.AdditionalInfo = string.Empty;
            newDetail.Body = message;
            newDetail.UserId = null;
            newDetail.Created = DateTimeOffset.Now;
            newDetail.DeviceId = "__SOCKET__";
            newDetail.DeviceType = "__SOCKET__";
            newDetail.DeviceModel = "__SOCKET__";
            newDetail.OsVersion = "__SOCKET__";
            newDetail.AppVersion = "__SOCKET__";
            logger.LogInformation(newDetail.ToString());
        }
    }
}
