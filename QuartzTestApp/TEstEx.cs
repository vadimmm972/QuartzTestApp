using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTestApp
{
    public class TEstEx : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            // Виводимо повідомлення у консоль кожні 5 секунд
            Console.WriteLine("Повідомлення виведено: " + DateTime.Now.ToString("HH:mm:ss"));
        }
    }

    public class TestRun
    {
        public async Task Run()
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();
            IJobDetail job = JobBuilder.Create<TEstEx>().WithIdentity("job1", "group1").Build();

            ITrigger trigger = TriggerBuilder.Create()
                                .WithIdentity("trigger1", "group1")
                                .StartNow()
                                .WithSimpleSchedule(x => x
                                .WithIntervalInSeconds(10)
                                .RepeatForever())
                                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
