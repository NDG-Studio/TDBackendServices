using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PlayerBaseApi.Entities;
using PlayerBaseApi.Enums;
using SharedLibrary.Enums;
using SharedLibrary.Helpers;
using SharedLibrary.Models;

namespace PlayerBaseApi.Helpers;

public class SupportUnitHelper
{
    public static List<SupportUnit> SupportUnitList = new List<SupportUnit>();
    public static void Start(ILoggerProvider logger)
    {
         new Thread(new ThreadStart(CheckSupportUnit)).Start();
            
    }
    
    
    public static void NewSupport(SupportUnit supU)
    {
        SupportUnitList.Add(supU);
        using (var _context = new PlayerBaseContext())
        {
            var ccc = SendSupportNews(new BaseRequest<SupportUnitDTO>()
            {
                Data = new SupportUnitDTO()
                {
                    IsActive = supU.IsActive,
                    ComeBackDate = supU.ComeBackDate.ToString(),
                    HostUsername = supU.HostUsername,
                    Id = supU.Id,
                    HostAvatarId = supU.HostAvatarId,
                    State = supU.State,
                    Wounded = supU.Wounded,
                    ArrivedDate = supU.ArrivedDate.ToString(),
                    TroopCount = supU.TroopCount,
                    Dead = supU.Dead,
                    ClientUserId = supU.ClientUserId,
                    ClientCoord = supU.ClientCoord??"",
                    ClientAvatarId = supU.ClientAvatarId,
                    HostCoord = supU.HostCoord??"",
                    ClientUsername = supU.ClientUsername,
                    HeroId = supU.HeroId,
                    HeroName = supU.HeroName,
                    SendedDate = supU.SendedDate.ToString(),
                    HostUserId = supU.HostUserId
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
        }

    }

    public static void ComebackSupport(SupportUnit supU)
    {
        var tmp=SupportUnitList.Where(l => l.Id == supU.Id).FirstOrDefault();
        if (tmp!=null)
        {
            SupportUnitList.Remove(tmp);
        }
        SupportUnitList.Add(supU);
        using (var _context = new PlayerBaseContext())
        {
            var ccc = SendSupportNews(new BaseRequest<SupportUnitDTO>()
            {
                Data = new SupportUnitDTO()
                {
                    IsActive = supU.IsActive,
                    ComeBackDate = supU.ComeBackDate.ToString(),
                    HostUsername = supU.HostUsername,
                    Id = supU.Id,
                    HostAvatarId = supU.HostAvatarId,
                    State = supU.State,
                    Wounded = supU.Wounded,
                    ArrivedDate = supU.ArrivedDate.ToString(),
                    TroopCount = supU.TroopCount,
                    Dead = supU.Dead,
                    ClientUserId = supU.ClientUserId,
                    ClientCoord = supU.ClientCoord??"",
                    ClientAvatarId = supU.ClientAvatarId,
                    HostCoord = supU.HostCoord??"",
                    ClientUsername = supU.ClientUsername,
                    HeroId = supU.HeroId,
                    HeroName = supU.HeroName,
                    SendedDate = supU.SendedDate.ToString(),
                    HostUserId = supU.HostUserId
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
        }
    }
    
    
    
    private static void CheckSupportUnit()
    {
        using (var _context = new PlayerBaseContext())
        {
            SupportUnitList = _context.SupportUnit.Where(l => l.IsActive && l.State!=(int)SupportUnitState.Stay).ToList();
        }

        while (true)
        {
            try
            {
                var now = DateTimeOffset.UtcNow;
                var doneList=SupportUnitList.Where(l =>l.ArrivedDate <= now && l.ComeBackDate==null).ToList();
                using (var _context = new PlayerBaseContext())
                {
                    foreach (var s in doneList)
                    {
                        try
                        {
                            #region SUPPORT ALGORITHM
                            var dbEnt =_context.SupportUnit.Where(l => l.Id == s.Id).FirstOrDefault();
                            if (dbEnt != null)
                            {
                                dbEnt.State = (int)SupportUnitState.Stay;
                                _context.SaveChanges();
                            }
                            #endregion
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    SupportUnitList.RemoveAll(l => l.ArrivedDate <= now);
                    
                    now=DateTimeOffset.UtcNow;
                    var rmvList= _context.SupportUnit.Where(l=>l.ComeBackDate <= now && l.IsActive && l.ComeBackDate != null).ToList();
                    if (rmvList.Count>0)
                    {
                        foreach (var s in rmvList)
                        {
                            var dbEnt =_context.SupportUnit.Where(l => l.Id == s.Id).FirstOrDefault();
                            if (dbEnt != null)
                            {
                                dbEnt.State = (int)SupportUnitState.Stay;
                                dbEnt.IsActive = false;
                                var _AplayerTroop = _context.PlayerTroop.Where(l => l.UserId == s.ClientUserId).FirstOrDefault();
                                var _APlayerHospital = _context.PlayerHospital.Include(l=>l.HospitalLevel).Where(l => l.UserId == s.ClientUserId).FirstOrDefault();
                                _AplayerTroop.TroopCount += dbEnt.TroopCount;
                                _APlayerHospital.InjuredCount += dbEnt.Wounded;
                                _context.SaveChanges();
                            }
                        }
                    }
                    
                    SupportUnitList.RemoveAll(l => l.ComeBackDate <= now);
                }
                
                Thread.Sleep((int)TimeSpan.FromSeconds(5).TotalMilliseconds);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
    
    
    
        
        
    private static async Task<TDResponse> SendSupportNews(BaseRequest<SupportUnitDTO> req)
    {
        var handler = new HttpClientHandler();

        handler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) =>
            { return true; }; //TODO: Prodda silinmeli

        using (HttpClient client = new HttpClient(handler))
        {

            var response = client.PostAsync(new Uri( Environment.GetEnvironmentVariable("WebSocketUrl")+ "/api/News/SendSupportNews"),
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