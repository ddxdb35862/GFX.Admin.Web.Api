using ET;
using Furion.JsonSerialization;
using Furion.Logging;

namespace GameFrameX.Application.Game;

/// <summary>
/// 游戏阵容服务
/// </summary>
[ApiDescriptionSettings(GameConst.GroupName, Order = 100)]
[AllowAnonymous]
public class GameItemTransformConfigService : IDynamicApiController, ITransient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private static Dictionary<int, ItemTransformConfig?>? _itemTransformConfigDictionary;
    
    public static Dictionary<int, List<ItemTransformConfig>?> _transformGroups = new ();
    public static Dictionary<(int, int), ItemTransformConfig?> _transformGroupMembers = new ();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpClientFactory"></param>
    public GameItemTransformConfigService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }



    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<ItemTransformConfig>?> List()
    {
        return _itemTransformConfigDictionary?.Values?.ToList();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Dictionary<int, ItemTransformConfig>?> Init()
    {
        if (!_itemTransformConfigDictionary.IsNullOrEmpty())
        {
            return _itemTransformConfigDictionary;
        }
        try
        {
            var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
            var response = await client.GetAsync("/manage/config/itemTransform");
            var result = MongoHelper.FromJson<HttpCommonResponse>(response.Content.ReadAsStringAsync().Result);
            if (result.Error == ErrorCode.ERR_Success)
            { 
                var listFrom = result.Body;
                _itemTransformConfigDictionary = JSON.Deserialize<Dictionary<int, ItemTransformConfig>>(listFrom);
                
                foreach (ItemTransformConfig? config in _itemTransformConfigDictionary.Values)
                {
                    _transformGroups.TryGetValue(config.GroupId, out List<ItemTransformConfig>? transforms);
                    if (transforms == null)
                    {
                        transforms = new List<ItemTransformConfig>();
                        _transformGroups.TryAdd(config.GroupId, transforms);
                    }
                    transforms.Add(config);

                    _transformGroupMembers[(config.GroupId, config.GroupRotationId)] = config;
                }
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }
        return _itemTransformConfigDictionary;
    }

    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ItemTransformConfig? Get(int id)
    {
        if (!_itemTransformConfigDictionary.IsNullOrEmpty())
        {
            _itemTransformConfigDictionary.TryGetValue(id, out var itemTransformConfig);
            return itemTransformConfig;
        }
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="groupId"></param>
    /// <returns></returns>
    public List<ItemTransformConfig>? GetGroup(int groupId)
    {
        _transformGroups.TryGetValue(groupId, out List<ItemTransformConfig>? transforms);
        return transforms;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="groupRotationId"></param>
    /// <returns></returns>
    public ItemTransformConfig? GetGroupRotation(int groupId, int groupRotationId)
    {
        _transformGroupMembers.TryGetValue((groupId,groupRotationId), out ItemTransformConfig? transform);
        return transform;
    }
}

