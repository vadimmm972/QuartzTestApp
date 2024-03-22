// See https://aka.ms/new-console-template for more information
using Quartz.Impl;
using Quartz;
using QuartzTestApp;
using QuartzTestApp.Jobs;
using QuartzTestApp.TaskExecution;
using QuartzTestApp.TaskExecution.Repository;

//Console.WriteLine("Hello, World!");

//TestRun testRun = new TestRun();
//await testRun.Run();
bool data;

StatisUsersTasksRepository.FillUsers();
await RunTaskExecution.Run();


//await JobRunning.Run();

// EX 2
//class Program
//{
//    static async Task Main(string[] args)
//    {
//        await ScheduleJob();
//        Console.WriteLine("Press 'q' to exit or 'a' to add a new job...");

//        // Чекаємо, поки користувач не натисне 'q' або 'a'
//        while (true)
//        {
//            var key = Console.ReadKey();
//            if (key.KeyChar == 'q')
//                break;
//            else if (key.KeyChar == 'a')
//                await AddNewJob();
//        }

//        // Зупиняємо планувальник перед виходом
//        await scheduler.Shutdown();
//    }

//    static IScheduler scheduler;

//    static async Task ScheduleJob()
//    {
//        // Створюємо фабрику для планувальників
//        var schedulerFactory = new StdSchedulerFactory();

//        // Отримуємо планувальник
//        scheduler = await schedulerFactory.GetScheduler();

//        // Запускаємо планувальник
//        await scheduler.Start();
//    }

//    static async Task AddNewJob()
//    {
//        // Визначаємо новий джоб
//        var job = JobBuilder.Create<PrintJob>()
//            .WithIdentity($"PrintJob_{Guid.NewGuid()}", "group")
//            .Build();

//        // Визначаємо тригер, що запускає джоб кожні 5 секунд
//        var trigger = TriggerBuilder.Create()
//            .WithIdentity($"PrintTrigger_{Guid.NewGuid()}", "group")
//            .StartNow()
//            .WithSimpleSchedule(x => x
//                .WithIntervalInSeconds(5)
//                .RepeatForever())
//            .Build();

//        // Реєструємо новий джоб і тригер з планувальником
//        await scheduler.ScheduleJob(job, trigger);

//        Console.WriteLine("New job added successfully!");
//    }
//}

//public class PrintJob : IJob
//{
//    public Task Execute(IJobExecutionContext context)
//    {
//        // Виводимо повідомлення у консоль
//        Console.WriteLine($"PrintJob executed at: {context.JobDetail.Key}");

//        return Task.CompletedTask;
//    }
//}


// EX 1

//class Program
//{
//    static async Task Main(string[] args)
//    {
//        await ScheduleJob();
//        Console.WriteLine("Press any key to exit...");
//        Console.ReadKey();
//    }

//    static async Task ScheduleJob()
//    {
//        // Створюємо фабрику для планувальників
//        var schedulerFactory = new StdSchedulerFactory();

//        // Отримуємо планувальник
//        var scheduler = await schedulerFactory.GetScheduler();

//        // Запускаємо планувальник
//        await scheduler.Start();

//        // Визначаємо джоб
//        var job = JobBuilder.Create<PrintJob>()
//            .WithIdentity("PrintJob", "group")
//            .Build();

//        // Визначаємо тригер, що запускає джоб кожні 5 секунд
//        var trigger = TriggerBuilder.Create()
//            .WithIdentity("PrintTrigger", "group")
//            .StartNow()
//            .WithSimpleSchedule(x => x
//                .WithIntervalInSeconds(5)
//                .RepeatForever())
//            .Build();

//        // Реєструємо джоб і тригер з планувальником
//        await scheduler.ScheduleJob(job, trigger);
//    }
//}

//public class PrintJob : IJob
//{
//    public Task Execute(IJobExecutionContext context)
//    {
//        // Виводимо повідомлення у консоль
//        Console.WriteLine($"PrintJob executed at: {DateTime.Now}");

//        return Task.CompletedTask;
//    }
//}