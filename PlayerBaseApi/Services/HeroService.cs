﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlayerBaseApi.Entities;
using PlayerBaseApi.Enums;
using PlayerBaseApi.Helpers;
using PlayerBaseApi.Interfaces;
using PlayerBaseApi.Models;
using SharedLibrary.Helpers;
using SharedLibrary.Models;
using SharedLibrary.Models.Hero;

namespace PlayerBaseApi.Services
{
    public class HeroService : IHeroService
    {
        private readonly ILogger<HeroService> _logger;
        private readonly IMapper _mapper;
        private readonly PlayerBaseContext _context;
        private readonly IPlayerBaseService _playerBaseService;
        private readonly IConfiguration _configuration;

        public HeroService(ILogger<HeroService> logger, PlayerBaseContext context, IMapper mapper, IPlayerBaseService playerBaseService, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _playerBaseService = playerBaseService;
        }

        public async Task<TDResponse<List<HeroDTO>>> GetHeroTypes(BaseRequest req, UserDto user)
        {
            TDResponse<List<HeroDTO>> response = new TDResponse<List<HeroDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetHeroTypes");
            try
            {
                var playerBaseInfo = await _context.GetPlayerBaseInfoByUser(user);
                var query = _context.Hero.Where(l => l.IsActive && l.IsApe == playerBaseInfo.IsApe);
                var qlist = await _mapper.ProjectTo<HeroDTO>(query).ToListAsync();
                var ownedHeroes = await _context.PlayerHero.Include(l => l.Hero).Where(l => l.Hero.IsActive && l.UserId == user.Id).ToListAsync();
                var herosInAttack = await _context.Attack.Where(l => l.IsActive && l.AttackerUserId == user.Id)
                    .Select(l => l.AttackerHeroId).ToListAsync();
                response.Data = qlist;
                foreach (var oh in ownedHeroes)
                {
                    qlist.FirstOrDefault(l => l.Id == oh.HeroId).Owned = true;
                    qlist.FirstOrDefault(l => l.Id == oh.HeroId).CurrentLevel = oh.CurrentLevel;
                    qlist.FirstOrDefault(l => l.Id == oh.HeroId).InBattle = herosInAttack.Any(l => l == oh.HeroId);

                }
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }

        public async Task<TDResponse<PlayerHeroDTO>> GetPlayersHeroById(BaseRequest<int> req, UserDto user)
        {
            TDResponse<PlayerHeroDTO> response = new TDResponse<PlayerHeroDTO>();
            var info = InfoDetail.CreateInfo(req, "GetPlayersHeroById");
            try
            {
                var query = _context.PlayerHero.Include(l => l.Hero).Where(l => l.Hero.IsActive && l.UserId == user.Id && l.HeroId == req.Data);
                var qlist = await _mapper.ProjectTo<PlayerHeroDTO>(query).FirstOrDefaultAsync();
                if (qlist == null)
                {
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    response.SetError(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                qlist.ThresholdLeft = await _context.HeroLevelThreshold.Where(l => l.HeroId == req.Data && l.Level == qlist.CurrentLevel).Select(l => l.Experience).FirstOrDefaultAsync();
                qlist.ThresholdRight = await _context.HeroLevelThreshold.Where(l => l.HeroId == req.Data && l.Level == qlist.CurrentLevel + 1).Select(l => l.Experience).FirstOrDefaultAsync();
                response.Data = qlist;
                var getBuff = await BuffHelper.GetHeroTotalBuff(user.Id, req.Data);
                if (getBuff!=null)
                {
                    response.Data.TotalBuff = _mapper.Map<BuffDTO>(getBuff);
                }
                
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }

        public async Task<TDResponse<bool>> AddHeroExperience(BaseRequest<AddHeroExperienceRequest> req, UserDto user)
        {
            TDResponse<bool> response = new TDResponse<bool>();
            var info = InfoDetail.CreateInfo(req, "AddHeroExperience");
            try
            {
                var pH = await _context.PlayerHero.Include(l => l.Hero)
                    .Where(l => l.UserId == user.Id && l.HeroId == req.Data.HeroId && l.EndDate == null).FirstOrDefaultAsync();
                if (pH == null)
                {
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    response.SetError(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (pH.CurrentLevel >= pH.Hero.MaxLevel)
                {
                    info.AddInfo(OperationMessages.HeroAllreadyMaxLevel);
                    response.SetError(OperationMessages.HeroAllreadyMaxLevel);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var threshold = await _context.HeroLevelThreshold
                    .Where(l => l.HeroId == req.Data.HeroId && l.Level == pH.CurrentLevel + 1)
                    .Select(l => l.Experience).FirstOrDefaultAsync();
                pH.Exp += req.Data.Experience;

                response.Data = false;
                if (pH.Exp >= threshold)
                {
                    pH.CurrentLevel = await _context.HeroLevelThreshold
                        .Where(l => l.HeroId == pH.HeroId && l.Experience <= pH.Exp)
                        .OrderByDescending(l => l.Level).Select(l => l.Level).FirstOrDefaultAsync();
                    response.Data = true;
                }
                await _context.SaveChangesAsync();
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }

        public async Task<TDResponse<bool>> UseHeroExp(BaseRequest<UseHeroExperienceRequest> req, UserDto user)
        {
            TDResponse<bool> response = new TDResponse<bool>();
            var info = InfoDetail.CreateInfo(req, "UseHeroExp");
            try
            {
                var pH = await _context.PlayerHero.Include(l => l.Hero)
                    .Where(l => l.UserId == user.Id && l.HeroId == req.Data.HeroId && l.EndDate == null).FirstOrDefaultAsync();
                var oldLevel = pH.CurrentLevel;
                if (pH == null || req.Data == null)
                {
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    response.SetError(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var playerItems = await _context.PlayerItem.Include(l => l.Item)
                   .Where(l => l.ItemId == req.Data.ItemId && l.UserId == user.Id && l.Item.ItemTypeId == (int)ItemTypeEnum.HeroXp).FirstOrDefaultAsync();

                if (pH.CurrentLevel >= pH.Hero.MaxLevel)
                {
                    info.AddInfo(OperationMessages.HeroAllreadyMaxLevel);
                    response.SetError(OperationMessages.HeroAllreadyMaxLevel);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if ((playerItems == null || playerItems.Count < req.Data.Count) && !req.Data.Buy)
                {
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (req.Data.Buy && (playerItems == null || playerItems.Count < req.Data.Count))
                {
                    var marketItemId = await _context.MarketItem
                        .Where(l => l.ItemId == req.Data.ItemId && l.Item.ItemTypeId == (int)ItemTypeEnum.HeroXp && l.IsActive)
                        .Select(l => l.Id).FirstOrDefaultAsync();
                    var marketReq = new BaseRequest<BuyMarketItemRequest>()
                    {
                        Info = req.Info,
                        Data = new BuyMarketItemRequest()
                        {
                            Count = req.Data.Count,
                            MarketItemId = marketItemId,
                        }
                    };
                    var buyResponse = await _playerBaseService.BuyMarketItem(marketReq, user);
                    if (buyResponse.HasError)
                    {
                        response.SetError(buyResponse.Message);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                    else
                    {
                        playerItems = await _context.PlayerItem.Include(l => l.Item)
                            .Where(l => l.ItemId == req.Data.ItemId && l.UserId == user.Id && l.Item.ItemTypeId == (int)ItemTypeEnum.HeroXp).FirstOrDefaultAsync();
                    }
                }

                var threshold = await _context.HeroLevelThreshold
                    .Where(l => l.HeroId == req.Data.HeroId && l.Level == pH.CurrentLevel + 1)
                    .Select(l => l.Experience).FirstOrDefaultAsync();

                pH.Exp += req.Data.Count * (playerItems.Item.Value1 ?? 0);
                playerItems.Count -= req.Data.Count;

                response.Data = false;
                if (pH.Exp >= threshold)
                {
                    pH.CurrentLevel = await _context.HeroLevelThreshold
                        .Where(l => l.HeroId == pH.HeroId && l.Experience <= pH.Exp)
                        .OrderByDescending(l => l.Level).Select(l => l.Level).FirstOrDefaultAsync();
                    response.Data = true;
                }
                pH.TalentPoint += pH.CurrentLevel - oldLevel;
                await _context.SaveChangesAsync();
                response.SetSuccess(OperationMessages.UseHeroExpSuccess);
                info.AddInfo(OperationMessages.UseHeroExpSuccess);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }

        public async Task<TDResponse<List<UsableItemDTO>>> GetPlayersHeroXpItems(BaseRequest req, UserDto user)
        {
            TDResponse<List<UsableItemDTO>> response = new TDResponse<List<UsableItemDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetPlayersHeroXpItems");
            try
            {
                var pq = _context.PlayerItem.Include(l => l.Item)
                   .Where(l => l.UserId == user.Id && l.Item.ItemTypeId == (int)ItemTypeEnum.HeroXp && l.Count > 0).OrderBy(l => l.ItemId);
                var playerItems = await _mapper.ProjectTo<PlayerItemDTO>(pq).ToListAsync();


                var heroXpItems = await _mapper.ProjectTo<UsableItemDTO>(_context.MarketItem
                    .Where(l => l.IsActive && l.Item.ItemTypeId == (int)ItemTypeEnum.HeroXp)
                    .OrderBy(l => l.MarketOrderId)).ToListAsync();
                foreach (var sui in heroXpItems)
                {
                    sui.Count = playerItems.FirstOrDefault(l => l.Item.Id == sui.Item.Id)?.Count ?? 0;
                }
                response.Data = heroXpItems.GroupBy(l => l.Count == 0).OrderBy(l => l.Key).SelectMany(l => l).ToList();
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }

        public async Task<TDResponse<List<TalentTreeDTO>>> GetHeroTalentTreeByHeroId(BaseRequest<int> req, UserDto user)
        {
            TDResponse<List<TalentTreeDTO>> response = new TDResponse<List<TalentTreeDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetHeroTalentTreeByHeroId");
            try
            {
                var talentTrees = _context.TalentTree;
                var qlist = await _mapper.ProjectTo<TalentTreeDTO>(talentTrees).ToListAsync();
                for (int i = 0; i < qlist.Count; i++)
                {
                    var qq = _context.TalentTreeNode
                        .Where(l => l.IsActive && l.TalentTreeId == qlist[i].Id && l.HeroId == req.Data).OrderBy(l => l.PlaceId);
                    var playerTalentTree = await _context.PlayerTalentTreeNode
                        .Include(l=>l.TalentTreeNodeLevel).ThenInclude(l=>l.Buff)
                        .Where(l => l.TalentTreeNodeLevel.TalentTreeNode.TalentTreeId == qlist[i].Id && l.UserId == user.Id).ToListAsync();
                    qlist[i].NodeList = await _mapper.ProjectTo<TalentTreeNodeDTO>(qq).ToListAsync();
                    qlist[i].NodeList.ForEach(l => l.TalentTreeNodeLevel = _mapper.Map<TalentTreeNodeLevel,TalentTreeNodeLevelDTO>(playerTalentTree.Where(k => k.TalentTreeNodeLevel.TalentTreeNodeId == l.Id).Select(l=>l.TalentTreeNodeLevel).FirstOrDefault()));
                }
                response.Data = qlist;
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }


        public async Task<TDResponse> AddHeroTalentNodeByNodeId(BaseRequest<int> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "AddHeroTalentNodeByNodeId");
            try
            {
                var existEnt = await _context.PlayerTalentTreeNode
                    .Include(l => l.TalentTreeNodeLevel)
                    .ThenInclude(l=>l.TalentTreeNode)
                    .Where(l => l.TalentTreeNodeLevel.TalentTreeNodeId == req.Data && l.UserId == user.Id)
                    .FirstOrDefaultAsync();
                if (existEnt != null)
                {
                    var pq = await _context.PlayerHero
                        .Where(l => l.UserId == user.Id && l.HeroId == existEnt.TalentTreeNodeLevel.TalentTreeNode.HeroId)
                        .FirstOrDefaultAsync();
                    if (pq!.TalentPoint < 1)
                    {
                        response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                        info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                    if (existEnt.TalentTreeNodeLevel.TalentTreeNode.Capacity == existEnt.Level)
                    {
                        response.SetError(OperationMessages.HeroAllreadyMaxLevel);
                        info.AddInfo(OperationMessages.HeroAllreadyMaxLevel);
                        _logger.LogInformation(info.ToString());
                        return response;

                    }
                    pq.TalentPoint--;
                    existEnt.Level++;
                    existEnt.TalentTreeNodeLevelId = await _context.TalentTreeNodeLevel
                        .Where(l => l.TalentTreeNodeId == existEnt.TalentTreeNodeLevel.TalentTreeNodeId &&
                                    l.Level == existEnt.Level).Select(l => l.Id).FirstOrDefaultAsync();
                }
                else
                {
                    var ttn = await _context.TalentTreeNode
                        .Include(l => l.Hero)
                        .Where(l => l.IsActive && l.Id == req.Data)
                        .FirstOrDefaultAsync();
                    if (ttn == null)
                    {
                        response.SetError(OperationMessages.DbItemNotFound);
                        info.AddInfo(OperationMessages.DbItemNotFound);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                    if (!(await _context.PlayerHero.Where(l => l.UserId == user.Id && l.HeroId == ttn.HeroId).AnyAsync()))//TODO: Enddate için ekleme yapılmalı
                    {
                        response.SetError(OperationMessages.PlayerHaveNoHero);
                        info.AddInfo(OperationMessages.PlayerHaveNoHero);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }

                    var pq = await _context.PlayerHero.Where(l => l.UserId == user.Id && l.HeroId == ttn.HeroId).FirstOrDefaultAsync();
                    if (pq!.TalentPoint < 1)
                    {
                        response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                        info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }

                    var ent = new PlayerTalentTreeNode()
                    {
                        Level = 1,
                        TalentTreeNodeLevelId = await _context.TalentTreeNodeLevel
                            .Where(l => l.TalentTreeNodeId == req.Data &&
                                        l.Level == 1).Select(l => l.Id).FirstOrDefaultAsync(),
                        UserId = user.Id
                    };
                    pq.TalentPoint--;
                    await _context.AddAsync(ent);
                }
                await _context.SaveChangesAsync();
                response.SetSuccess(OperationMessages.AddHeroTalentNodeByNodeIDSuccess);
                info.AddInfo(OperationMessages.AddHeroTalentNodeByNodeIDSuccess);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }

        
        public async Task<TDResponse> ExchangeTalentAndCard(BaseRequest<ExchangeTalentAndCardRequest> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "ExchangeTalentAndCard");
            try
            {
                var pq = await _context.PlayerHero.Where(l => l.UserId == user.Id && l.HeroId == req.Data.HeroId).FirstOrDefaultAsync();
                if (pq == null)
                {
                    response.SetError(OperationMessages.PlayerHaveNoHero);
                    info.AddInfo(OperationMessages.PlayerHaveNoHero);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (pq.TalentPoint != 0 || pq.CurrentLevel != pq.Hero.MaxLevel)
                {
                    response.SetError(OperationMessages.PlayerNotHavePermission);
                    info.AddInfo(OperationMessages.PlayerNotHavePermission);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var pb = await _context.PlayerBaseInfo
                    .Where(l => l.UserId == user.Id).FirstOrDefaultAsync();

                switch ((HeroRarity)pq.Hero.Rarity)
                {
                    case HeroRarity.Rare:
                        if (pb.RareHeroCards<req.Data.Count*10)
                        {
                            response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                            info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                            _logger.LogInformation(info.ToString());
                            return response;
                        }

                        pb.RareHeroCards -= req.Data.Count * 10;
                        break;
                    case HeroRarity.Epic:
                        if (pb.EpicHeroCards<req.Data.Count*10)
                        {
                            response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                            info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                            _logger.LogInformation(info.ToString());
                            return response;
                        }
                        pb.EpicHeroCards -= req.Data.Count * 10;
                        break;
                    case HeroRarity.Legendary:
                        if (pb.LegendaryHeroCards<req.Data.Count*10)
                        {
                            response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                            info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                            _logger.LogInformation(info.ToString());
                            return response;
                        }
                        pb.LegendaryHeroCards -= req.Data.Count * 10;
                        break;
                }

                pq.TalentPoint += req.Data.Count;
                await _context.SaveChangesAsync();
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }


        public async Task<TDResponse<List<HeroSkillDTO>>> GetHeroSkillsByHeroId(BaseRequest<int> req, UserDto user)
        {
            TDResponse<List<HeroSkillDTO>> response = new TDResponse<List<HeroSkillDTO>>();
            var info = InfoDetail.CreateInfo(req, "GetHeroSkillsByHeroId");
            try
            {
                var query = _context.HeroSkill.Where(l => l.HeroId == req.Data).OrderBy(l => l.PlaceId);
                var dto = await _mapper.ProjectTo<HeroSkillDTO>(query).ToListAsync();
                foreach (var item in dto)
                {
                    var temp = await _context.PlayerHeroSkillLevel.Include(z => z.HeroSkillLevel).Where(o => o.UserId == user.Id && o.HeroSkillLevel.HeroSkillId == item.Id).FirstOrDefaultAsync();
                    item.Level = temp?.HeroSkillLevel?.Level ?? 0;
                    item.BuffId = temp?.HeroSkillLevel?.Level ?? 0;
                    item.UpgradeCost = temp?.HeroSkillLevel == null ?
                        await _context.HeroSkillLevel.Where(o => o.HeroSkillId == item.Id && o.Level == 1).Select(l => l.Cost).FirstOrDefaultAsync()
                        :
                        await _context.HeroSkillLevel.Where(o => o.HeroSkill == temp.HeroSkillLevel.HeroSkill && o.Level == temp.HeroSkillLevel.Level + 1).Select(l => l.Cost).FirstOrDefaultAsync();
                }

                response.Data = dto;
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }


        public async Task<TDResponse> UpgradeHeroSkillBySkillId(BaseRequest<int> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "UpgradeHeroSkillBySkillId");
            try
            {
                var heroSkill = await _context.HeroSkill.Include(l => l.Hero).Where(l => l.Id == req.Data).FirstOrDefaultAsync();
                if (heroSkill == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var playerInfo = await _context.PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();

                var playerHero = await _context.PlayerHero.Include(l => l.Hero).Where(l => l.HeroId == heroSkill.HeroId && l.UserId == user.Id).FirstOrDefaultAsync();
                if (playerHero == null || playerInfo == null)
                {
                    response.SetError(OperationMessages.PlayerHaveNoHero);
                    info.AddInfo(OperationMessages.PlayerHaveNoHero);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var currentHeroSkillLevel = await _context.PlayerHeroSkillLevel.Include(l => l.HeroSkillLevel).Where(l => l.HeroSkillLevel.HeroSkillId == req.Data && l.UserId == user.Id).FirstOrDefaultAsync();
                var cost = 0;
                if (currentHeroSkillLevel == null)
                {
                    var heroSkillLevel = await _context.HeroSkillLevel.Where(l => l.HeroSkillId == req.Data && l.Level == 1).FirstOrDefaultAsync();
                    if (heroSkillLevel == null)
                    {
                        response.SetError(OperationMessages.InputError);
                        info.AddInfo(OperationMessages.InputError);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                    cost = heroSkillLevel.Cost;
                    var newEnt = new PlayerHeroSkillLevel()
                    {
                        UserId = user.Id,
                        HeroSkillLevelId = heroSkillLevel.Id
                    };
                    await _context.AddAsync(newEnt);
                }
                else
                {
                    if (currentHeroSkillLevel.HeroSkillLevel.Level == heroSkill.MaksLevel)
                    {
                        response.SetError(OperationMessages.HeroAllreadyMaxLevel);
                        info.AddInfo(OperationMessages.HeroAllreadyMaxLevel);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                    var heroSkillLevell = await _context.HeroSkillLevel.Where(l => l.HeroSkillId == req.Data && l.Level == currentHeroSkillLevel.HeroSkillLevel.Level + 1).FirstOrDefaultAsync();
                    if (heroSkillLevell == null)
                    {
                        response.SetError(OperationMessages.InputError);
                        info.AddInfo(OperationMessages.InputError);
                        _logger.LogInformation(info.ToString());
                        return response;
                    }
                    currentHeroSkillLevel.HeroSkillLevelId = heroSkillLevell.Id;
                    cost = heroSkillLevell.Cost;
                }
                var hasError = false;
                switch (playerHero.Hero.Rarity)
                {
                    case (int)HeroRarity.Rare:
                        hasError = playerInfo.RareHeroCards < cost;
                        playerInfo.RareHeroCards -= cost;
                        break;
                    case (int)HeroRarity.Epic:
                        hasError = playerInfo.EpicHeroCards < cost;
                        playerInfo.EpicHeroCards -= cost;
                        break;
                    case (int)HeroRarity.Legendary:
                        hasError = playerInfo.LegendaryHeroCards < cost;
                        playerInfo.LegendaryHeroCards -= cost;
                        break;
                }
                if (hasError)
                {
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                await _context.SaveChangesAsync();
                response.SetSuccess(OperationMessages.UpgradeHeroSkillSuccess);
                info.AddInfo(OperationMessages.UpgradeHeroSkillSuccess);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }

        public async Task<TDResponse> BuyHeroByHeroId(BaseRequest<int> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "BuyHeroByHeroId");
            try
            {
                var isAllreadyExist = await _context.PlayerHero.Where(l => l.UserId == user.Id && l.HeroId == req.Data).AnyAsync();
                if (isAllreadyExist)
                {
                    response.SetError(OperationMessages.HeroAllreadyExist);
                    info.AddInfo(OperationMessages.HeroAllreadyExist);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var playerInfo = await _context.GetPlayerBaseInfoByUser(user);
                if (playerInfo == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var hero = await _context.Hero.Where(l => l.Id == req.Data && l.IsActive && l.IsApe == playerInfo.IsApe).FirstOrDefaultAsync();
                if (hero == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var hasError = false;
                switch (hero.Rarity)
                {
                    case (int)HeroRarity.Rare:
                        if (playerInfo.RareHeroCards < hero.Price)
                        {
                            hasError = true;
                        }
                        playerInfo.RareHeroCards -= hero.Price;
                        break;
                    case (int)HeroRarity.Epic:
                        if (playerInfo.EpicHeroCards < hero.Price)
                        {
                            hasError = true;
                        }
                        playerInfo.EpicHeroCards -= hero.Price;
                        break;
                    case (int)HeroRarity.Legendary:
                        if (playerInfo.LegendaryHeroCards < hero.Price)
                        {
                            hasError = true;
                        }
                        playerInfo.LegendaryHeroCards -= hero.Price;
                        break;
                }
                if (hasError)
                {
                    response.SetError(OperationMessages.PlayerDoesNotHaveResource);
                    info.AddInfo(OperationMessages.PlayerDoesNotHaveResource);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                await _context.AddAsync(new PlayerHero()
                {
                    SkillPoint = 0,
                    CurrentLevel = 1,
                    Exp = 0,
                    HeroId = req.Data,
                    TalentPoint = 1,
                    UserId = user.Id,
                    EndDate = null
                });

                await _context.SaveChangesAsync();
                response.SetSuccess(OperationMessages.BuyHeroByHeroIdSuccess);
                info.AddInfo(OperationMessages.BuyHeroByHeroIdSuccess);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }




    }
}
