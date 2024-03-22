using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTestApp.Jobs
{
    public class NotificationJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"\n\n  Sent to: {context.JobDetail.Key}");
            return Task.CompletedTask;
        }
    }
}
