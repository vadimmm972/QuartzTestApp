using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTestApp.Jobs
{
    public class JobServices
    {
        private readonly IScheduler _scheduler;

        public JobServices()
        {
            _scheduler = GetScheduler().GetAwaiter().GetResult();
        }
        private async Task<IScheduler> GetScheduler()
        {
            var schedulerFactory = new StdSchedulerFactory();
            return await schedulerFactory.GetScheduler();
        }

        public async Task StartScheduler()
        {
            await _scheduler.Start();
        }

        public async Task AddJob(string jobName)
        {
            var job = JobBuilder.Create<NotificationJob>()
                .WithIdentity(jobName, "group")
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity($"{jobName}Trigger", "group")
                                            .StartNow()
                            .WithSimpleSchedule(x => x
                            .WithIntervalInSeconds(5)
                            .RepeatForever())
                            .Build();

            await _scheduler.ScheduleJob(job, trigger);
        }
        public async Task AddJob(string jobName, DateTime startTime)
        {
            var job = JobBuilder.Create<NotificationJob>()
                .WithIdentity(jobName, "group")
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity($"{jobName}Trigger", "group")
                            .StartNow()
                            .WithSimpleSchedule(x => x
                            .WithIntervalInSeconds(5)
                            .RepeatForever())
                            .Build();

            await _scheduler.ScheduleJob(job, trigger);
        }

        public async Task StopScheduler()
        {
            await _scheduler.Shutdown();
        }
    }
}
