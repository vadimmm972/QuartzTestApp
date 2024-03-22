using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTestApp.Jobs
{
    public class JobFactory : IJobFactory
    {
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var jobDetail = bundle.JobDetail;
            var jobType = jobDetail.JobType;

            try
            {
                var job = (IJob)Activator.CreateInstance(jobType);
                return job;
            }
            catch (Exception ex)
            {

                throw new SchedulerException($"Problem instantiating class '{jobDetail.JobType.FullName}'", ex);
            }
        }

        public void ReturnJob(IJob job)
        {
            throw new NotImplementedException();
        }
    }
}
