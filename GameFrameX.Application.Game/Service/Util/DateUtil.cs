namespace GameFrameX.Application.Game;

/// <summary>
/// 
/// </summary>
public static partial class DateUtil
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ms"></param>
    /// <returns></returns>
    public static string ShowAppendDate(long ms)
    {
        var create = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(ms);
        return create.ToString("yyyyMMdd HH:mm:ss");
    }

    /// <summary>
    /// 
    /// </summary>
    private static readonly DateTime Dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    
    /// <summary>
    /// 当前时间
    /// </summary>
    /// <returns></returns>
    public static long ServerNow()
    {
        return (DateTime.UtcNow.Ticks - Dt1970.Ticks) / 10000;
    }

}