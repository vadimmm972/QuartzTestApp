using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTestApp.Jobs
{
    public static class JobRunning
    {
        public static async Task Run()
        {
            var jobService = new JobServices();

            await jobService.StartScheduler();

            Console.WriteLine("Enter job name and start time (format: JobName StartTime), or 'exit' to quit:");

            while (true)
            {
                var input = Console.ReadLine();

                //if (input.ToLower() == "exit")
                //    break;

                //var parts = input.Split(' ');
                //if (parts.Length != 2)
                //{
                //    Console.WriteLine("Invalid input. Please enter job name and start time (format: JobName StartTime)");
                //    continue;
                //}

                //if (!DateTime.TryParse(parts[1], out DateTime startTime))
                //{
                //    Console.WriteLine("Invalid start time. Please enter a valid date and time.");
                //    continue;
                //}

                await jobService.AddJob(input.ToString());
                Console.WriteLine($"\nJob '{input}'\n");
            }

            await jobService.StopScheduler();
        }
    }
}
