using ET;
using Furion.JsonSerialization;
using Furion.Logging;

namespace GameFrameX.Application.Game;

/// <summary>
/// 游戏阵容服务
/// </summary>
[ApiDescriptionSettings(GameConst.GroupName, Order = 100)]
[AllowAnonymous]
public class GameCareerConfigService : IDynamicApiController, ITransient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private static Dictionary<int, CareerConfig> _careerConfigDictionary;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpClientFactory"></param>
    public GameCareerConfigService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Init")]
    public async Task<Dictionary<int, CareerConfig>> Init()
    {
        if (!_careerConfigDictionary.IsNullOrEmpty())
        {
            return _careerConfigDictionary;
        }

        try
        {
            var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
            var response = await client.GetAsync("/admin/config/career");
            var result = MongoHelper.FromJson<HttpCommonResponse>(response.Content.ReadAsStringAsync().Result);
            if (result.Error == ErrorCode.ERR_Success)
            {
                var listFrom = result.Body;
                _careerConfigDictionary = JSON.Deserialize<Dictionary<int, CareerConfig>>(listFrom);
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }
        return _careerConfigDictionary;
    }

    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public CareerConfig? Get(int id)
    {
        if (!_careerConfigDictionary.IsNullOrEmpty())
        {
            _careerConfigDictionary.TryGetValue(id, out var careerConfig);
            return careerConfig;
        }
        return null;
    }


}

