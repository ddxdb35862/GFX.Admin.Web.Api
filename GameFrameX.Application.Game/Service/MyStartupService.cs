using Furion.Logging;
using Microsoft.Extensions.Hosting;

namespace GameFrameX.Application.Game;

/// <summary>
/// 
/// </summary>
public class MyStartupService : IHostedService, IDisposable  
{  
    private readonly GameCareerConfigService _gameCareerConfigService;
    private readonly GameCareerSkinConfigService _gameCareerSkinConfigService;  
    private Timer? _timer;  
  
    /// <summary>
    /// 
    /// </summary>
    /// <param name="gameCareerConfigService"></param>
    /// <param name="gameCareerSkinConfigService"></param>
    public MyStartupService(GameCareerConfigService gameCareerConfigService, GameCareerSkinConfigService gameCareerSkinConfigService)
    {
        _gameCareerConfigService = gameCareerConfigService;
        _gameCareerSkinConfigService = gameCareerSkinConfigService;
    }  
  
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task StartAsync(CancellationToken cancellationToken)  
    {  
        _timer = new Timer(ExecuteDoWork, null, TimeSpan.FromSeconds(1), Timeout.InfiniteTimeSpan);  
  
        // 如果你想让任务只执行一次，可以在DoWork方法内部停止定时器  
        // 或者你可以在这里直接调用DoWork方法，并取消定时器的初始化  
  
        return Task.CompletedTask;  
    }  
  
    private async Task DoWorkAsync()  
    {
        Log.Information("MyStartupService init GameCareerConfig");
        await _gameCareerConfigService.Init(); // 调用你的Service方法
        Log.Information("MyStartupService init GameCareerSkinConfig");
        await _gameCareerSkinConfigService.Init(); // 调用你的Service方法  
  
        // 如果定时器只执行一次，则停止它  
        _timer?.Change(Timeout.Infinite, 0);  
    }  
  
    private void ExecuteDoWork(object? state)  
    {  
        // 使用Task.Run来确保DoWork的异步操作不会阻塞回调线程  
        _ = Task.Run(DoWorkAsync);  
  
        // 如果你希望DoWork只执行一次，可以在这里停止定时器  
        _timer?.Change(Timeout.Infinite, 0);  
    }  
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task StopAsync(CancellationToken cancellationToken)  
    {  
        _timer?.Change(Timeout.Infinite, 0);  
  
        return Task.CompletedTask;  
    }  
  
    /// <summary>
    /// 
    /// </summary>
    public void Dispose()  
    {  
        _timer?.Dispose();  
    }  
}