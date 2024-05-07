using SqlSugar;

namespace GameFrameX.Application.Game;

/// <summary>
/// 
/// </summary>
public class UpdateGameFormationBaseInput : BaseUpdateInput
{
    /// <summary>
    /// 是否是默认
    /// </summary>
    [SugarColumn(ColumnDescription = "难度等级")]
    public DifficultyLevelEnum DifficultyLevelEnum { get; set; }
    
    /// <summary>
    /// 道具，已反序列化
    /// </summary>
    [SugarColumn(ColumnDescription = "道具")]
    public List<GameItemEntity> ItemLayerItems { get; set; }
    
    /// <summary>
    /// 状态，1无效，0有效
    /// </summary>
    [SugarColumn(ColumnDescription = "状态，1无效，0有效")]
    public int Status { get; set; }
}

