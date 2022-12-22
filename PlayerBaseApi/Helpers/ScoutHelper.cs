
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PlayerBaseApi.Entities;
using PlayerBaseApi.Models;
using SharedLibrary.Models;

namespace PlayerBaseApi;

public class ScoutHelper
{
    public static List<Scout> ScoutList = new List<Scout>();
    public static void Start(ILoggerProvider logger)
    {

        new Thread(new ThreadStart(CheckScout)).Start();
            
    }

    public static void AddScoutList(Scout s)
    {
        ScoutList.Add(s);
        using (var _context = new PlayerBaseContext())
        {
            var ccc = SendScoutInfo(new BaseRequest<ScoutInfoDTO>()
            {
                Data = new ScoutInfoDTO()
                {
                    ArrivedDate = s.ArrivedDate.ToString(),
                    ScoutedData = s.ScoutedData,
                    IsActive = s.IsActive,
                    ComeBackDate = s.ComeBackDate.ToString(),
                    SenderUserId = s.SenderUserId,
                    TargetUserId = s.TargetUserId,
                    SenderUserName = s.SenderUsername,
                    TargetUserName = s.TargetUsername,
                    Id = s.Id,
                    TargetAvatarId = _context.PlayerBaseInfo
                        .Where(l => l.UserId == s.TargetUserId).Select(l => l.AvatarId).FirstOrDefault(),
                    SenderAvatarId = _context.PlayerBaseInfo
                        .Where(l => l.UserId == s.SenderUserId).Select(l => l.AvatarId).FirstOrDefault(),
                },
                Info = new InfoDto()
                {
                    Ip = "",
                    AppVersion = "",
                    DeviceId = "",
                    DeviceModel = "",
                    DeviceType = "",
                    OsVersion = "",
                    UserId = 111
                }
            }).Result;
            Console.WriteLine(ccc.Message+"--");
        }

        
    }
    
    
    
    
    private static void CheckScout()
    {
        using (var _context = new PlayerBaseContext())
        {
            ScoutList = _context.Scout.Where(l => l.IsActive).ToList();
        }

        while (true)
        {
            try
            {
                var now = DateTimeOffset.UtcNow;
                var doneList=ScoutList.Where(l => l.ArrivedDate <= now && l.ScoutedData == null).ToList();
                using (var _context = new PlayerBaseContext())
                {
                    foreach (var s in doneList)
                    {
                        var playerBaseInfo = _context.PlayerBaseInfo.Where(l => l.UserId == s.TargetUserId)
                            .FirstOrDefault();
                        var playerTroop = _context.PlayerTroop.Where(l => l.UserId == s.TargetUserId).FirstOrDefault();
                        var playerBasePlacement = _context.PlayerBasePlacement
                            .Where(l => l.UserId == s.TargetUserId && (l.BuildingTypeId == 3 || l.BuildingTypeId == 10))
                            .ToList();
                        var barracksLevel = playerBasePlacement.Where(l => l.BuildingTypeId == 10)
                            .Select(l => l.BuildingLevel).FirstOrDefault();                    
                        var wallLevel = playerBasePlacement.Where(l => l.BuildingTypeId == 3)
                            .Select(l => l.BuildingLevel).FirstOrDefault();
                        var scoutData = new ScoutedData()
                        {
                            TargetUsername = s.TargetUsername,
                            ScrapCount = playerBaseInfo.Scraps,
                            TargetUserId = playerBaseInfo.UserId,
                            TroopCount = playerTroop.TroopCount,
                            BarracksLevel = barracksLevel,
                            WallLevel = wallLevel,
                            SenderUserId = s.SenderUserId,
                            SenderUsername = s.SenderUsername,
                        };
                        var dbEnt =_context.Scout.Where(l => l.Id == s.Id).FirstOrDefault();
                        if (dbEnt != null)
                        {
                            dbEnt.ScoutedData = JsonConvert.SerializeObject(scoutData);
                            s.ScoutedData = dbEnt.ScoutedData;
                   
                            _context.SaveChanges();
                            var ccc = SendScoutInfo(new BaseRequest<ScoutInfoDTO>()
                            {
                                Data = new ScoutInfoDTO()
                                {
                                    ArrivedDate = dbEnt.ArrivedDate.ToString(),
                                    ScoutedData = dbEnt.ScoutedData,
                                    IsActive = dbEnt.IsActive,
                                    ComeBackDate = dbEnt.ComeBackDate.ToString(),
                                    SenderUserId = dbEnt.SenderUserId,
                                    TargetUserId = dbEnt.TargetUserId,
                                    SenderUserName = dbEnt.SenderUsername,
                                    TargetUserName = dbEnt.TargetUsername,
                                    TargetAvatarId =  _context.PlayerBaseInfo
                                        .Where(l=>l.UserId==dbEnt.TargetUserId).Select(l=>l.AvatarId).FirstOrDefault(),                                    
                                    SenderAvatarId =  _context.PlayerBaseInfo
                                        .Where(l=>l.UserId==dbEnt.SenderUserId).Select(l=>l.AvatarId).FirstOrDefault(),
                                    Id = dbEnt.Id
                                },
                                Info = new InfoDto()
                                {
                                    Ip = "",
                                    AppVersion = "",
                                    DeviceId = "",
                                    DeviceModel = "",
                                    DeviceType = "",
                                    OsVersion = "",
                                    UserId = 111
                                }
                            }).Result;
                            Console.WriteLine("---");
                        }
                    }
                    
                    now=DateTimeOffset.UtcNow;
                    var rmvList= _context.Scout.Where(l=>l.ComeBackDate <= now && l.ScoutedData != null && l.IsActive).ToList();
                    if (rmvList.Count>0)
                    {
                        foreach (var rS in rmvList)
                        {
                            rS.IsActive = false;
                        }
                        _context.SaveChanges();

                    }
                    
                    ScoutList.RemoveAll(l => l.ComeBackDate <= now && l.ScoutedData != null);
                }
                

                Thread.Sleep((int)TimeSpan.FromSeconds(5).TotalMilliseconds);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e.InnerException);
            }
        }
    }
    
    
    
        
    private static async Task<TDResponse> SendScoutInfo(BaseRequest<ScoutInfoDTO> req)
    {
        var handler = new HttpClientHandler();

        handler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) =>
            { return true; }; //TODO: Prodda silinmeli

        using (HttpClient client = new HttpClient(handler))
        {

            var response = client.PostAsync(new Uri( Environment.GetEnvironmentVariable("WebSocketUrl")+ "/api/News/SendScoutNews"),
                new StringContent(JsonConvert.SerializeObject(
                    req
                ), Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<TDResponse>(content);
                return res;
            }
            return null;
        }
    }
}