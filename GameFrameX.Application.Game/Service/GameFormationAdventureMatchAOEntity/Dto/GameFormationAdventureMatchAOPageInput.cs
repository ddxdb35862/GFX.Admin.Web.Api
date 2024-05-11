namespace GameFrameX.Application.Game;

/// <summary>
/// 游戏区服分页查询输入参数
/// </summary>
public class GameFormationAdventureMatchAOInput : BasePageInput
{
        
    #region 表结构定义
    /// <summary>
    /// 轮次，在一次闯关中
    /// </summary>
    public int RoundId { get; set; }
    /// <summary>
    /// 模式
    /// </summary>
    public int AdventureMode { get; set; }
    /// <summary>
    /// 模式
    /// </summary>
    public int AdventureTime { get; set; }
        
    #endregion
}
