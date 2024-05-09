using ET;
using Furion.JsonSerialization;
using Furion.Logging;

namespace GameFrameX.Application.Game;

/// <summary>
/// 游戏阵容服务
/// </summary>
[ApiDescriptionSettings(GameConst.GroupName, Order = 100)]
[AllowAnonymous]
public class GameItemConfigService : IDynamicApiController, ITransient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private static Dictionary<int, ItemConfig?> _itemConfigDictionary;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpClientFactory"></param>
    public GameItemConfigService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Init")]
    public async Task<Dictionary<int, ItemConfig>?> Init()
    {
        if (!_itemConfigDictionary.IsNullOrEmpty())
        {
            return _itemConfigDictionary;
        }
        try
        {
            var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
            var response = await client.GetAsync("/admin/config/item");
            var result = MongoHelper.FromJson<HttpCommonResponse>(response.Content.ReadAsStringAsync().Result);
            if (result.Error == ErrorCode.ERR_Success)
            { 
                var listFrom = result.Body;
                _itemConfigDictionary = JSON.Deserialize<Dictionary<int, ItemConfig>>(listFrom);
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }
        return _itemConfigDictionary;
    }

    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ItemConfig? Get(int id)
    {
        if (!_itemConfigDictionary.IsNullOrEmpty())
        {
            _itemConfigDictionary.TryGetValue(id, out var itemConfig);
            return itemConfig;
        }
        return null;
    }
}

