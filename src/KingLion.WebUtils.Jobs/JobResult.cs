namespace KingLion.WebUtils.Jobs
{
    public class JobResult
    {
        public int Code { get; set; } = 0;

        public string Message { get; set; } = "success";

        public object Data { get; set; }
    }
}