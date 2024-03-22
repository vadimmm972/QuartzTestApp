using Quartz.Impl;
using Quartz;
using QuartzTestApp.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuartzTestApp.TaskExecution.Repository;
using QuartzTestApp.TaskExecution.Services;

namespace QuartzTestApp.TaskExecution.Jobs
{
    public class CustomJobService
    {
        private readonly IScheduler _scheduler;

        public CustomJobService()
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
        public async Task DeleteJob(string jobName, string groupName)
        {
            var jobKey = new JobKey(jobName, groupName);
            await _scheduler.DeleteJob(jobKey);
        }

        public async Task AddJob(Guid id, string jobName, string userName, string taskDescription)
        {
            //var schedulerFactory = new StdSchedulerFactory();

            //// Отримуємо планувальник
            //var scheduler = await schedulerFactory.GetScheduler();

            // Запускаємо планувальник
            await _scheduler.Start();

            var jobData = new JobDataMap
            {
                { "TaskId", id },
                { "UserName", userName },
                { "TaskDescription", taskDescription }
            };


            var job = JobBuilder.Create<TaskRedistributionService>()
                .WithIdentity(jobName, "group")
                .SetJobData(jobData)
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity($"{jobName}Trigger", "group")
                            .WithSimpleSchedule(x => x
                            .WithIntervalInSeconds(10)
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
