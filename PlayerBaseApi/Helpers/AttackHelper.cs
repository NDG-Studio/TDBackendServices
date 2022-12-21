using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PlayerBaseApi.Entities;
using SharedLibrary.Enums;
using SharedLibrary.Helpers;
using SharedLibrary.Models;

namespace PlayerBaseApi.Helpers;

public class AttackHelper
{
    public static List<Attack> AttackList = new List<Attack>();
    private static int TROOP_POWER = 1;
    private static int WALL_POWER = 1;
    public static void Start(ILoggerProvider logger)
    {
        TROOP_POWER=Int32.Parse(Environment.GetEnvironmentVariable("TROOPPOWER")??"1");
        WALL_POWER=Int32.Parse(Environment.GetEnvironmentVariable("WALLPOWER")??"1");
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
                        .Select(l=>l.Username).FirstOrDefault()??(attack.TargetUserId==(long)FakeId.TutorialEnemy?"Emmanuel":""),
                    AttackerAvatarId = _context.PlayerBaseInfo.Where(l=>l.UserId==attack.AttackerUserId)
                        .Select(l=>l.AvatarId).FirstOrDefault()??0,
                    DefenserAvatarId = _context.PlayerBaseInfo.Where(l=>l.UserId==attack.AttackerUserId)
                        .Select(l=>l.AvatarId).FirstOrDefault()??(attack.TargetUserId==(long)FakeId.TutorialEnemy?3:0)

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
                            if (s.TargetUserId==(long)FakeId.TutorialEnemy)//FAKE ATTACK
                            {
                                var _AplayerBaseInfo = _context.PlayerBaseInfo.Where(l => l.UserId == s.AttackerUserId)
                                    .FirstOrDefault();
                                var _AplayerTroop = _context.PlayerTroop.Where(l => l.UserId == s.AttackerUserId).FirstOrDefault();
                                var _APlayerHospital = _context.PlayerHospital.Include(l=>l.HospitalLevel).Where(l => l.UserId == s.AttackerUserId).FirstOrDefault();

                                var attackResultData = new AttackResultData()
                                {
                                    TargetUsername = "Emmanuel",
                                    TargetUserId = s.TargetUserId,
                                    TargetsWoundedTroop = 625,
                                    TargetsDeadTroop = 375,
                                    BarracksLevel = 1,
                                    WallLevel = 1,
                                    LootedScrap = 5000,
                                    PrisonerCount = 0,
                                    SenderUserId = s.AttackerUserId,
                                    SenderUsername = _AplayerBaseInfo.Username,
                                    AttackersDeadTroop = 875,
                                    AttackersWoundedTroop = 125,
                                    DefenserScrap = 10000,
                                    TargetsTroop = 1000,
                                    TargetAvatarId = 3,
                                    SenderAvatarId = _AplayerBaseInfo.AvatarId??0,
                                    AttackerPower = 50520,
                                    DefenserPower = 42367

                                };
                                s.WinnerSide = (byte)AttackSideEnum.Attacker;
                                s.ResultData=JsonConvert.SerializeObject(attackResultData,Formatting.Indented, new JsonSerializerSettings
                                {
                                    NullValueHandling = NullValueHandling.Ignore,
                                    DefaultValueHandling = DefaultValueHandling.Ignore,
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                });
                            var _dbEnt =_context.Attack.Where(l => l.Id == s.Id).FirstOrDefault();
                            if (_dbEnt != null)
                            {
                                _dbEnt.ResultData = s.ResultData;
                                _dbEnt.WinnerSide = s.WinnerSide;
                                _context.SaveChanges();
                                var xxx=SendAttackInfo(new BaseRequest<AttackInfoDTO>()
                                {
                                    Data = new AttackInfoDTO()
                                    {
                                        IsActive = _dbEnt.IsActive,
                                        ComeBackDate = _dbEnt.ComeBackDate.ToString(),
                                        DefenserUserId = _dbEnt.TargetUserId,
                                        Id = _dbEnt.Id,
                                        ArriveDate = _dbEnt.ArriveDate.ToString(),
                                        ResultData = _dbEnt.ResultData,
                                        WinnerSide = _dbEnt.WinnerSide,
                                        AttackerHeroId = _dbEnt.AttackerHeroId,
                                        AttackerTroopCount = _dbEnt.AttackerTroopCount,
                                        AttackerUserId = _dbEnt.AttackerUserId,
                                        AttackerUsername = _context.PlayerBaseInfo
                                            .Where(l=>l.UserId==s.AttackerUserId)
                                            .Select(l=>l.Username).FirstOrDefault()??"",
                                        DefenserUsername = "Emmanuel",
                                        AttackerAvatarId = _AplayerBaseInfo.AvatarId??0,
                                        DefenserAvatarId = 3,
                                        AttackerPower = 50520,
                                        DefenserPower = 42367
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
                                Console.WriteLine("--SendFAKEAttackInfo-");
                            }
                            

                                continue;
                            }
                            #region ATTACK ALGORITHM

                            var TplayerBaseInfo = _context.PlayerBaseInfo.Where(l => l.UserId == s.TargetUserId)
                                .FirstOrDefault();
                            var TplayerTroop = _context.PlayerTroop.Where(l => l.UserId == s.TargetUserId).FirstOrDefault();
                            var TPlayerHospital = _context.PlayerHospital.Include(l=>l.HospitalLevel).Where(l => l.UserId == s.TargetUserId).FirstOrDefault();
                            var TplayerBasePlacement = _context.PlayerBasePlacement
                                .Where(l => l.UserId == s.TargetUserId && (l.BuildingTypeId == 3 || l.BuildingTypeId == 10))
                                .ToList();
                            var TbarracksLevel = TplayerBasePlacement.Where(l => l.BuildingTypeId == 10 )
                                .Select(l => l.BuildingLevel).FirstOrDefault();                    
                            var TwallLevel = TplayerBasePlacement.Where(l => l.BuildingTypeId == 3)
                                .Select(l => l.BuildingLevel).FirstOrDefault();
                            
                            var AplayerBaseInfo = _context.PlayerBaseInfo.Where(l => l.UserId == s.AttackerUserId)
                                .FirstOrDefault();
                            var AplayerTroop = _context.PlayerTroop.Where(l => l.UserId == s.AttackerUserId).FirstOrDefault();
                            var APlayerHospital = _context.PlayerHospital.Include(l=>l.HospitalLevel).Where(l => l.UserId == s.AttackerUserId).FirstOrDefault();


                            int APower = 0;
                            int TPower = 0;
                            var ABuffs = BuffHelper.GetPlayersTotalBuff(s.AttackerUserId, s.AttackerHeroId).Result;
                            var TBuffs = BuffHelper.GetPlayersTotalBuff(s.TargetUserId, -1).Result;

                            
                            APower = (int)(s.AttackerTroopCount * TROOP_POWER * (ABuffs.AttackMultiplier<=1?1:ABuffs.AttackMultiplier));
                            TPower = (int)(TplayerTroop.TroopCount * TROOP_POWER * (TBuffs.DefenseMultiplier<=1?1:TBuffs.DefenseMultiplier));
                            TPower = TPower + (TwallLevel * WALL_POWER);
                            Console.WriteLine("ATTACKER-Power-"+s.AttackerUserId+":"+APower);
                            Console.WriteLine("Defenser-Power-"+s.TargetUserId+":"+TPower);
                            
                            AttackSideEnum winnerSide = APower - TPower > 0 ? AttackSideEnum.Attacker : AttackSideEnum.Defenser;
                            int powerDiff = Math.Abs(APower - TPower);
                            int troopDiff = powerDiff / TROOP_POWER;
                            
                            
                            if (winnerSide == AttackSideEnum.Attacker) // attacker wins 
                            {
                                int TDead = RandomHelper.GetRandomInt(0,TplayerTroop.TroopCount/4);                                
                                int Prisoner = RandomHelper.GetRandomInt(0,Math.Min(TplayerTroop.TroopCount-TDead,troopDiff));
                                int TWounded = TplayerTroop.TroopCount - TDead - Prisoner;
                                int ADead = RandomHelper.GetRandomInt(0,(s.AttackerTroopCount-troopDiff)/3);
                                int AWounded = s.AttackerTroopCount-troopDiff-ADead;
                                int LootedScrap = Math.Min(troopDiff*100,TplayerBaseInfo.Scraps);
                                
                                var attackResultData = new AttackResultData()
                                {
                                    TargetUsername = TplayerBaseInfo.Username,
                                    TargetUserId = TplayerBaseInfo.UserId,
                                    TargetsWoundedTroop = TWounded,
                                    TargetsDeadTroop = TDead,
                                    BarracksLevel = TbarracksLevel,
                                    WallLevel = TwallLevel,
                                    LootedScrap = LootedScrap,
                                    PrisonerCount = Prisoner,
                                    SenderUserId = AplayerBaseInfo.UserId,
                                    SenderUsername = AplayerBaseInfo.Username,
                                    AttackersDeadTroop = ADead,
                                    AttackersWoundedTroop = AWounded,
                                    DefenserScrap = TplayerBaseInfo.Scraps,
                                    TargetsTroop = TplayerTroop.TroopCount,
                                    TargetAvatarId = TplayerBaseInfo.AvatarId??0,
                                    SenderAvatarId = AplayerBaseInfo.AvatarId??0,
                                    AttackerPower = APower,
                                    DefenserPower = TPower

                                };
                                
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
                                TplayerBaseInfo.Scraps -= attackResultData.LootedScrap;
                                AplayerBaseInfo.KillCount+=attackResultData.TargetsDeadTroop;
                                AplayerBaseInfo.LootedScrap+=attackResultData.LootedScrap;
                                TplayerTroop.TroopCount = 0;
                                TPlayerHospital.InjuredCount = Math.Min(TPlayerHospital.HospitalLevel.HospitalCapacity,
                                    TPlayerHospital.InjuredCount + attackResultData.TargetsWoundedTroop);
                            }
                            else // defenser wins 
                            {
                                int TDead = RandomHelper.GetRandomInt(0, (TplayerTroop.TroopCount - troopDiff) / 4);
                                int TWounded = TplayerTroop.TroopCount - troopDiff - TDead;
                                int ADead = RandomHelper.GetRandomInt(0,s.AttackerTroopCount/3);
                                int AWounded = s.AttackerTroopCount-ADead;
                                int LootedScrap = 0;
                                
                                var attackResultData = new AttackResultData()
                                {
                                    TargetUsername = TplayerBaseInfo.Username,
                                    TargetUserId = TplayerBaseInfo.UserId,
                                    TargetsWoundedTroop = TWounded,
                                    TargetsDeadTroop = TDead,
                                    BarracksLevel = TbarracksLevel,
                                    WallLevel = TwallLevel,
                                    LootedScrap = 0,
                                    PrisonerCount = 0,
                                    SenderUserId = AplayerBaseInfo.UserId,
                                    SenderUsername = AplayerBaseInfo.Username,
                                    AttackersDeadTroop = ADead,
                                    AttackersWoundedTroop = AWounded,
                                    DefenserScrap = TplayerBaseInfo.Scraps,
                                    TargetsTroop = TplayerTroop.TroopCount,
                                    TargetAvatarId = TplayerBaseInfo.AvatarId??0,
                                    SenderAvatarId = AplayerBaseInfo.AvatarId??0,
                                    AttackerPower = APower,
                                    DefenserPower = TPower
                                };
                                
                                s.WinnerSide = (byte)AttackSideEnum.Defenser;
                                if (s !=null )
                                {
                                    s.ResultData = JsonConvert.SerializeObject(attackResultData,Formatting.Indented, new JsonSerializerSettings
                                    {
                                        NullValueHandling = NullValueHandling.Ignore,
                                        DefaultValueHandling = DefaultValueHandling.Ignore,
                                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                    });
                                }
                                AplayerBaseInfo.KillCount+=attackResultData.TargetsDeadTroop;
                                TplayerTroop.TroopCount =TplayerTroop.TroopCount - TDead -TWounded;
                                TPlayerHospital.InjuredCount = Math.Min(TPlayerHospital.HospitalLevel.HospitalCapacity,
                                    TPlayerHospital.InjuredCount + attackResultData.TargetsWoundedTroop);
                                
                                
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
                                            .Select(l=>l.Username).FirstOrDefault()??"",
                                        AttackerAvatarId = AplayerBaseInfo.AvatarId??0,
                                        DefenserAvatarId = TplayerBaseInfo.AvatarId??0,
                                        AttackerPower = APower,
                                        DefenserPower = TPower
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

                            attackerPlayerHospital.InjuredCount = Math.Min(
                                attackerPlayerHospital.HospitalLevel.HospitalCapacity,
                                attackerPlayerHospital.InjuredCount + resData.AttackersWoundedTroop);

                            attackerPlayerBaseInfo.Scraps += resData.LootedScrap;
                            attackerPlayerTroops.TroopCount += rS.AttackerTroopCount - resData.AttackersDeadTroop -
                                                               resData.AttackersWoundedTroop;
                            
                            attackerPlayerPrison.PrisonerCount = Math.Min(
                                                                attackerPlayerPrison.PrisonerCount + resData.PrisonerCount,
                                                                attackerPlayerPrison.PrisonLevel.MaxPrisonerCount);
                            
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
                                    DefenserUsername = defenserPlayerBaseInfo.Username,
                                    AttackerAvatarId = attackerPlayerBaseInfo.AvatarId??0,
                                    DefenserAvatarId = defenserPlayerBaseInfo.AvatarId??0,
                                    AttackerPower = resData.AttackerPower,
                                    DefenserPower = resData.DefenserPower
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