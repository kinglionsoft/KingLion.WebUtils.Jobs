using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace KingLion.WebUtils.Jobs
{
    public static class JobDIExtensions
    {
        /// <summary>
        /// 添加作业管理器
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddJobManager(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IJobManager),typeof(JobManager));
            return services;
        }

        /// <summary>
        /// 启用作业管理器
        /// </summary>
        /// <param name="app"></param>
        /// <param name="interval">作业队列为空时，线程等待时间，单位：毫秒</param>
        public static IApplicationBuilder UseJobManager(this IApplicationBuilder app,int interval=5000)
        {
            app.ApplicationServices.GetService<IJobManager>().Start(interval);
            return app;
        }
    }
}