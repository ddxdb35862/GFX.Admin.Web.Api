namespace GameFrameX.Application.Game;

/// <summary>
/// 游戏区服分页查询输入参数
/// </summary>
public class GameFormationBaseInput : BasePageInput
{
        
    /// <summary>
    /// 回合数
    /// </summary>
    public int? RoundId { get; set; }
    
    /// <summary>
    /// 排名等级
    /// </summary>
    public int? Rank { get; set; }
    /// <summary>
    /// 职业Id
    /// </summary>
    public int? CareerConfigId { get; set; }
    /// <summary>
    /// 职业皮肤Id
    /// </summary>
    public int? CareerSkinConfigId { get; set; }
    
    /// <summary>
    /// 合并的玩家Id，如果没有输入，则默认合并所有玩家
    /// </summary>
    public string? ToMergePlayerUnitIds { get; set; }
}
