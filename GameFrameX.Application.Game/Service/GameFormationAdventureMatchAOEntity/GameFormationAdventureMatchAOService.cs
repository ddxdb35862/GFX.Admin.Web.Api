using ET;

namespace GameFrameX.Application.Game;

/// <summary>
/// 游戏阵容服务
/// </summary>
[ApiDescriptionSettings(GameConst.GroupName, Order = 100)]
[AllowAnonymous]
public class GameFormationAdventureMatchAOService : IDynamicApiController, ITransient
{
    private readonly IHttpClientFactory _httpClientFactory;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpClientFactory"></param>
    public GameFormationAdventureMatchAOService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// 逻辑删除游戏阵容
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "LogicDelete")]
    public async Task<bool> LogicDelete(DeleteGameFormationAdventureMatchAOInput input)
    {
        List<GameFormationAdventureMatchAOOutput> list = new List<GameFormationAdventureMatchAOOutput>();
        var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
        AdventureMatchAOProto proto = await CopyFormationToDelete(input);
        string requestBody = MongoHelper.ToJson(proto);
        HttpContent content = new StringContent(requestBody);//UTF8
        var response = await client.PostAsync("/manage/adventure/matchOA/addOrUpdate", content);
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
    public async Task<bool> Delete(DeleteGameFormationAdventureMatchAOInput input)
    {
        return await this.LogicDelete(input);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="deleteInput"></param>
    private async Task<AdventureMatchAOProto> CopyFormationToDelete(DeleteGameFormationAdventureMatchAOInput deleteInput)
    {
        var id = long.Parse(deleteInput.S_Id);
        var origin = await this.Get(new QueryByIdGameFormationAdventureMatchAOInput(){Id = id});
        var to = CopyFormation(origin);
        to.IsDeleted = 1;
        return to;
    }

    /// <summary>
    /// 获取游戏阵容
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<GameFormationAdventureMatchAOOutput?> Get([FromQuery] QueryByIdGameFormationAdventureMatchAOInput input)
    {
        GameFormationAdventureMatchAOOutput detail = null;
        var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
        var response = await client.GetAsync("/manage/adventure/matchOA/detail?id="+input.Id);
        var result = response.Content.ReadAsStringAsync().Result;
        var body = MongoHelper.FromJson<HttpGetAdventureMatchAOResponse>(result);
        if (body.Error == ErrorCode.ERR_Success)
        { 
            var listFrom = body.AdventureMatchAOProto;
            CopyFormation(listFrom, out detail);
        }
        return detail;
    }
    
    /// <summary>
    /// 更新游戏阵容
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task<bool> Update(UpdateGameFormationAdventureMatchAOInput input)
    {
        List<GameFormationAdventureMatchAOOutput> list = new List<GameFormationAdventureMatchAOOutput>();
        var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
        AdventureMatchAOProto proto = CopyFormation(input);
        string requestBody = MongoHelper.ToJson(proto);
        HttpContent content = new StringContent(requestBody);//UTF8
        var response = await client.PostAsync("/manage/adventure/matchOA/addOrUpdate", content);
        var result = response.Content.ReadAsStringAsync().Result;
        var body = MongoHelper.FromJson<HttpCommonResponse>(result);
        return body.Error == ErrorCode.ERR_Success;
    }
    
    /// <summary>
    /// 更新游戏阵容
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<bool> Add(AddGameFormationAdventureMatchAOInput input)
    {
        List<GameFormationAdventureMatchAOOutput> list = new List<GameFormationAdventureMatchAOOutput>();
        var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
        AdventureMatchAOProto proto = CopyFormation(input);
        string requestBody = MongoHelper.ToJson(proto);
        HttpContent content = new StringContent(requestBody);//UTF8
        var response = await client.PostAsync("/manage/adventure/matchOA/addOrUpdate", content);
        var result = response.Content.ReadAsStringAsync().Result;
        var body = MongoHelper.FromJson<HttpCommonResponse>(result);
        return body.Error == ErrorCode.ERR_Success;
    }
    
    /// <summary>
    /// 获取游戏阵容列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<GameFormationAdventureMatchAOOutput>> List([FromBody] GameFormationAdventureMatchAOInput input)
    {
        List<GameFormationAdventureMatchAOOutput> list = new List<GameFormationAdventureMatchAOOutput>();
        var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
        string uri = "/manage/adventure/matchOA/list?";
        if (input.RoundId == 0)
        {
            uri += "roundId="+input.RoundId + "&";
        }
        uri += "adventureMode="+input.AdventureMode + "&";
        if (input.AdventureTime == 0)
        {
            uri += "adventureTime="+input.AdventureTime + "&";
        }
        
        var response = await client.PostAsync(uri,null);
        var result = response.Content.ReadAsStringAsync().Result;
        var body = MongoHelper.FromJson<HttpGetAdventureMatchAOsResponse>(result);
        if (body.Error == ErrorCode.ERR_Success)
        { 
            var listFrom = body.AdventureMatchAOProtos;
            CopyList(ref list, listFrom);
        }
        return list;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tos"></param>
    /// <param name="froms"></param>
    private void CopyList(ref List<GameFormationAdventureMatchAOOutput> tos, List<AdventureMatchAOProto> froms)
    {
        if (froms.IsNullOrEmpty())
        {
            return;
        }

        foreach (var from in froms)
        {
            CopyFormation(from, out GameFormationAdventureMatchAOOutput to);
            tos.Add(to);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="to"></param>
    /// <param name="from"></param>
    private void CopyFormation(AdventureMatchAOProto from, out GameFormationAdventureMatchAOOutput to)
    {
        to = new GameFormationAdventureMatchAOOutput();
        to.Id = from.Id;
        to.RoundId = (GameRound)from.RoundId;
        to.AdventureMode = (GameAdventureMode)from.AdventureMode;
        to.AdventureTime = from.AdventureTime;
        to.FormationRemark = from.FormationRemark;
        to.S_FormationId = from.FormationId.ToString();
        
        to.CreateTime = from.CreateTime;
        to.UpdateTime = from.UpdateTime;
        to.UpdateUserId = from.UpdateUserId;
        to.IsDeleted = from.IsDeleted;
        to.Remark = from.Remark;
        
        to.S_Id = from.Id.ToString();
        to.S_CreateTime = DateUtil.ShowAppendDate(from.CreateTime);
        to.S_UpdateTime = DateUtil.ShowAppendDate(from.UpdateTime);
    }

    /// <summary>
    /// 更改
    /// </summary>
    /// <param name="updateInput"></param>
    private AdventureMatchAOProto CopyFormation(UpdateGameFormationAdventureMatchAOInput updateInput)
    {
        long id = long.Parse(updateInput.S_Id);
        
        AdventureMatchAOProto to = new AdventureMatchAOProto();
        to.Id = id;
        to.RoundId = (int)updateInput.RoundId;
        to.AdventureMode = (int)updateInput.AdventureMode;
        to.AdventureTime = updateInput.AdventureTime;
        to.FormationId = long.Parse(updateInput.S_FormationId);
        
        to.CreateTime = updateInput.CreateTime;
        to.UpdateTime = updateInput.UpdateTime;
        to.UpdateUserId = updateInput.UpdateUserId;
        to.IsDeleted = updateInput.IsDeleted;
        to.Remark = updateInput.Remark;
        return to;
    }
    
    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="addInput"></param>
    private AdventureMatchAOProto CopyFormation(AddGameFormationAdventureMatchAOInput addInput)
    {
        AdventureMatchAOProto to = new AdventureMatchAOProto();
        to.RoundId = (int)addInput.RoundId;
        to.AdventureMode = (int)addInput.AdventureMode;
        to.AdventureTime = addInput.AdventureTime;
        to.FormationId = long.Parse(addInput.S_FormationId);
        
        to.CreateTime = DateUtil.ServerNow();
        to.UpdateTime = DateUtil.ServerNow();
        to.UpdateUserId = addInput.UpdateUserId;
        //to.IsDeleted = addInput.IsDeleted;
        to.Remark = addInput.Remark;
        return to;
    }

    /// <summary>
    /// 更改
    /// </summary>
    /// <param name="updateInput"></param>
    private AdventureMatchAOProto CopyFormation(GameFormationAdventureMatchAOOutput updateInput)
    {
        long id = long.Parse(updateInput.S_Id);
        
        AdventureMatchAOProto to = new AdventureMatchAOProto();
        to.Id = id;
        to.RoundId = (int)updateInput.RoundId;
        to.AdventureMode = (int)updateInput.AdventureMode;
        to.AdventureTime = updateInput.AdventureTime;
        to.FormationRemark = updateInput.FormationRemark;
        to.FormationId = long.Parse(updateInput.S_FormationId);
        
        to.CreateTime = updateInput.CreateTime;
        to.UpdateTime = updateInput.UpdateTime;
        to.UpdateUserId = updateInput.UpdateUserId;
        to.IsDeleted = updateInput.IsDeleted;
        to.Remark = updateInput.Remark;
        return to;
    }

}

