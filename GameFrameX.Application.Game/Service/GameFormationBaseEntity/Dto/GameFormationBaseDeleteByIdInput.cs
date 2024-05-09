using GameFrameX.Core;
using System.ComponentModel.DataAnnotations;

namespace GameFrameX.Application.Game;


/// <summary>
/// 游戏阵容删除输入参数
/// </summary>
public class DeleteGameFormationBaseInput : BaseDeleteInput
{
     public string S_Id { get; set; }
}

