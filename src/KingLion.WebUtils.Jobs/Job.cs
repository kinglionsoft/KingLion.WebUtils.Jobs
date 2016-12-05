using System;

namespace KingLion.WebUtils.Jobs
{
    internal class Job
    {
        public int Id { get; set; }

        public Func<JobResult> Action { get; set; }

        public Action<int, JobResult> OnComplete { get; set; }

        public Job()
        {
            
        }

        public Job(int id, Func<JobResult> action, Action<int, JobResult> onComplete)
        {
            Id = id;
            Action = action;
            OnComplete = onComplete;
        }
    }
}