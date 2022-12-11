using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PlayerBaseApi.Entities;
using SharedLibrary.Enums;
using SharedLibrary.Models;

namespace PlayerBaseApi.Helpers;

public class AttackHelper
{
    public static List<Attack> AttackList = new List<Attack>();
    public static void Start(ILoggerProvider logger)
    {

         new Thread(new ThreadStart(CheckAttack)).Start();
            
    }
    
    
    public static void NewAttack(Attack attack)
    {
        AttackList.Add(attack);
        using (var _context = new PlayerBaseContext())
        {
            var ccc = SendAttackInfo(new BaseRequest<AttackInfoDTO>()
            {
                Data = new AttackInfoDTO()
                {
                    IsActive = attack.IsActive,
                    ComeBackDate = attack.ComeBackDate.ToString(),
                    Id = attack.Id,
                    ArriveDate = attack.ArriveDate.ToString(),
                    ResultData = attack.ResultData,
                    WinnerSide = attack.WinnerSide,
                    AttackerHeroId = attack.AttackerHeroId,
                    AttackerTroopCount = attack.AttackerTroopCount,
                    AttackerUserId = attack.AttackerUserId,
                    DefenserUserId = attack.TargetUserId,
                    AttackerUsername = _context.PlayerBaseInfo.Where(l=>l.UserId==attack.AttackerUserId)
                        .Select(l=>l.Username).FirstOrDefault()??"",
                    DefenserUsername = _context.PlayerBaseInfo.Where(l=>l.UserId==attack.TargetUserId)
                        .Select(l=>l.Username).FirstOrDefault()??"",

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

    public static void AddAttackDetail()
    {
        
        
    }
    
    
    
    private static void CheckAttack()
    {
        using (var _context = new PlayerBaseContext())
        {
            AttackList = _context.Attack.Where(l => l.IsActive).ToList();
        }

        while (true)
        {
            try
            {
                var now = DateTimeOffset.UtcNow;
                var doneList=AttackList.Where(l =>l.ArriveDate <= now && l.ResultData==null && l.IsActive).ToList();
                using (var _context = new PlayerBaseContext())
                {
                    foreach (var s in doneList)
                    {
                        try
                        {
                            #region ATTACK ALGORITHM

                            var playerBaseInfo = _context.PlayerBaseInfo.Where(l => l.UserId == s.TargetUserId)
                                .FirstOrDefault();
                            var playerTroop = _context.PlayerTroop.Where(l => l.UserId == s.TargetUserId).FirstOrDefault();
                            var targetPlayerHospital = _context.PlayerHospital.Include(l=>l.HospitalLevel).Where(l => l.UserId == s.TargetUserId).FirstOrDefault();
                            var playerBasePlacement = _context.PlayerBasePlacement
                                .Where(l => l.UserId == s.TargetUserId && (l.BuildingTypeId == 3 || l.BuildingTypeId == 10))
                                .ToList();
                            var barracksLevel = playerBasePlacement.Where(l => l.BuildingTypeId == 10)
                                .Select(l => l.BuildingLevel).FirstOrDefault();                    
                            var wallLevel = playerBasePlacement.Where(l => l.BuildingTypeId == 3)
                                .Select(l => l.BuildingLevel).FirstOrDefault();
                            
                            int attackerWinCondition = s.AttackerTroopCount - (int)( playerTroop?.TroopCount * 1.05 * wallLevel ?? 1);
                            int attackerLastTroops = s.AttackerTroopCount - attackerWinCondition;
                            if (attackerWinCondition > 0) // attacker wins 
                            {
                                var attackResultData = new AttackResultData()
                                {
                                    TargetUsername = playerBaseInfo?.Username??"",
                                    TargetUserId = playerBaseInfo.UserId,
                                    TargetsWoundedTroop = (playerTroop?.TroopCount/6*3) ?? 0,
                                    TargetsDeadTroop = (playerTroop?.TroopCount/6*2) ?? 0,
                                    BarracksLevel = barracksLevel,
                                    WallLevel = wallLevel,
                                    LootedScrap = playerBaseInfo.Scraps/5,
                                    PrisonerCount = (playerTroop?.TroopCount/6*1) ?? 0,
                                    SenderUserId = s.AttackerUserId,
                                    SenderUsername = _context.PlayerBaseInfo
                                        .Where(l=>l.UserId==s.AttackerUserId)
                                        .Select(l=>l.Username).FirstOrDefault()??"",
                                    AttackersDeadTroop = (s.AttackerTroopCount-attackerLastTroops)/5,
                                    AttackersWoundedTroop = (s.AttackerTroopCount-attackerLastTroops)/5*4,
                                    DefenserScrap = playerBaseInfo.Scraps,
                                    TargetsTroop = _context.PlayerTroop
                                        .Where(l=>l.UserId==s.TargetUserId)
                                        .Select(l=>l.TroopCount).FirstOrDefault(),
                                    
                                    
                                };
                                
                                Console.WriteLine(JsonConvert.SerializeObject(attackResultData));
                                Console.WriteLine(s.ResultData+"----");
                                s.WinnerSide = (byte)AttackSideEnum.Attacker;
                                if (s !=null )
                                {
                                    s.ResultData = JsonConvert.SerializeObject(attackResultData,Formatting.Indented, new JsonSerializerSettings
                                    {
                                        NullValueHandling = NullValueHandling.Ignore,
                                        DefaultValueHandling = DefaultValueHandling.Ignore,
                                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                    });
                                }
                                playerBaseInfo.Scraps -= playerBaseInfo.Scraps / 5;
                                playerTroop.TroopCount -= attackResultData.TargetsDeadTroop 
                                                          + attackResultData.TargetsWoundedTroop 
                                                          + attackResultData.PrisonerCount;
                                int newVal = targetPlayerHospital.InjuredCount + attackResultData.TargetsWoundedTroop;
                                targetPlayerHospital.InjuredCount =
                                    newVal > targetPlayerHospital.HospitalLevel.HospitalCapacity
                                        ? targetPlayerHospital.HospitalLevel.HospitalCapacity
                                        : newVal;


                            }
                            else // defenser wins 
                            {
                                var attackResultData = new AttackResultData()
                                {
                                    TargetUsername = playerBaseInfo?.Username??"",
                                    TargetUserId = playerBaseInfo.UserId,
                                    TargetsWoundedTroop = (playerTroop?.TroopCount/12*3) ?? 0,
                                    TargetsDeadTroop = (playerTroop?.TroopCount/12*2) ?? 0,
                                    BarracksLevel = barracksLevel,
                                    WallLevel = wallLevel,
                                    LootedScrap = 0,
                                    PrisonerCount = 0,
                                    SenderUserId = s.AttackerUserId,
                                    SenderUsername = _context.PlayerBaseInfo
                                        .Where(l=>l.UserId==s.AttackerUserId)
                                        .Select(l=>l.Username).FirstOrDefault()??"",
                                    AttackersDeadTroop = (s.AttackerTroopCount)/5,
                                    AttackersWoundedTroop = (s.AttackerTroopCount)/5*4,
                                    DefenserScrap = playerBaseInfo.Scraps,
                                    TargetsTroop = _context.PlayerTroop
                                        .Where(l=>l.UserId==s.TargetUserId)
                                        .Select(l=>l.TroopCount).FirstOrDefault(),
                                };
                                s.WinnerSide = (byte)AttackSideEnum.Defenser;
                                s.ResultData = JsonConvert.SerializeObject(attackResultData);
                                playerBaseInfo.Scraps -= playerBaseInfo.Scraps / 5;
                                playerTroop.TroopCount -= attackResultData.TargetsDeadTroop 
                                                          + attackResultData.TargetsWoundedTroop 
                                                          + attackResultData.PrisonerCount;
                                int newVal = targetPlayerHospital.InjuredCount + attackResultData.TargetsWoundedTroop;
                                targetPlayerHospital.InjuredCount =
                                    newVal > targetPlayerHospital.HospitalLevel.HospitalCapacity
                                        ? targetPlayerHospital.HospitalLevel.HospitalCapacity
                                        : newVal;
                            }

                            var dbEnt =_context.Attack.Where(l => l.Id == s.Id).FirstOrDefault();
                            if (dbEnt != null)
                            {
                                dbEnt.ResultData = s.ResultData;
                                dbEnt.WinnerSide = s.WinnerSide;
                                _context.SaveChanges();
                                
                                var xxx=SendAttackInfo(new BaseRequest<AttackInfoDTO>()
                                {
                                    Data = new AttackInfoDTO()
                                    {
                                        IsActive = dbEnt.IsActive,
                                        ComeBackDate = dbEnt.ComeBackDate.ToString(),
                                        DefenserUserId = dbEnt.TargetUserId,
                                        Id = dbEnt.Id,
                                        ArriveDate = dbEnt.ArriveDate.ToString(),
                                        ResultData = dbEnt.ResultData,
                                        WinnerSide = dbEnt.WinnerSide,
                                        AttackerHeroId = dbEnt.AttackerHeroId,
                                        AttackerTroopCount = dbEnt.AttackerTroopCount,
                                        AttackerUserId = dbEnt.AttackerUserId,
                                        AttackerUsername = _context.PlayerBaseInfo
                                            .Where(l=>l.UserId==s.AttackerUserId)
                                            .Select(l=>l.Username).FirstOrDefault()??"",
                                        DefenserUsername = _context.PlayerBaseInfo
                                            .Where(l=>l.UserId==s.TargetUserId)
                                            .Select(l=>l.Username).FirstOrDefault()??""
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
                                Console.WriteLine("--SendAttackInfo-");
                            }
                            

                            #endregion
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    
                    now=DateTimeOffset.UtcNow;
                    var rmvList= _context.Attack.Where(l=>l.ComeBackDate <= now && l.ResultData != null && l.IsActive).ToList();
                    if (rmvList.Count>0)
                    {
                        foreach (var rS in rmvList)
                        {                         
                            rS.IsActive = false;
                            var attackerPlayerHospital = _context.PlayerHospital.Include(l=>l.HospitalLevel).Where(l => l.UserId == rS.AttackerUserId).FirstOrDefault();
                            var attackerPlayerTroops = _context.PlayerTroop.Where(l => l.UserId == rS.AttackerUserId).FirstOrDefault();
                            var attackerPlayerBaseInfo = _context.PlayerBaseInfo.Where(l => l.UserId == rS.AttackerUserId).FirstOrDefault();
                            var defenserPlayerBaseInfo = _context.PlayerBaseInfo.Where(l => l.UserId == rS.TargetUserId).FirstOrDefault();
                            var attackerPlayerPrison = _context.PlayerPrison.Include(l=>l.PrisonLevel).Where(l => l.UserId == rS.AttackerUserId).FirstOrDefault();
                            var resData = JsonConvert.DeserializeObject<AttackResultData>(rS.ResultData);

                            int newVal = attackerPlayerHospital.InjuredCount + resData.AttackersWoundedTroop;
                            attackerPlayerHospital.InjuredCount =
                                newVal > attackerPlayerHospital.HospitalLevel.HospitalCapacity
                                    ? attackerPlayerHospital.HospitalLevel.HospitalCapacity
                                    : newVal;
                            attackerPlayerBaseInfo.Scraps += resData.LootedScrap;
                            attackerPlayerTroops.TroopCount += rS.AttackerTroopCount - resData.AttackersDeadTroop -
                                                               resData.AttackersWoundedTroop;
                            newVal = attackerPlayerPrison.PrisonerCount + resData.PrisonerCount;
                            attackerPlayerPrison.PrisonerCount =
                                newVal > attackerPlayerPrison.PrisonLevel.MaxPrisonerCount
                                    ? attackerPlayerPrison.PrisonLevel.MaxPrisonerCount
                                    : newVal;
                            _context.SaveChanges();
                            
                            var ccc = SendAttackInfo(new BaseRequest<AttackInfoDTO>()
                            {
                                Data = new AttackInfoDTO()
                                {
                                    IsActive = rS.IsActive,
                                    ComeBackDate = rS.ComeBackDate.ToString(),
                                    Id = rS.Id,
                                    ArriveDate = rS.ArriveDate.ToString(),
                                    ResultData = rS.ResultData,
                                    WinnerSide = rS.WinnerSide,
                                    AttackerHeroId = rS.AttackerHeroId,
                                    AttackerTroopCount = rS.AttackerTroopCount,
                                    AttackerUserId = rS.AttackerUserId,
                                    DefenserUserId = rS.TargetUserId,
                                    AttackerUsername = attackerPlayerBaseInfo.Username,
                                    DefenserUsername = defenserPlayerBaseInfo.Username
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
                            Console.WriteLine("238---"+ccc.Message);
                            
                        }

                    }
                    
                    AttackList.RemoveAll(l => l.ComeBackDate <= now && l.ResultData != null);
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
    
    
    
        
        
    private static async Task<TDResponse> SendAttackInfo(BaseRequest<AttackInfoDTO> req)
    {
        var handler = new HttpClientHandler();

        handler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) =>
            { return true; }; //TODO: Prodda silinmeli

        using (HttpClient client = new HttpClient(handler))
        {

            var response = client.PostAsync(new Uri( Environment.GetEnvironmentVariable("WebSocketUrl")+ "/api/News/SendAttackNews"),
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