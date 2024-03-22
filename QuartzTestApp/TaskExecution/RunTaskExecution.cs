using QuartzTestApp.TaskExecution.Jobs;
using QuartzTestApp.TaskExecution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTestApp.TaskExecution
{
    public static class RunTaskExecution
    {
        public static async Task Run() 
        {
            TaskEntityService taskEntityService = new TaskEntityService();
            CustomJobService customJobService = new CustomJobService();
            Console.WriteLine("Press 'q' to exit or 'a' to add a new job...");

            // Чекаємо, поки користувач не натисне 'q' або 'a'
            while (true)
            {
                var key = Console.ReadKey();
                if (key.KeyChar == 'q')
                    break;
                else if (key.KeyChar == 'a')
                    await taskEntityService.AddNewTask();
            }

            // Зупиняємо планувальник перед виходом
            await customJobService.StopScheduler();
        }
    }
}
