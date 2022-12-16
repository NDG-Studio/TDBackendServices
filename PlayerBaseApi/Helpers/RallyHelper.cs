using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PlayerBaseApi.Entities;
using SharedLibrary.Enums;
using SharedLibrary.Helpers;
using SharedLibrary.Models;
using SharedLibrary.Models.Loot;

namespace PlayerBaseApi.Helpers;

public class RallyHelper
{
    public static List<Rally> RallyList = new List<Rally>();
    private static int TROOP_POWER = 1;
    private static int WALL_POWER = 1;
    
    public static void Start(ILoggerProvider logger)
    {
        TROOP_POWER=Int32.Parse(Environment.GetEnvironmentVariable("TROOPPOWER")??"1");
        WALL_POWER=Int32.Parse(Environment.GetEnvironmentVariable("WALLPOWER")??"1");
        new Thread(new ThreadStart(CheckRally)).Start();
            
    }
    
    
    
        
    public static void NewRally(Rally rally)
    {
        RallyList.Add(rally);
        using (var _context = new PlayerBaseContext())
        {
            var ccc = SendRallyInfo(new BaseRequest<RallyDTO>()
            {
                Data = MapRallyDTO(rally),
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
    

    private static void CheckRally()
    {
        using (var _context = new PlayerBaseContext())
        {
            RallyList = _context.Rally.Where(l => l.IsActive).ToList();
        }

        while (true)
        {
            try
            {
                var now = DateTimeOffset.UtcNow;
                var doneList=RallyList.Where(l =>l.WarDate <= now && l.WinnerSide==null && l.IsActive).ToList();
                using (var _context = new PlayerBaseContext())
                {
                    foreach (var s in doneList)
                    {
                        try
                        {
                            #region ATTACK ALGORITHM

                            s.RallyParts = _context.RallyPart.Where(l => l.RallyId == s.Id).ToList();
                            var TplayerBaseInfo = _context.PlayerBaseInfo.Where(l => l.UserId == s.TargetUserId)
                                .FirstOrDefault();
                            var TplayerTroop = _context.PlayerTroop.Where(l => l.UserId == s.TargetUserId).FirstOrDefault();
                            var TPlayerHospital = _context.PlayerHospital.Include(l=>l.HospitalLevel)
                                .Where(l => l.UserId == s.TargetUserId).FirstOrDefault();
                            var TplayerBasePlacement = _context.PlayerBasePlacement
                                .Where(l => l.UserId == s.TargetUserId && (l.BuildingTypeId == 3 || l.BuildingTypeId == 10))
                                .ToList();
                            var TbarracksLevel = TplayerBasePlacement.Where(l => l.BuildingTypeId == 10 )
                                .Select(l => l.BuildingLevel).FirstOrDefault();                    
                            var TwallLevel = TplayerBasePlacement.Where(l => l.BuildingTypeId == 3)
                                .Select(l => l.BuildingLevel).FirstOrDefault();
                            

                            // var AplayerTroop = _context.PlayerTroop.Where(l => l.UserId == s.AttackerUserId).FirstOrDefault();
                            // var APlayerHospital = _context.PlayerHospital.Include(l=>l.HospitalLevel).Where(l => l.UserId == s.AttackerUserId).FirstOrDefault();


                            int APower = 0;
                            int TPower = 0;
                            var TBuffs = BuffHelper.GetPlayersTotalBuff(s.TargetUserId, -1).Result;
                            var ATotalTroops = 0;
                            foreach (var rallyPart in s.RallyParts)
                            {
                                var ABuffs = BuffHelper.GetPlayersTotalBuff(rallyPart.UserId, rallyPart.HeroId).Result;
                                ATotalTroops += rallyPart.TroopCount;
                                APower += (int)(rallyPart.TroopCount * TROOP_POWER * (ABuffs.AttackMultiplier <= 1 ? 1: ABuffs.AttackMultiplier));
                                Console.WriteLine("ATTACKER-Power-"+rallyPart.UserId+":"+APower);
                            }
                 

                            
                            
                            TPower += (int)(TplayerTroop.TroopCount * TROOP_POWER * (TBuffs.DefenseMultiplier<=1?1:TBuffs.DefenseMultiplier));
                            TPower += (TwallLevel * WALL_POWER);
                            
                            Console.WriteLine("Defenser-Power-"+s.TargetUserId+":"+TPower);
                            
                            AttackSideEnum winnerSide = APower - TPower > 0 ? AttackSideEnum.Attacker : AttackSideEnum.Defenser;
                            int powerDiff = Math.Abs(APower - TPower);
                            int troopDiff = powerDiff / TROOP_POWER;
                            
                            
                            if (winnerSide == AttackSideEnum.Attacker) // attacker wins 
                            {
                                int TDead = RandomHelper.GetRandomInt(0,TplayerTroop.TroopCount/4);                                
                                int ATotalPrisoner = RandomHelper.GetRandomInt(0,Math.Min(TplayerTroop.TroopCount-TDead,troopDiff));
                                int TWounded = TplayerTroop.TroopCount - TDead - ATotalPrisoner;
                                
                                int ATotalDead = RandomHelper.GetRandomInt(0,(ATotalTroops-troopDiff)/3);
                                int ATotalWounded = ATotalTroops-troopDiff-ATotalDead;
                                int TotalLootedScrap = Math.Min(troopDiff*100,TplayerBaseInfo.Scraps);

                                s.TargetsWoundedTroop = TWounded;
                                s.TargetsDeadTroop = TDead;
                                s.TargetBarracksLevel = TbarracksLevel;
                                s.TargetWallLevel = TwallLevel;
                                s.LootedScrap = TotalLootedScrap;
                                s.PrisonerCount = ATotalPrisoner;
                                s.TargetScrap = TplayerBaseInfo.Scraps;
                                s.TargetsTroop = TplayerTroop.TroopCount;
                                s.WinnerSide = (byte)AttackSideEnum.Attacker;
                                TplayerBaseInfo.Scraps -= s.LootedScrap??0;

                                foreach (var part in s.RallyParts)
                                {
                                    var AplayerBaseInfo = _context.PlayerBaseInfo
                                        .Where(l => l.UserId == part.UserId)
                                        .FirstOrDefault();
                                    part.BarracksLevel = 0;
                                    part.DeadTroop = (part.TroopCount / ATotalTroops) * ATotalDead;
                                    part.WoundedTroop= (part.TroopCount / ATotalTroops) * ATotalWounded;
                                    part.PrisonerCount=(part.TroopCount / ATotalTroops) * ATotalPrisoner;
                                    part.LootedScrap=(part.TroopCount / ATotalTroops) * TotalLootedScrap;
                                    if (AplayerBaseInfo!=null)
                                    {
                                        AplayerBaseInfo.KillCount+=(part.TroopCount / ATotalTroops)*ATotalDead;
                                        AplayerBaseInfo.LootedScrap += part.LootedScrap;
                                    }
                                }
                                

                                TplayerTroop.TroopCount = 0;
                                TPlayerHospital.InjuredCount = Math.Min(TPlayerHospital.HospitalLevel.HospitalCapacity,
                                    TPlayerHospital.InjuredCount + (s.TargetsWoundedTroop??0));
                            }
                            else // defenser wins 
                            {
                                // int TDead = RandomHelper.GetRandomInt(0, (TplayerTroop.TroopCount - troopDiff) / 4);
                                // int TWounded = TplayerTroop.TroopCount - troopDiff - TDead;
                                // int ATotalDead = RandomHelper.GetRandomInt(0,ATotalTroops/3);
                                // int ATotalWounded = ATotalTroops-ATotalDead;
                                // int TotalLootedScrap = 0;
                                //
                                // var attackResultData = new AttackResultData()
                                // {
                                //     TargetUsername = TplayerBaseInfo.Username,
                                //     TargetUserId = TplayerBaseInfo.UserId,
                                //     TargetsWoundedTroop = TWounded,
                                //     TargetsDeadTroop = TDead,
                                //     BarracksLevel = TbarracksLevel,
                                //     WallLevel = TwallLevel,
                                //     LootedScrap = 0,
                                //     PrisonerCount = 0,
                                //     SenderUserId = AplayerBaseInfo.UserId,
                                //     SenderUsername = AplayerBaseInfo.Username,
                                //     AttackersDeadTroop = ADead,
                                //     AttackersWoundedTroop = AWounded,
                                //     DefenserScrap = TplayerBaseInfo.Scraps,
                                //     TargetsTroop = TplayerTroop.TroopCount,
                                //     TargetAvatarId = TplayerBaseInfo.AvatarId??0,
                                //     SenderAvatarId = AplayerBaseInfo.AvatarId??0
                                // };
                                //
                                // s.WinnerSide = (byte)AttackSideEnum.Defenser;
                                // if (s !=null )
                                // {
                                //     s.ResultData = JsonConvert.SerializeObject(attackResultData,Formatting.Indented, new JsonSerializerSettings
                                //     {
                                //         NullValueHandling = NullValueHandling.Ignore,
                                //         DefaultValueHandling = DefaultValueHandling.Ignore,
                                //         ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                //     });
                                // }
                                
                                int TDead = RandomHelper.GetRandomInt(0, (TplayerTroop.TroopCount - troopDiff) / 4);
                                int TWounded = TplayerTroop.TroopCount - troopDiff - TDead;
                                
                                int ATotalDead = RandomHelper.GetRandomInt(0,ATotalTroops/3);
                                int TotalLootedScrap = 0;

                                s.TargetsWoundedTroop = TWounded;
                                s.TargetsDeadTroop = TDead;
                                s.TargetBarracksLevel = TbarracksLevel;
                                s.TargetWallLevel = TwallLevel;
                                s.LootedScrap = TotalLootedScrap;
                                s.PrisonerCount = 0;
                                s.TargetScrap = TplayerBaseInfo.Scraps;
                                s.TargetsTroop = TplayerTroop.TroopCount;
                                s.WinnerSide = (byte)AttackSideEnum.Defenser;

                                foreach (var part in s.RallyParts)
                                {
                                    var AplayerBaseInfo = _context.PlayerBaseInfo
                                        .Where(l => l.UserId == part.UserId)
                                        .FirstOrDefault();
                                    part.BarracksLevel = 0;
                                    part.DeadTroop = (part.TroopCount / ATotalTroops) * ATotalDead;
                                    part.WoundedTroop = part.TroopCount - part.DeadTroop;
                                    part.PrisonerCount=0;
                                    part.LootedScrap=(part.TroopCount / ATotalTroops) * TotalLootedScrap;
                                    if (AplayerBaseInfo!=null)
                                    {
                                        AplayerBaseInfo.KillCount+=(part.TroopCount / ATotalTroops)*ATotalDead;
                                        AplayerBaseInfo.LootedScrap += part.LootedScrap;
                                    }
                                }
                                

                                TplayerTroop.TroopCount -= s.TargetsWoundedTroop ?? 0;
                                TplayerTroop.TroopCount -= s.TargetsDeadTroop ?? 0;
                                TPlayerHospital.InjuredCount = Math.Min(TPlayerHospital.HospitalLevel.HospitalCapacity,
                                    TPlayerHospital.InjuredCount + (s.TargetsWoundedTroop??0));
                                
                                
                            }

                            var dbEnt =_context.Rally.Where(l => l.Id == s.Id).FirstOrDefault();
                            if (dbEnt != null)
                            {
                                dbEnt.TargetsWoundedTroop = s.TargetsWoundedTroop;
                                dbEnt.TargetsDeadTroop = s.TargetsWoundedTroop;
                                dbEnt.TargetBarracksLevel = s.TargetBarracksLevel;
                                dbEnt.TargetWallLevel = s.TargetWallLevel;
                                dbEnt.LootedScrap = s.LootedScrap;
                                dbEnt.PrisonerCount = s.PrisonerCount;
                                dbEnt.TargetScrap = s.TargetScrap;
                                dbEnt.TargetsTroop = s.TargetsTroop;
                                dbEnt.WinnerSide = s.WinnerSide;
                                dbEnt.RallyParts = s.RallyParts; //TODO: rally partlarini kaydedecek mi kontrol et
                                _context.SaveChanges();
                                
                                
                                
                                
                                var xxx=SendRallyInfo(new BaseRequest<RallyDTO>()
                                {
                                    Data = MapRallyDTO(dbEnt),
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
                                Console.WriteLine("--SendRallyInfo-");
                            }
                            

                            #endregion
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    
                    now=DateTimeOffset.UtcNow;
                    var rmvList= _context.RallyPart.Include(l=>l.Rally)
                        .Where(l=>l.ComeBackDate <= now && l.Rally.WinnerSide != null && l.IsActive).ToList();
                    if (rmvList.Count>0)
                    {
                        foreach (RallyPart r in rmvList)
                        {                         
                            r.IsActive = false;
                            var attackerPlayerHospital = _context.PlayerHospital.Include(l=>l.HospitalLevel).Where(l => l.UserId == r.UserId).FirstOrDefault();
                            var attackerPlayerTroops = _context.PlayerTroop.Where(l => l.UserId == r.UserId).FirstOrDefault();
                            var attackerPlayerBaseInfo = _context.PlayerBaseInfo.Where(l => l.UserId == r.UserId).FirstOrDefault();
                            var defenserPlayerBaseInfo = _context.PlayerBaseInfo.Where(l => l.UserId == r.Rally.TargetUserId).FirstOrDefault();
                            var attackerPlayerPrison = _context.PlayerPrison.Include(l=>l.PrisonLevel).Where(l => l.UserId == r.UserId).FirstOrDefault();
                            

                            attackerPlayerHospital.InjuredCount = Math.Min(
                                attackerPlayerHospital.HospitalLevel.HospitalCapacity,
                                attackerPlayerHospital.InjuredCount + r.WoundedTroop);

                            attackerPlayerBaseInfo.Scraps += r.LootedScrap;
                            attackerPlayerTroops.TroopCount += r.TroopCount - r.DeadTroop -
                                                               r.WoundedTroop;
                            attackerPlayerPrison.PrisonerCount = Math.Min(
                                attackerPlayerPrison.PrisonerCount + r.PrisonerCount,
                                attackerPlayerPrison.PrisonLevel.MaxPrisonerCount);
                            _context.SaveChanges();
                            
                            var ccc = SendRallyInfo(new BaseRequest<RallyDTO>()
                            {
                                Data = MapRallyDTO(r.Rally),
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
                    
                    RallyList.RemoveAll(l => l.WinnerSide != null);
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
    
    
    
            
    private static async Task<TDResponse> SendRallyInfo(BaseRequest<RallyDTO> req)
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

    public static RallyDTO MapRallyDTO(Rally r)
    {
        return new RallyDTO()
        {
            Id = r.Id,
            Date = r.Date.ToString(),
            IsActive = r.IsActive,
            LeaderUsername = r.LeaderUsername,
            LootedScrap = r.LootedScrap,
            PrisonerCount = r.PrisonerCount,
            RallyParts = r.RallyParts.Select(l => new RallyPartDTO()
            {
                Id = l.Id,
                Username = l.Username,
                ArriveDate = l.ArriveDate.ToString(),
                BarracksLevel = l.BarracksLevel,
                DeadTroop = l.DeadTroop,
                HeroId = l.HeroId,
                IsActive = l.IsActive,
                LootedScrap = l.LootedScrap,
                PrisonerCount = l.PrisonerCount,
                RallyId = l.RallyId,
                TroopCount = l.TroopCount,
                UserId = l.UserId,
                WallLevel = l.WallLevel,
                WoundedTroop = l.WoundedTroop,
                ComeBackDate = l.ComeBackDate.ToString(),
                SenderAvatarId = l.SenderAvatarId
            }).ToList(),
            TargetScrap = r.TargetScrap,
            TargetsTroop = r.TargetsTroop,
            TargetUsername = r.TargetUsername,
            WarDate = r.WarDate.ToString(),
            WinnerSide = r.WinnerSide,
            ComeBackDate = r.ComeBackDate.ToString(),
            LeaderAvatarId = r.LeaderAvatarId,
            LeaderUserCoord = r.LeaderUserCoord,
            LeaderUserId = r.LeaderUserId,
            RallyStartDate = r.RallyStartDate.ToString(),
            TargetAvatarId = r.TargetAvatarId,
            TargetBarracksLevel = r.TargetBarracksLevel,
            TargetsDeadTroop = r.TargetsDeadTroop,
            TargetsWoundedTroop = r.TargetsWoundedTroop,
            TargetTroopCount = r.TargetTroopCount,
            TargetUserCoord = r.TargetUserCoord,
            TargetUserId = r.TargetUserId,
            TargetWallLevel = r.TargetWallLevel,
            LeaderGangId = r.LeaderGangId,
            LeaderGangName = r.LeaderGangName,
            TargetGangId = r.TargetGangId,
            TargetGangName = r.TargetGangName,
            LeaderGangAvatarId = r.LeaderGangAvatarId,
            TargetGangAvatarId = r.TargetGangAvatarId
            
        };
    }
    
    
}