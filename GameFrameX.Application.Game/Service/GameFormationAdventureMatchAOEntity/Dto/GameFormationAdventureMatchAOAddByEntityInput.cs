namespace GameFrameX.Application.Game;

/// <summary>
/// 游戏阵容增加输入参数
/// </summary>
public class AddGameFormationAdventureMatchAOInput : BaseAddInput
{
    #region 表结构定义
    /// <summary>
    /// 轮次，在一次闯关中
    /// </summary>
    public GameRound RoundId { get; set; }
    /// <summary>
    /// 模式
    /// </summary>
    public GameAdventureMode AdventureMode { get; set; }
    /// <summary>
    /// 模式
    /// </summary>
    public int AdventureTime { get; set; }
    /// <summary>
    /// 阵容
    /// </summary>
    //public long FormationId { get; set; }
    #endregion
    
    #region 扩展属性
    /// <summary>
    /// 是否删除
    /// </summary>
    public int IsDeleted { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public long CreateTime { get; set; }
    /// <summary>
    /// 更新时间
    /// </summary>
    public long UpdateTime { get; set; }
    /// <summary>
    /// 更新用户
    /// </summary
    public long UpdateUserId { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
    
    /// <summary>
    /// 阵容stringID
    /// </summary>
    public string S_FormationId { get; set; }
    #endregion
    
    

}

