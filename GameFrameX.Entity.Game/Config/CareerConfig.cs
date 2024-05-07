namespace GameFrameX.Entity.Game;

public partial class CareerConfig
{
    /// <summary>CareerId</summary>
    public int Id { get; set; }
    /// <summary>Code</summary>
    public string Code { get; set; }
    /// <summary>Model</summary>
    public string Model { get; set; }
    /// <summary>CareerName</summary>
    public string CareerName { get; set; }
    /// <summary>解锁所需钻石</summary>
    public int UnlockDiamond { get; set; }
    /// <summary>CareerItemIds</summary>
    public string CareerItemIds { get; set; }
    /// <summary>天赋属性</summary>
    public string CareerProp { get; set; }
    /// <summary>职业说明</summary>
    public string CareerDesc { get; set; }

}