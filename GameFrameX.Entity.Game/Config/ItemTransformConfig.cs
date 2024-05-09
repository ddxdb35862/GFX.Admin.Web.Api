namespace GameFrameX.Entity.Game;

public partial class ItemTransformConfig
{
    /// <summary>Id</summary>
    public int Id { get; set; }
    /// <summary>格子数</summary>
    public int GridNum { get; set; }
    /// <summary>数组</summary>
    public string GridArrays { get; set; }
    /// <summary>中心点X</summary>
    public int CentreX { get; set; }
    /// <summary>中心点Y</summary>
    public int CentreY { get; set; }
    /// <summary>旋转点</summary>
    public string RotationPos { get; set; }
    /// <summary>旋转点Y</summary>
    public int RotationPosX { get; set; }
    /// <summary>旋转点Y</summary>
    public int RotationPosY { get; set; }
    /// <summary>组Id</summary>
    public int GroupId { get; set; }
    /// <summary>旋转Id</summary>
    public int GroupRotationId { get; set; }
}