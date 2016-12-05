using System;
using System.Threading.Tasks;

namespace KingLion.WebUtils.Jobs
{
    public interface IJobManager
    {
        /// <summary>
        /// 添加作业
        /// </summary>
        /// <param name="task">作业任务</param>
        /// <param name="onComplete">完成任务的回调，参数值为：作业Id、完成结果</param>
        /// <returns>生成作业Id</returns>
        int Add(Func<JobResult> task, Action<int, JobResult> onComplete =null);

        /// <summary>
        /// 启动作业
        /// </summary>
        /// <param name="interval">作业队列为空时，线程等待时间，单位：毫秒</param>
        /// <returns></returns>
        Task Start(int interval=5000);
    }
}