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
/// 游戏区服
/// </summary>
[SugarTable(null, "游戏道具")]
[SysTable]
[IncreTable]
public class GameItemEntity : EntityBaseId
{
    [SugarColumn(ColumnDescription = "道具ConfigId")]
    public int ConfigId { get; set; }

    [SugarColumn(ColumnDescription = "道具X坐标")]
    public int CentrePosX { get; set; }

    [SugarColumn(ColumnDescription = "道具Y坐标")]
    public int CentrePosY { get; set; }

    [SugarColumn(ColumnDescription = "道具所处包裹")]
    public int Bag { get; set; }

    [SugarColumn(ColumnDescription = "道具价格")]
    public int Price { get; set; }

    [SugarColumn(ColumnDescription = "道具在商店的位置")]
    public int IndexId { get; set; }

    [SugarColumn(ColumnDescription = "道具在商店是否锁定")]
    public bool Locked { get; set; }

    [SugarColumn(ColumnDescription = "道具在商店是否打折")]
    public bool Discount { get; set; }

    [SugarColumn(ColumnDescription = "是否已被卖出")]
    public bool Sold { get; set; }

    [SugarColumn(ColumnDescription = "当前所处的合成Id")]
    public long CurrentBelongItemCompositeId { get; set; }

    [SugarColumn(ColumnDescription = "所有的可合成Id")]
    public List<long> BelongItemCompositeIds { get; set; } = new();

    [SugarColumn(ColumnDescription = "旋转,0,1,2,3")]
    public int Z_Rotation { get; set; }
}