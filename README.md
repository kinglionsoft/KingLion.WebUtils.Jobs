# KingLion.WebUtils.Jobs

Asp .Net Core项目中，非常轻量的异步任务管理模块。
> 若要支持进度管理、失败重试、任务队列等高级功能，推荐使用[Hangfire](http://hangfire.io/)

### 安装

NuGet: 
```
Install-Package KingLion.WebUtils.Jobs
```

### 用法

1. 启用Job Manager
    
    * Startup-> ConfigureServices：
    ```C#
    services.AddJobManager();
   ```
    * Startup-> Configure，在配置日志模块后添加：
    ```C#
    app.UseJobManager(5000);
    ```
2. 添加作业
    * 注入IJobManager；
    * 添加作业：
    ```C#
    _jobManager.Add(() =>
    {
        Thread.Sleep(5000);
        return new JobResult();
    }, (id,result) =>
    {
        _logger.LogInformation($"task{id} completed");
    });
    ```
### 依赖
* "Microsoft.AspNetCore.Http.Abstractions": "1.1.0",
* "Microsoft.Extensions.DependencyInjection.Abstractions": "1.1.0",
* "Microsoft.Extensions.Logging.Abstractions": "1.1.0",
* "NETStandard.Library": "1.6.1",
* "System.Threading.Thread": "4.3.0"
