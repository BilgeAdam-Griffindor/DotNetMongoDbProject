namespace DemoMarketPlace.WebApi.Quartz.JobPlanning
{
    public class JobSchedule
    {
        public Type _JobType { get; set; }
        public string _CronExpression { get; set; }
        public JobSchedule(Type jobType, string cronExpression)
        {
            _JobType = jobType;
            _CronExpression = cronExpression;
        }
    }
}
