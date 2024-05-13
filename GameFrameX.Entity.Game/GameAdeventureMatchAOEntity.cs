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
public class GameFormationAdventureMatchAO : EntityBaseSelect
{
    #region 表结构定义
    /// <summary>
    /// 轮次，在一次闯关中
    /// </summary>
    [SugarColumn(ColumnDescription = "第几轮")]
    public GameRound RoundId { get; set; }
    /// <summary>
    /// 模式
    /// </summary>
    [SugarColumn(ColumnDescription = "模式")]
    public GameAdventureMode AdventureMode { get; set; }
    /// <summary>
    /// 模式
    /// </summary>
    [SugarColumn(ColumnDescription = "轮次")]
    public int AdventureTime { get; set; }
    
    /// <summary>
    /// 阵容备注
    /// </summary>
    [SugarColumn(ColumnDescription = "阵容备注")]
    public string? FormationRemark { get; set; }
    
    /// <summary>
    /// 阵容id
    /// </summary>
    //[SugarColumn(ColumnDescription = "阵容id")]
    //public long FormationId { get; set; }
    
    #endregion
    
    #region 扩展属性
    /// <summary>
    /// 是否删除
    /// </summary>
    [SugarColumn(ColumnDescription = "状态，1已删除，0未删除")]
    public int IsDeleted { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    [SugarColumn(ColumnDescription = "创建时间")]
    public long CreateTime { get; set; }
    
    /// <summary>
    /// 更新时间
    /// </summary>
    [SugarColumn(ColumnDescription = "更新时间")]
    public long UpdateTime { get; set; }
    
    /// <summary>
    /// 更新用户
    /// </summary>
    [SugarColumn(ColumnDescription = "更新用户ID")]
    public long UpdateUserId { get; set; }
    
    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnDescription = "备注")]
    public string? Remark { get; set; }
    
    #endregion
    
    #region long类型扩展，javascript显示long会失真，后续需要前端引入moment.js等进行格式化
    /// <summary>
    /// 
    /// </summary>
    public string S_UpdateTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string S_CreateTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string S_Id { get; set; }
    
    /// <summary>
    /// 阵容stringID
    /// </summary>
    public string S_FormationId { get; set; }
    #endregion
}