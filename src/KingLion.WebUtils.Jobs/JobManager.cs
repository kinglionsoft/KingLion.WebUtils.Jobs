using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace KingLion.WebUtils.Jobs
{
    /// <summary>
    /// 统一处理
    /// </summary>
    public class JobManager:IJobManager
    {
        /// <summary>
        /// 日志中间件
        /// </summary>
        private ILogger<JobManager> _logger;

        private ConcurrentQueue<Job> _tasks;

        #region 构造函数

        public JobManager(ILogger<JobManager> logger)
        {
            _logger = logger;

            _tasks= new ConcurrentQueue<Job>();
        }

        #endregion

        #region 全局配置
        

        #endregion

        #region 添加作业

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="action">作业任务</param>
        /// <param name="onComplete">完成任务的回调</param>
        /// <returns>生成作业Id。若小于0，添加作业失败</returns>
        public int Add(Func<JobResult> action, Action<int,JobResult> onComplete = null)
        {
            var newTaskId = GenerateNewTaskId();
            _tasks.Enqueue(new Job(newTaskId, action, onComplete));
            return newTaskId;
        }

        /// <summary>
        /// 启动作业
        /// </summary>
        public Task Start(int interval=5000)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Job job;
                    if (_tasks.TryDequeue(out job))
                    {
                        var result = job.Action();
                        job.OnComplete?.Invoke(job.Id,result);
                    }
                    else
                    {
                        Thread.Sleep(interval);
                    }
                }

            });
            return Task.CompletedTask;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 生成唯一的新任务Id
        /// </summary>
        /// <returns></returns>
        private int GenerateNewTaskId()
        {
            return BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0);
        }
        
        #endregion
    }
}