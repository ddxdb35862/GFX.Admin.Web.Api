namespace GameFrameX.Entity.Game;

public partial class CareerSkinConfig
{
    /// <summary>CareerSkinId</summary>
    public int Id { get; set; }
    /// <summary>职业Id</summary>
    public int CareerId { get; set; }
    /// <summary>皮肤名称</summary>
    public string SkinName { get; set; }
    /// <summary>Model</summary>
    public string Model { get; set; }
    /// <summary>是否默认白板皮肤</summary>
    public int IsDefault { get; set; }
    /// <summary>获取方式</summary>
    public int UnlockMethod { get; set; }
    /// <summary>获取活动ConfigId</summary>
    public int UnlockActivityConfigId { get; set; }
    /// <summary>解锁所需钻石</summary>
    public int UnlockDiamond { get; set; }
    /// <summary>SkinItemIds</summary>
    public string SkinItemIds { get; set; }
    /// <summary>皮肤属性</summary>
    public string SkinAdditionProp { get; set; }

}