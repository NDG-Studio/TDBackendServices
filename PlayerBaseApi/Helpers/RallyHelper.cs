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
    public static List<RallyPart> AbortedRallyParts = new List<RallyPart>();
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
    public static void ChangeRally(Rally rally)
    {
        var exist = RallyList.Where(l => l.Id == rally.Id).FirstOrDefault();
        if (exist!=null)
        {
            RallyList.Remove(exist);
        }
        
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

                            var isGate = s.TargetUserId <= 0;
                            s.RallyParts = _context.RallyPart.Where(l => l.RallyId == s.Id && l.IsActive && !l.IsAbort).ToList();
                            PlayerBaseInfo? TplayerBaseInfo = !isGate ? _context.PlayerBaseInfo.Where(l => l.UserId == s.TargetUserId)
                                .FirstOrDefault():null;
                            PlayerTroop? TplayerTroop = !isGate ? _context.PlayerTroop.Where(l => l.UserId == s.TargetUserId)
                                .FirstOrDefault() : null;
                            PlayerHospital? TPlayerHospital = !isGate ? _context.PlayerHospital.Include(l=>l.HospitalLevel)
                                .Where(l => l.UserId == s.TargetUserId).FirstOrDefault(): null;
                            List<PlayerBasePlacement>? TplayerBasePlacement =!isGate ? _context.PlayerBasePlacement
                                .Where(l => l.UserId == s.TargetUserId && (l.BuildingTypeId == 3 || l.BuildingTypeId == 10))
                                .ToList():null;
                            int? TbarracksLevel =!isGate ? TplayerBasePlacement.Where(l => l.BuildingTypeId == 10 )
                                .Select(l => l.BuildingLevel).FirstOrDefault() :null;                    
                            int? TwallLevel = !isGate ? TplayerBasePlacement.Where(l => l.BuildingTypeId == 3)
                                .Select(l => l.BuildingLevel).FirstOrDefault() :null;
                            
                            int APower = 0;
                            int TPower = 0;
                            var TBuffs = BuffHelper.GetPlayersTotalBuff(s.TargetUserId, -1).Result;
                            var ATotalTroops = 0;
                            var TTotalTroops = 0;
                            foreach (var rallyPart in s.RallyParts)
                            {
                                var ABuffs = BuffHelper.GetPlayersTotalBuff(rallyPart.UserId, rallyPart.HeroId).Result;
                                ATotalTroops += rallyPart.TroopCount;
                                APower += (int)(rallyPart.TroopCount * TROOP_POWER * (ABuffs.TroopDamageMultiplier <= 1 ? 1: ABuffs.TroopDamageMultiplier));
                            }


                            var supports = _context.SupportUnit.Where(l =>
                                    l.HostUserId == s.TargetUserId && l.State == (int)SupportUnitState.Stay &&
                                    l.IsActive)
                                .ToList();


                            foreach (var sup in supports)
                            {
                                var supBuff = BuffHelper.GetPlayersTotalBuff(sup.ClientUserId, sup.HeroId).Result;
                                TPower += (int)(sup.TroopCount * TROOP_POWER * (supBuff.TroopDefenseMultiplier <= 1 ? 1 : TBuffs.TroopDefenseMultiplier));
                                TTotalTroops += sup.TroopCount;

                            }
                            
                            if (!isGate)
                            {
                                TPower += (int)(TplayerTroop.TroopCount * TROOP_POWER * (TBuffs.TroopDefenseMultiplier<=1?1:TBuffs.TroopDefenseMultiplier));
                                TPower += ((TwallLevel ?? 0) * WALL_POWER);
                                TTotalTroops += TplayerTroop.TroopCount;
                            }
                            
                            
                            AttackSideEnum winnerSide = APower - TPower > 0 ? AttackSideEnum.Attacker : AttackSideEnum.Defenser;
                            int powerDiff = Math.Abs(APower - TPower);
                            int troopDiff = powerDiff / TROOP_POWER;
                            
                            
                            if (winnerSide == AttackSideEnum.Attacker) // attacker wins 
                            {
                                int TDead = RandomHelper.GetRandomInt(0,TTotalTroops/4);                                
                                int ATotalPrisoner = RandomHelper.GetRandomInt(0,Math.Min(TTotalTroops-TDead,troopDiff));
                                int TWounded = TTotalTroops - TDead - ATotalPrisoner;
                                
                                int ATotalDead = RandomHelper.GetRandomInt(0,(ATotalTroops-troopDiff)/3);
                                int ATotalWounded = ATotalTroops-troopDiff-ATotalDead;
                                int TotalLootedScrap = isGate ? 0 : Math.Min(troopDiff*100,TplayerBaseInfo.Scraps);

                                s.TargetsWoundedTroop = TWounded;
                                s.TargetsDeadTroop = TDead;
                                s.TargetBarracksLevel = TbarracksLevel;
                                s.TargetWallLevel = TwallLevel;
                                s.LootedScrap = TotalLootedScrap;
                                s.PrisonerCount = ATotalPrisoner;
                                s.TargetScrap = isGate ? 0 : TplayerBaseInfo.Scraps;
                                s.TargetsTroop = TTotalTroops;
                                s.WinnerSide = (byte)AttackSideEnum.Attacker;
                                s.ATotalTroop = ATotalTroops;
                                s.ATotalDeadTroop = ATotalDead;
                                s.ATotalWoundedTroop = ATotalWounded;
                                if (!isGate)
                                {
                                    TplayerBaseInfo.Scraps -= s.LootedScrap??0;
                                }
                                

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
                                        AplayerBaseInfo.KillCount+=(part.TroopCount / ATotalTroops)*TDead;
                                        AplayerBaseInfo.LootedScrap += part.LootedScrap;
                                    }
                                }

                                foreach (var supPart in supports)
                                {
                                    supPart.Dead = (supPart.TroopCount / TTotalTroops) * TDead;
                                    supPart.Wounded= (supPart.TroopCount / TTotalTroops) * TWounded;
                                    supPart.TroopCount = 0;
                                    _context.SaveChanges();
                                    SupportUnitHelper.ComebackSupport(supPart);
                                }

                                if (isGate)
                                {
                                    var gateInfo = _context.GateInfo.Where(l => l.GateId == s.TargetUserId).FirstOrDefault();
                                    if (gateInfo!=null)
                                    {
                                        gateInfo.GangId = s.LeaderGangId;
                                        gateInfo.GangName = s.LeaderGangName;
                                        gateInfo.GangShortName = s.LeaderGangName?.Split('[')[1].Split(']')[0];
                                        gateInfo.TotalTroopCount = 0;
                                        gateInfo.GangAvatarId = s.LeaderGangAvatarId;
                                    }
                                }

                                if (!isGate)
                                {
                                    TplayerBaseInfo.DefenseKillCount += ATotalDead;
                                    TplayerTroop.TroopCount = 0;
                                    TPlayerHospital.InjuredCount = Math.Min(TPlayerHospital.HospitalLevel.HospitalCapacity,
                                    TPlayerHospital.InjuredCount + (s.TargetsWoundedTroop??0));
                                }
                                
                                
                            }
                            else // defenser wins 
                            {

                                int TDead = RandomHelper.GetRandomInt(0, (TTotalTroops - troopDiff) / 4);
                                int TWounded = TTotalTroops - troopDiff - TDead;
                                
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
                                s.ATotalTroop = ATotalTroops;
                                s.ATotalDeadTroop = ATotalDead;
                                s.ATotalWoundedTroop = ATotalTroops-ATotalDead;

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
                                        AplayerBaseInfo.KillCount+=(part.TroopCount / ATotalTroops)*TDead;
                                        AplayerBaseInfo.LootedScrap += part.LootedScrap;
                                    }
                                }
                                
                                foreach (var supPart in supports)
                                {
                                    supPart.Dead = (supPart.TroopCount / TTotalTroops) * TDead;
                                    supPart.Wounded= (supPart.TroopCount / TTotalTroops) * TWounded;
                                    supPart.TroopCount = supPart.TroopCount -(
                                                         ((supPart.TroopCount / TTotalTroops) * TDead) + ((supPart.TroopCount / TTotalTroops) * TWounded));
                                }

                                _context.SaveChanges();
                                
                                if (isGate)
                                {
                                    var gateInfo = _context.GateInfo.Where(l => l.GateId == s.TargetUserId).FirstOrDefault();
                                    if (gateInfo!=null)
                                    {
                                        gateInfo.TotalTroopCount = supports.Count != 0 ? supports.Sum(l=>l.TroopCount):0;
                                    }
                                    _context.SaveChanges();
                                }

                                if (!isGate)
                                {
                                    TplayerBaseInfo.DefenseKillCount += ATotalDead;
                                    TplayerTroop.TroopCount -= s.TargetsWoundedTroop ?? 0;
                                    TplayerTroop.TroopCount -= s.TargetsDeadTroop ?? 0;
                                    TPlayerHospital.InjuredCount = Math.Min(TPlayerHospital.HospitalLevel.HospitalCapacity,
                                        TPlayerHospital.InjuredCount + (s.TargetsWoundedTroop??0));
                                }
                            }

                            var dbEnt =_context.Rally.Where(l => l.Id == s.Id).FirstOrDefault();
                            if (dbEnt != null)
                            {
                                dbEnt.TargetsWoundedTroop = s.TargetsWoundedTroop;
                                dbEnt.TargetsDeadTroop = s.TargetsDeadTroop;
                                dbEnt.TargetBarracksLevel = s.TargetBarracksLevel;
                                dbEnt.TargetWallLevel = s.TargetWallLevel;
                                dbEnt.LootedScrap = s.LootedScrap;
                                dbEnt.PrisonerCount = s.PrisonerCount;
                                dbEnt.TargetScrap = s.TargetScrap;
                                dbEnt.TargetsTroop = s.TargetsTroop;
                                dbEnt.WinnerSide = s.WinnerSide;
                                dbEnt.ATotalTroop = s.ATotalTroop;
                                dbEnt.ATotalDeadTroop = s.ATotalDeadTroop;
                                dbEnt.ATotalWoundedTroop = s.ATotalWoundedTroop;
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
                        .Where(l=>l.ComeBackDate <= now && l.Rally.WinnerSide != null && l.IsActive && !l.IsAbort).ToList();
                    if (rmvList.Count>0)
                    {
                        foreach (RallyPart r in rmvList)
                        {
                            r.IsActive = false;
                            var attackerPlayerHospital = _context.PlayerHospital.Include(l=>l.HospitalLevel).Where(l => l.UserId == r.UserId).FirstOrDefault();
                            var attackerPlayerTroops = _context.PlayerTroop.Where(l => l.UserId == r.UserId).FirstOrDefault();
                            var attackerPlayerBaseInfo = _context.PlayerBaseInfo.Where(l => l.UserId == r.UserId).FirstOrDefault();
                            var attackerPlayerPrison = _context.PlayerPrison.Include(l=>l.PrisonLevel).Where(l => l.UserId == r.UserId).FirstOrDefault();
                            
                            var ABuffs = BuffHelper.GetPlayersTotalBuff(r.UserId).Result;
                            attackerPlayerHospital.InjuredCount = Math.Min(
                                attackerPlayerHospital.HospitalLevel.HospitalCapacity,
                                attackerPlayerHospital.InjuredCount + r.WoundedTroop);

                            attackerPlayerBaseInfo.Scraps += r.LootedScrap;
                            attackerPlayerTroops.TroopCount += r.TroopCount - r.DeadTroop -
                                                               r.WoundedTroop;
                            attackerPlayerPrison.PrisonerCount = Math.Min(
                                attackerPlayerPrison.PrisonerCount + r.PrisonerCount,
                                attackerPlayerPrison.PrisonLevel.MaxPrisonerCount + (int)(attackerPlayerPrison.PrisonLevel.MaxPrisonerCount * ABuffs.PrisonCapacityMultiplier));
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
                    var abortPartList= _context.RallyPart.Include(l=>l.Rally)
                        .Where(l=>l.ComeBackDate <= now && l.IsAbort && l.IsActive).ToList();
                    if (abortPartList.Count>0)
                    {
                        foreach (RallyPart r in abortPartList)
                        { 
                            r.IsActive = false;
                            var attackerPlayerTroops = _context.PlayerTroop.Where(l => l.UserId == r.UserId).FirstOrDefault();
                            attackerPlayerTroops.TroopCount += r.TroopCount - r.DeadTroop - r.WoundedTroop;
                            _context.SaveChanges();
                            // var ccc = SendRallyInfo(new BaseRequest<RallyDTO>()
                            // {
                            //     Data = MapRallyDTO(r.Rally),
                            //     Info = new InfoDto()
                            //     {
                            //         Ip = "",
                            //         AppVersion = "",
                            //         DeviceId = "",
                            //         DeviceModel = "",
                            //         DeviceType = "",
                            //         OsVersion = "",
                            //         UserId = 111
                            //     }
                            // }).Result;
                        }
                    }

                    var rmvRallies = _context.Rally
                        .Include(l => l.RallyParts)
                        .Where(l => !l.RallyParts.Any(o => o.IsActive)).ToList();
                    rmvRallies.ForEach(l=>l.IsActive=false);
                    _context.SaveChanges();
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

            var response = client.PostAsync(new Uri( Environment.GetEnvironmentVariable("WebSocketUrl")+ "/api/News/SendRallyNews"),
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
        var rally = new RallyDTO();

        {
            rally.Id = r.Id;
            rally.Date = r.Date.ToString();
            rally.IsActive = r.IsActive;
            rally.LeaderUsername = r.LeaderUsername;
            rally.LootedScrap = r.LootedScrap;
            rally.PrisonerCount = r.PrisonerCount;
            rally.RallyParts = r.RallyParts?.Select(l => new RallyPartDTO()
            {
                Id = l.Id,
                Username = l.Username,
                ArriveDate = l.ArriveDate?.ToString(),
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
                ComeBackDate = l.ComeBackDate?.ToString(),
                SenderAvatarId = l.SenderAvatarId,
                IsAbort = l.IsAbort
            }).ToList() ?? new List<RallyPartDTO>();
            rally.TargetScrap = r.TargetScrap;
            rally.TargetsTroop = r.TargetsTroop;
            rally.TargetUsername = r.TargetUsername;
            rally.WarDate = r.WarDate.ToString();
            rally.WinnerSide = r.WinnerSide;
            rally.ComeBackDate = r.ComeBackDate.ToString();
            rally.LeaderAvatarId = r.LeaderAvatarId;
            rally.LeaderUserCoord = r.LeaderUserCoord;
            rally.LeaderUserId = r.LeaderUserId;
            rally.RallyStartDate = r.RallyStartDate?.ToString();
            rally.TargetAvatarId = r.TargetAvatarId;
            rally.TargetBarracksLevel = r.TargetBarracksLevel;
            rally.TargetsDeadTroop = r.TargetsDeadTroop;
            rally.TargetsWoundedTroop = r.TargetsWoundedTroop;
            rally.TargetUserCoord = r.TargetUserCoord;
            rally.TargetUserId = r.TargetUserId;
            rally.TargetWallLevel = r.TargetWallLevel;
            rally.LeaderGangId = r.LeaderGangId;
            rally.LeaderGangName = r.LeaderGangName;
            rally.TargetGangId = r.TargetGangId;
            rally.TargetGangName = r.TargetGangName;
            rally.LeaderGangAvatarId = r.LeaderGangAvatarId;
            rally.TargetGangAvatarId = r.TargetGangAvatarId;
            rally.ATotalTroop = r.ATotalTroop;
            rally.ATotalDeadTroop = r.ATotalDeadTroop;
            rally.ATotalWoundedTroop = r.ATotalWoundedTroop;
            rally.IsAbort = r.IsAbort;

        };
        return rally;
    }
    
    
}