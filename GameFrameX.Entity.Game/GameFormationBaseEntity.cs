// 麻省理工学院许可证
// 
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
// 
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
// 
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using GameFrameX.Core.Enum;

namespace GameFrameX.Entity.Game;

/// <summary>
/// 游戏阵容
/// </summary>
[SugarTable(null, "游戏阵容")]
[SysTable]
[IncreTable]
public class GameFormationBaseEntity : EntityBaseSelect
{
    /// <summary>
    /// 轮次，在一次闯关中
    /// </summary>
    [SugarColumn(ColumnDescription = "第几轮")]
    public int RoundId { get; set; }

    /// <summary>
    /// 所属玩家排名
    /// </summary>
    [SugarColumn(ColumnDescription = "所属玩家排名")]
    public int Rank { get; set; }

    /// <summary>
    /// 玩家职业id
    /// </summary>
    [SugarColumn(ColumnDescription = "职业Id")]
    public int CareerConfigId { get; set; }

    /// <summary>
    /// 玩家职业皮肤id
    /// </summary>
    [SugarColumn(ColumnDescription = "职业皮肤Id")]
    public int CareerSkinConfigId { get; set; }

    /// <summary>
    /// 玩家Id
    /// </summary>
    [SugarColumn(ColumnDescription = "玩家Id")]
    public long PlayerUnitId { get; set; }
    
    /// <summary>
    /// 玩家名称
    /// </summary>
    [SugarColumn(ColumnDescription = "玩家名称")]
    public string? PlayerName { get; set; }

    /// <summary>
    /// 玩家头像
    /// </summary>
    [SugarColumn(ColumnDescription = "玩家头像")]
    public string? PlayerAvatar { get; set; }

    /// <summary>
    /// 是否是默认
    /// </summary>
    [SugarColumn(ColumnDescription = "难度等级")]
    public FormationDifficultyLevelEnum DifficultyLevelEnum { get; set; }

    /// <summary>
    /// 背包，需要反序列化
    /// </summary>
    [SugarColumn(ColumnDescription = "背包,json")]
    public string? CapacityLayerItemProtos { get; set; }
    
    /// <summary>
    /// 背包，已反序列化
    /// </summary>
    [SugarColumn(ColumnDescription = "背包")]
    public List<GameItemEntity> CapacityLayerItems { get; set; }

    /// <summary>
    /// 道具，需要反序列化
    /// </summary>
    [SugarColumn(ColumnDescription = "道具,json")]
    public string? ItemLayerItemProtos { get; set; }
    
    /// <summary>
    /// 道具，已反序列化
    /// </summary>
    [SugarColumn(ColumnDescription = "道具")]
    public List<GameItemEntity> ItemLayerItems { get; set; }

    /// <summary>
    /// 职业皮肤，需要反序列化
    /// </summary>
    [SugarColumn(ColumnDescription = "职业皮肤,json")]
    public string? CareerItemProtos { get; set; }
    
    /// <summary>
    /// 职业皮肤，已反序列化
    /// </summary>
    [SugarColumn(ColumnDescription = "职业皮肤")]
    public List<GameItemEntity> CareerItems { get; set; }

    /// <summary>
    /// 组合，需要反序列化
    /// </summary>
    [SugarColumn(ColumnDescription = "组合,json")]
    public string? ItemCompositeProtos { get; set; }
    
    /// <summary>
    /// 组合，已反序列化
    /// </summary>
    [SugarColumn(ColumnDescription = "组合")]
    public List<GameCompositeItemEntity> ItemComposites { get; set; }

    /// <summary>
    /// 能否组合
    /// </summary>
    [SugarColumn(ColumnDescription = "能否组合")]
    public bool CanComposite { get; set; }
    
    /// <summary>
    /// 是否已编辑过
    /// </summary>
    [SugarColumn(ColumnDescription = "是否已编辑过")]
    public bool HasEditor { get; set; }
}