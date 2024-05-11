using ET;
using Furion.JsonSerialization;
using Furion.Logging;

namespace GameFrameX.Application.Game;

/// <summary>
/// 游戏阵容服务
/// </summary>
[ApiDescriptionSettings(GameConst.GroupName, Order = 100)]
[AllowAnonymous]
public class GameCareerSkinConfigService : IDynamicApiController, ITransient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly GameCareerConfigService _gameCareerConfigService;
    private static Dictionary<int, CareerSkinConfig>? _careerSkinConfigDictionary;
    private static Dictionary<int, CareerConfig?>? _careerSkinDictionary;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpClientFactory"></param>
    /// <param name="gameCareerConfigService"></param>
    public GameCareerSkinConfigService(IHttpClientFactory httpClientFactory, GameCareerConfigService gameCareerConfigService)
    {
        _httpClientFactory = httpClientFactory;
        _gameCareerConfigService = gameCareerConfigService;
        _careerSkinDictionary = new Dictionary<int, CareerConfig?>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<CareerSkinConfig>?> List()
    {
        return _careerSkinConfigDictionary?.Values?.ToList();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Dictionary<int, CareerSkinConfig>?> Init()
    {
        if (!_careerSkinConfigDictionary.IsNullOrEmpty())
        {
            return _careerSkinConfigDictionary;
        }
        try
        {
            var client = _httpClientFactory.CreateClient(GameConst.GameRequestHttpGroupName);
            var response = await client.GetAsync("/manage/config/careerSkin");
            var result = MongoHelper.FromJson<HttpCommonResponse>(response.Content.ReadAsStringAsync().Result);
            if (result.Error == ErrorCode.ERR_Success)
            { 
                var listFrom = result.Body;
                _careerSkinConfigDictionary = JSON.Deserialize<Dictionary<int, CareerSkinConfig>>(listFrom);
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }
        return _careerSkinConfigDictionary;
    }

    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public CareerSkinConfig? Get(int id)
    {
        if (!_careerSkinConfigDictionary.IsNullOrEmpty())
        {
            _careerSkinConfigDictionary.TryGetValue(id, out var careerSkinConfig);
            return careerSkinConfig;
        }
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public CareerConfig? GetCareer(int id)
    {
        if (_careerSkinDictionary.TryGetValue(id, out CareerConfig? careerConfig))
        {
            return careerConfig;
        }
        CareerSkinConfig? careerSkinConfig = Get(id);
        if (careerSkinConfig == null)
        {
            return null;
        }
        
        careerConfig = _gameCareerConfigService.Get(careerSkinConfig.CareerId);
        _careerSkinDictionary.Add(id, careerConfig);
        return careerConfig;
    }
}

