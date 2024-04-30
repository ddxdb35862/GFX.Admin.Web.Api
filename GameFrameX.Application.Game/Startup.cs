﻿// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using GameFrameX.Core.Base.Option;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace GameFrameX.Application.Game;

[AppStartup(102)]
public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        _ = new GameUserEntity();
        // 配置选项
        services.AddConfigurableOptions<GameServerOptions>();

        var gameServerOptions = App.GetConfig<GameServerOptions>("GameServerSettings", true);
        
        var gameServerHostPort = Environment.GetEnvironmentVariable("GAME_SERVER_HOST_PORT");
        if (!string.IsNullOrEmpty(gameServerHostPort))
        {
            Log.Information($"数据库类型:{config.DbType}连接字符串:{config.ConnectionString}");
            
            gameServerOptions.HttpRootUrl = $"http://{gameServerHostPort}";
        }
        // 添加HTTP客户端
        services.AddHttpClient(GameConst.GameRequestHttpGroupName, options => { options.BaseAddress = new Uri(gameServerOptions.HttpRootUrl); });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
    }
}