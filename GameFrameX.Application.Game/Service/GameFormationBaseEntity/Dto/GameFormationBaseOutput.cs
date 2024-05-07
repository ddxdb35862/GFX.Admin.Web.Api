namespace GameFrameX.Application.Game;

/// <summary>
/// 游戏区服输出参数
/// </summary>
public class GameFormationBaseOutput : GameFormationBase, IBasePageOutput<GameFormationBase>
{
    public string S_UpdateTime { get; set; }
    public string S_CreateTime { get; set; }
}
