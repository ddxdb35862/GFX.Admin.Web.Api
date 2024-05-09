using ET;
using Furion.Logging;

namespace GameFrameX.Application.Game;

/// <summary>
/// 游戏阵容服务
/// </summary>
[ApiDescriptionSettings(GameConst.GroupName, Order = 100)]
[AllowAnonymous]
public class GameFormationBaseService : IDynamicApiController, ITransient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly GameCareerSkinConfigService _gameCareerSkinConfigService;
    private readonly GameItemConfigService _gameItemConfigService;
    private readonly GameItemTransformConfigService _gameItemTransformConfigService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpClientFactory"></param>
    /// <param name="gameCareerSkinConfigService"></param>
    public GameFormationBaseService(IHttpClientFactory httpClientFactory, GameCareerSkinConfigService gameCareerSkinConfigService, GameItemConfigService gameItemConfigService, GameItemTransformConfigService gameItemTransformConfigService)
    {
        _httpClientFactory = httpClientFactory;
        _gameCareerSkinConfigService = gameCareerSkinConfigService;
        _gameItemConfigService = gameItemConfigService;
        _gameItemTransformConfigService = gameItemTransformConfigService;
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
        BattleFormationProto proto = await CopyFormationToDelete(input);
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
        return await this.LogicDelete(input);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="deleteInput"></param>
    private async Task<BattleFormationProto> CopyFormationToDelete(DeleteGameFormationBaseInput deleteInput)
    {
        var id = long.Parse(deleteInput.S_Id);
        var origin = await this.Get(new QueryByIdGameFormationBaseInput(){Id = id});
        CopyFormation(origin, out var to);
        to.IsDeleted = 1;
        return to;
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
        var body = MongoHelper.FromJson<HttpGetPoolFormationResponse>(result);
        if (body.Error == ErrorCode.ERR_Success)
        { 
            var listFrom = body.BattleFormationProto;
            CopyFormation(listFrom, out detail);
        }
        return detail;
    }
    
    /// <summary>
    /// 获取游戏阵容列表
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "MergeOnline")]
    public async Task<bool> MergeOnline([FromBody] GameFormationBaseInput input)
    {
        if (string.IsNullOrEmpty(input.ToMergePlayerUnitIds))
        {
            return false;
        }
        long start = DateTime.Now.Millisecond;
        var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
        var response = await client.PostAsync("/admin/pool_battle_formation/merge_online?playerIds="+input.ToMergePlayerUnitIds, null);
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
    [HttpPost]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<GameFormationBaseOutput>> List([FromBody] GameFormationBaseInput input)
    {
        List<GameFormationBaseOutput> list = new List<GameFormationBaseOutput>();
        var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
        var response = await client.GetAsync("/admin/pool_battle_formation/list?roundId="+input.RoundId+"&rank="+input.Rank+"&careerConfigId="+input.CareerConfigId+"&careerSkinConfigId="+input.CareerSkinConfigId);
        var result = response.Content.ReadAsStringAsync().Result;
        var body = MongoHelper.FromJson<HttpGetPoolFormationsResponse>(result);
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
    /// <param name="tos"></param>
    /// <param name="froms"></param>
    private void CopyList(ref List<GameFormationBaseOutput> tos, List<BattleFormationProto> froms)
    {
        if (froms.IsNullOrEmpty())
        {
            return;
        }

        foreach (var from in froms)
        {
            CopyFormation(from, out GameFormationBaseOutput to);
            tos.Add(to);
        }
    }

    /// <summary>
    /// 更改
    /// </summary>
    /// <param name="updateInput"></param>
    private async Task<BattleFormationProto> CopyFormation(UpdateGameFormationBaseInput updateInput)
    {
        long id = long.Parse(updateInput.S_Id);
        GameFormationBase origin = await this.Get(new QueryByIdGameFormationBaseInput(){Id = id});
        CopyFormation(origin, out BattleFormationProto to);

        to.DifficultyLevel = (int)updateInput.DifficultyLevelEnum;
        to.Remark = updateInput.Remark;

        if (!updateInput.ItemLayerItems.IsNullOrEmpty())
        {
            CopyItems(updateInput.ItemLayerItems, out List<ItemProto> gameItemLayerItemEntities);
            to.ItemLayerItemProtos = gameItemLayerItemEntities;
        }

        if (!updateInput.CapacityLayerItems.IsNullOrEmpty())
        {
            CopyItems(updateInput.CapacityLayerItems, out List<ItemProto> gameCapacityLayerItemEntities);
            to.CapacityLayerItemProtos = gameCapacityLayerItemEntities;
        }
        
        return to;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="to"></param>
    /// <param name="from"></param>
    private void CopyFormation(GameFormationBase from, out BattleFormationProto to)
    {
        to = new BattleFormationProto();
        to.Id = from.Id;
        to.RoundId = from.RoundId;
        to.PlayerRank = from.PlayerRank;
        //to.PlayerCareerConfigId = from.PlayerCareerConfigId;
        to.PlayerCareerSkinConfigId = from.PlayerCareerSkinConfigId;
        to.PlayerName = from.PlayerName;
        to.PlayerIcon = from.PlayerIcon;
        to.PlayerUnitId = from.PlayerUnitId;
        to.CanComposite = from.CanComposite;
        to.CreateTime = from.CreateTime;
        to.UpdateTime = from.UpdateTime;
        to.IsDeleted = from.IsDeleted;
        to.DifficultyLevel = (int)from.DifficultyLevelEnum;
        to.Remark = from.Remark;
        
        CopyItems(from.CareerItems, out List<ItemProto> gameCareerItemEntities);
        to.CareerItemProtos = gameCareerItemEntities;
        
        CopyItems(from.CapacityLayerItems, out List<ItemProto> gameCapacityLayerItemEntities);
        to.CapacityLayerItemProtos = gameCapacityLayerItemEntities;
        
        CopyItems(from.ItemLayerItems, out List<ItemProto> gameItemLayerItemEntities);
        to.ItemLayerItemProtos = gameItemLayerItemEntities;
    }

    private static string ShowAppendDate(long ms)
    {
        var create = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(ms);
        return create.ToString("yyyyMMdd HH:mm:ss");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="to"></param>
    /// <param name="from"></param>
    private void CopyFormation(BattleFormationProto from, out GameFormationBaseOutput to)
    {
        CareerConfig? config = _gameCareerSkinConfigService.GetCareer(from.PlayerCareerSkinConfigId);
        
        to = new GameFormationBaseOutput();
        to.Id = from.Id;
        to.S_Id = from.Id.ToString();
        to.PlayerRank = from.PlayerRank;
        if (config != null)
        {
            to.PlayerCareerConfigId = config.Id;
        }
        else
        {
            to.PlayerCareerConfigId = 0;
        }
        to.PlayerCareerSkinConfigId = from.PlayerCareerSkinConfigId;
        to.PlayerName = from.PlayerName;
        to.PlayerIcon = from.PlayerIcon;
        to.PlayerUnitId = from.PlayerUnitId;
        to.RoundId = from.RoundId;
        to.CanComposite = from.CanComposite;
        to.CreateTime = from.CreateTime;
        to.S_CreateTime = ShowAppendDate(from.CreateTime);
        to.UpdateTime = from.UpdateTime;
        to.S_UpdateTime = ShowAppendDate(from.UpdateTime);
        to.IsDeleted = from.IsDeleted;
        to.DifficultyLevelEnum = (DifficultyLevelEnum)from.DifficultyLevel;
        to.Remark = from.Remark;

        
        CopyItems(from.CareerItemProtos, out List<GameItemEntity> gameCareerItemEntities);
        to.CareerItems = gameCareerItemEntities;
        
        CopyItems(from.CapacityLayerItemProtos, out List<GameItemEntity> gameCapacityLayerItemEntities);
        to.CapacityLayerItems = gameCapacityLayerItemEntities;
        
        CopyItems(from.ItemLayerItemProtos, out List<GameItemEntity> gameItemLayerItemEntities);
        to.ItemLayerItems = gameItemLayerItemEntities;
        
        //var to = to.ItemComposites;
        //CopyComposite(ref to, deleteInput.CompositeGroupIds);
    }
    /// <summary>
    /// 复制Item
    /// </summary>
    /// <param name="to"></param>
    /// <param name="from"></param>
    private void CopyItems(List<ItemProto> from, out List<GameItemEntity> to)
    {
        if (from.IsNullOrEmpty())
        {
            to = null;
            return;
        }
        to = new List<GameItemEntity>(from.Count);
        foreach (var fromItem in from)
        {
            CopyItem(fromItem, out GameItemEntity toItem);
            to.Add(toItem);
        }
    }

    private void CopyItem(ItemProto from, out GameItemEntity to)
    {
        to = new GameItemEntity();
        to.Id = from.Id;
        to.ConfigId = from.ConfigId;
        to.Bag = from.Bag;
        to.Discount = from.Discount;
        to.Locked = from.Locked;
        to.Sold = from.Sold;
        to.Price = from.Price;
        to.IndexId = from.IndexId;
        to.Z_Rotation = from.Z_Rotation;
        to.CentrePosX = from.CentrePosX;
        to.CentrePosY = from.CentrePosY;
        to.CurrentBelongItemCompositeId = from.CurrentBelongItemCompositeId;
        to.BelongItemCompositeIds = from.BelongItemCompositeIds;
        ItemConfig config = _gameItemConfigService.Get(from.ConfigId);
        if (config != null)
        {
            to.ConfigName = config.Name;
            to.GridIndexes = CalGrids(config.TransformId, from.CentrePosX, from.CentrePosY, from.Z_Rotation);
        }
        else
        {
            Log.Error($"Cant found itemConfig:{from.ConfigId}");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fackItemTransformConfigId"></param>
    /// <param name="itemZRotation"></param>
    /// <param name="realItemTransform"></param>
    private void GetRealTransform(int fackItemTransformConfigId,int itemZRotation, out ItemTransformConfig? realItemTransform)
    {
        realItemTransform = null;
        ItemTransformConfig? fackItemTransform = _gameItemTransformConfigService.Get(fackItemTransformConfigId);
        List<ItemTransformConfig>? groupTransformConfigs = _gameItemTransformConfigService.GetGroup(fackItemTransform.GroupId);
        if (groupTransformConfigs.IsNullOrEmpty())
        {
            Log.Warning($"异常Transform {fackItemTransform.GroupId}");
            return;
        }
        int newGroupRotationId = (itemZRotation + fackItemTransform.GroupRotationId) % groupTransformConfigs.Count;
        
        realItemTransform = _gameItemTransformConfigService.GetGroupRotation(fackItemTransform.GroupId,newGroupRotationId);
    }
    
    /// <summary>
    /// 计算占格
    /// </summary>
    /// <param name="transformConfigId"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="zRotation"></param>
    /// <returns></returns>
    private List<int> CalGrids(int transformConfigId,int x,int y,int zRotation)
    {
        GetRealTransform(transformConfigId, zRotation, out ItemTransformConfig? realItemTransform);
        if (realItemTransform == null)
        {
            return null;
        }
        
        List<Vector2Int> gridList = GridHelper.SplitGridInItem(realItemTransform.GridArrays);
        int offsetX = MathHelper.Divide1K(x - realItemTransform.CentreX);
        int offsetY = MathHelper.Divide1K(y - realItemTransform.CentreY);
        
        List<int> gridIndexes = new (gridList.Count);
        for (int i = 0; i < gridList.Count; i++)
        {
            Vector2Int grid = gridList[i];
            gridIndexes.Add((offsetX + grid.X - 1) + (offsetY + grid.Y - 1) * 7);
        }
        return gridIndexes;
    }

    /// <summary>
    /// 复制Item
    /// </summary>
    /// <param name="to"></param>
    /// <param name="from"></param>
    private void CopyItems(List<GameItemEntity> from, out List<ItemProto> to)
    {
        if (from.IsNullOrEmpty())
        {
            to = null;
            return;
        }
        to = new List<ItemProto>(from.Count);
        foreach (var fromItem in from)
        {
            CopyItem(fromItem, out ItemProto toItem);
            to.Add(toItem);
        }
    }

    private void CopyItem(GameItemEntity from, out ItemProto to)
    {
        to = new ItemProto();
        to.Id = from.Id;
        to.ConfigId = from.ConfigId;
        to.Bag = from.Bag;
        to.Discount = from.Discount;
        to.Locked = from.Locked;
        to.Sold = from.Sold;
        to.Price = from.Price;
        to.IndexId = from.IndexId;
        to.Z_Rotation = from.Z_Rotation;
        to.CentrePosX = from.CentrePosX;
        to.CentrePosY = from.CentrePosY;
        to.CurrentBelongItemCompositeId = from.CurrentBelongItemCompositeId;
        to.BelongItemCompositeIds = from.BelongItemCompositeIds;
    }

    /// <summary>
    /// 复制合成关系
    /// </summary>
    /// <param name="to"></param>
    /// <param name="from"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void CopyComposite(ref List<GameCompositeItemEntity> to, List<ItemCompositeProto> from)
    {
        throw new NotImplementedException();
    }

}

