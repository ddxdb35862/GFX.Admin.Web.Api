namespace GameFrameX.Application.Game;

/// <summary>
/// 游戏阵容增加输入参数
/// </summary>
public class AddGameFormationBaseEntityInput : BaseAddInput
{
    /// <summary>
    /// 主键Id
    /// </summary>
    [Required(ErrorMessage = "主键Id不能为空")]
    public long Id { get; set; }
        
}

