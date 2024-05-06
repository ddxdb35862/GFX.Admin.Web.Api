using ET;
using Furion.Logging;
using RazorEngine;

namespace GameFrameX.Application.Game;

/// <summary>
/// 游戏阵容服务
/// </summary>
[ApiDescriptionSettings(GameConst.GroupName, Order = 100)]
[AllowAnonymous]
public class GameFormationBaseService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<GameUserEntity> _rep;
    private readonly IHttpClientFactory _httpClientFactory;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rep"></param>
    /// <param name="httpClientFactory"></param>
    public GameFormationBaseService(SqlSugarRepository<GameUserEntity> rep, IHttpClientFactory httpClientFactory)
    {
        _rep = rep;
        _httpClientFactory = httpClientFactory;
    }


    /// <summary>
    /// 分页查询游戏阵容
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<GameFormationBaseOutput>> Page(GameFormationBaseInput input)
    {
        return null;
    }

    /// <summary>
    /// 增加游戏阵容
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task Add(AddGameFormationBaseInput input)
    {
        //var entity = input.Adapt<GameAreaEntity>();
        //await Repository.InsertAsync(entity);
    }

    /// <summary>
    /// 逻辑删除游戏阵容
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "LogicDelete")]
    public async Task<bool> LogicDelete(DeleteGameFormationBaseInput input)
    {
        List<GameFormationBaseOutput> list = new List<GameFormationBaseOutput>();
        var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
        BattleFormationProto proto = await CopyFormation(input);
        proto.Status = 1;
        string requestBody = MongoHelper.ToJson(proto);
        HttpContent content = new StringContent(requestBody);//UTF8
        var response = await client.PostAsync("/admin/pool_battle_formation/addOrUpdate", content);
        var result = response.Content.ReadAsStringAsync().Result;
        var body = MongoHelper.FromJson<HttpCommonResponse>(result);
        return body.Error == ErrorCode.ERR_Success;
    }

    /// <summary>
    /// 删除游戏阵容
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task<bool> Delete(DeleteGameFormationBaseInput input)
    {
        return false;
        //var entity = await Repository.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        //await Repository.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新游戏阵容
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task<bool> Update(UpdateGameFormationBaseInput input)
    {
        List<GameFormationBaseOutput> list = new List<GameFormationBaseOutput>();
        var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
        BattleFormationProto proto = await CopyFormation(input);
        string requestBody = MongoHelper.ToJson(proto);
        HttpContent content = new StringContent(requestBody);//UTF8
        var response = await client.PostAsync("/admin/pool_battle_formation/addOrUpdate", content);
        var result = response.Content.ReadAsStringAsync().Result;
        var body = MongoHelper.FromJson<HttpCommonResponse>(result);
        return body.Error == ErrorCode.ERR_Success;
    }

    /// <summary>
    /// 获取游戏阵容
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<GameFormationBase> Get([FromQuery] QueryByIdGameFormationBaseInput input)
    {
        GameFormationBaseOutput detail = new GameFormationBaseOutput();
        var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
        var response = await client.GetAsync("/admin/pool_battle_formation/detail?id="+input.Id);
        var result = response.Content.ReadAsStringAsync().Result;
        var body = MongoHelper.FromJson<HttpGetBattleFormationResponse>(result);
        if (body.Error == ErrorCode.ERR_Success)
        { 
            var listFrom = body.BattleFormationProto;
            CopyFormation(out detail, listFrom);
        }
        return detail;
    }
    
    /// <summary>
    /// 获取游戏阵容列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "MergeFromOnline")]
    public async Task<bool> MergeFromOnline()
    {
        long start = DateTime.Now.Millisecond;
        List<GameFormationBaseOutput> list = new List<GameFormationBaseOutput>();
        var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
        var response = await client.PostAsync("/admin/pool_battle_formation/merge_from_online", null);
        var result = response.Content.ReadAsStringAsync().Result;
        var body = MongoHelper.FromJson<HttpCommonResponse>(result);
        Log.Information($"merge formation span {DateTime.Now.Millisecond - start} ms, {body.Message}");
        return body.Error == ErrorCode.ERR_Success;
    }

    /// <summary>
    /// 获取游戏阵容列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<GameFormationBaseOutput>> List([FromQuery] GameFormationBaseInput input)
    {
        List<GameFormationBaseOutput> list = new List<GameFormationBaseOutput>();
        var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
        var response = await client.GetAsync("/admin/pool_battle_formation/list?roundId="+input.RoundId+"&rank="+input.Rank+"&careerConfigId="+input.CareerConfigId+"&careerSkinConfigId="+input.CareerSkinConfigId);
        var result = response.Content.ReadAsStringAsync().Result;
        var body = MongoHelper.FromJson<HttpGetBattleFormationsResponse>(result);
        if (body.Error == ErrorCode.ERR_Success)
        { 
            var listFrom = body.BattleFormationProtos;
            CopyList(ref list, listFrom);
        }
        //return await response.Content.ReadAsStringAsync();
        //return await Repository.AsQueryable().Select<GameFormationBaseEntityOutput>().ToListAsync();
        return list;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <param name="listFrom"></param>
    private void CopyList(ref List<GameFormationBaseOutput> list, List<BattleFormationProto> listFrom)
    {
        if (listFrom.IsNullOrEmpty())
        {
            return;
        }

        foreach (var formationProto in listFrom)
        {
            CopyFormation(out GameFormationBaseOutput to, formationProto);
            list.Add(to);
        }
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="from"></param>
    private async Task<BattleFormationProto> CopyFormation(DeleteGameFormationBaseInput from)
    {
        long id = from.Id;
        GameFormationBase origin = await this.Get(new QueryByIdGameFormationBaseInput(){Id = id});
        CopyFormation(out BattleFormationProto to, origin);
        return to;
    }

    /// <summary>
    /// 更改
    /// </summary>
    /// <param name="from"></param>
    private async Task<BattleFormationProto> CopyFormation(UpdateGameFormationBaseInput from)
    {
        long id = from.Id;
        GameFormationBase origin = await this.Get(new QueryByIdGameFormationBaseInput(){Id = id});
        CopyFormation(out BattleFormationProto to, origin);

        to.DifficultyLevel = (int)from.DifficultyLevelEnum;

        var gameItemLayerItemEntities = to.ItemLayerItemProtos;
        CopyItems(ref gameItemLayerItemEntities, from.ItemLayerItems);
        
        return to;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="to"></param>
    /// <param name="from"></param>
    private void CopyFormation(out BattleFormationProto to, GameFormationBase from)
    {
        to = new BattleFormationProto();
        //TODO ....
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="to"></param>
    /// <param name="from"></param>
    private async Task<BattleFormationProto> CopyFormation(AddGameFormationBaseInput from)
    {
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="to"></param>
    /// <param name="from"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void CopyFormation(out GameFormationBaseOutput to, BattleFormationProto from)
    {
        to = new GameFormationBaseOutput();
        to.Id = from.Id;
        to.Rank = from.PlayerRank;
        to.CareerConfigId = 0;//from.CareerConfigId;
        to.CareerSkinConfigId = from.PlayerCareerSkinConfigId;
        to.PlayerName = from.PlayerName;
        to.PlayerAvatar = from.PlayerIcon;
        to.PlayerUnitId = from.PlayerUnitId;
        to.RoundId = from.RoundId;
        to.CanComposite = from.CanComposite;
        
        var gameCareerItemEntities = to.CareerItems;
        CopyItems(ref gameCareerItemEntities, from.CareerItemProtos);
        var gameCapacityLayerItemEntities = to.CapacityLayerItems;
        CopyItems(ref gameCapacityLayerItemEntities, from.CapacityLayerItemProtos);
        var gameItemLayerItemEntities = to.ItemLayerItems;
        CopyItems(ref gameItemLayerItemEntities, from.ItemLayerItemProtos);
        
        //var gameItemCompositeEntities = to.ItemComposites;
        //CopyComposite(ref gameItemCompositeEntities, from.CompositeGroupIds);
    }
    /// <summary>
    /// 复制Item
    /// </summary>
    /// <param name="gameItemEntities"></param>
    /// <param name="fromItemProtos"></param>
    private void CopyItems(ref List<GameItemEntity> gameItemEntities, List<ItemProto> fromItemProtos)
    {
        if (fromItemProtos.IsNullOrEmpty())
        {
            return;
        }
        gameItemEntities = new List<GameItemEntity>(fromItemProtos.Count);
        foreach (var fromItem in fromItemProtos)
        {
            CopyItem(out GameItemEntity toItem, fromItem);
            gameItemEntities.Add(toItem);
        }
    }

    private void CopyItem(out GameItemEntity gameItemEntity, ItemProto fromItem)
    {
        gameItemEntity = new GameItemEntity();
        gameItemEntity.Id = fromItem.Id;
        gameItemEntity.ConfigId = fromItem.ConfigId;
        gameItemEntity.Bag = fromItem.Bag;
        gameItemEntity.Discount = fromItem.Discount;
        gameItemEntity.Locked = fromItem.Locked;
        gameItemEntity.Sold = fromItem.Sold;
        gameItemEntity.Price = fromItem.Price;
        gameItemEntity.IndexId = fromItem.IndexId;
        gameItemEntity.Z_Rotation = fromItem.Z_Rotation;
        gameItemEntity.CentrePosX = fromItem.CentrePosX;
        gameItemEntity.CentrePosY = fromItem.CentrePosY;
        gameItemEntity.CurrentBelongItemCompositeId = fromItem.CurrentBelongItemCompositeId;
        gameItemEntity.BelongItemCompositeIds = fromItem.BelongItemCompositeIds;
    }

    /// <summary>
    /// 复制Item
    /// </summary>
    /// <param name="gameItemEntities"></param>
    /// <param name="fromItemProtos"></param>
    private void CopyItems(ref List<ItemProto> gameItemEntities, List<GameItemEntity> fromItemProtos)
    {
        if (fromItemProtos.IsNullOrEmpty())
        {
            return;
        }
        gameItemEntities = new List<ItemProto>(fromItemProtos.Count);
        foreach (var fromItem in fromItemProtos)
        {
            CopyItem(out ItemProto toItem, fromItem);
            gameItemEntities.Add(toItem);
        }
    }

    private void CopyItem(out ItemProto gameItemEntity, GameItemEntity fromItem)
    {
        gameItemEntity = new ItemProto();
        gameItemEntity.Id = fromItem.Id;
        gameItemEntity.ConfigId = fromItem.ConfigId;
        gameItemEntity.Bag = fromItem.Bag;
        gameItemEntity.Discount = fromItem.Discount;
        gameItemEntity.Locked = fromItem.Locked;
        gameItemEntity.Sold = fromItem.Sold;
        gameItemEntity.Price = fromItem.Price;
        gameItemEntity.IndexId = fromItem.IndexId;
        gameItemEntity.Z_Rotation = fromItem.Z_Rotation;
        gameItemEntity.CentrePosX = fromItem.CentrePosX;
        gameItemEntity.CentrePosY = fromItem.CentrePosY;
        gameItemEntity.CurrentBelongItemCompositeId = fromItem.CurrentBelongItemCompositeId;
        gameItemEntity.BelongItemCompositeIds = fromItem.BelongItemCompositeIds;
    }

    /// <summary>
    /// 复制合成关系
    /// </summary>
    /// <param name="gameItemCompositeEntities"></param>
    /// <param name="fromCompositeGroupIds"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void CopyComposite(ref List<GameCompositeItemEntity> gameItemCompositeEntities, List<ItemCompositeProto> fromCompositeGroupIds)
    {
        throw new NotImplementedException();
    }

}

