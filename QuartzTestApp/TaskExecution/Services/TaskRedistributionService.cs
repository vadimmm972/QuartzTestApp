using Quartz;
using QuartzTestApp.TaskExecution.Jobs;
using QuartzTestApp.TaskExecution.Models;
using QuartzTestApp.TaskExecution.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTestApp.TaskExecution.Services
{
    public class TaskRedistributionService : IJob
    {
        private readonly TaskEntityRepository _taskEntityRepository;
        private readonly UserRepository _userRepository;
        private readonly CustomJobService _jobServices;
        public TaskRedistributionService()
        {
            _taskEntityRepository = new TaskEntityRepository();
            _userRepository = new UserRepository();
            _jobServices = new CustomJobService();
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var jobDataMap = context.JobDetail.JobDataMap;
            var taskId = jobDataMap.GetGuid("TaskId");
            var task = _taskEntityRepository.GetTaskById(taskId);
            

            if (task == null)
            {
               
                return;
            }

           
            //if (task.Status == TaskEntityStatus.InProgress)
            //{
            //    //var availableUsers = _userRepository.GetAvailableUsersExcept(task.AssignedUserId);

            //    //if (availableUsers.Any())
            //    //{
            //    //    var random = new Random();
            //    //    var randomUser = availableUsers[random.Next(availableUsers.Count)];

            //    //    task.AssignedUserId = randomUser.Id;
            //    //}
            //    ReassignTaskToRandomUser(task, task.Status);
            //}

            
            switch (task.Status)
            {
                case TaskEntityStatus.Waiting:
                    Console.WriteLine($"Current status: {task.Status}");
                    task.Status = TaskEntityStatus.InProgress;
                    ReassignTaskToRandomUser(task, task.Status);
                    break;
                case TaskEntityStatus.InProgress:
                    Console.WriteLine($"Current status: {task.Status}");
                    task.Status = TaskEntityStatus.Completed;
                    ReassignTaskToRandomUser(task, task.Status);
                    break;
                case TaskEntityStatus.Completed:
                    Console.WriteLine($"Current status: {task.Status}");
                    ReassignTaskToRandomUser(task, task.Status);
                    var jobKey = context.JobDetail.Key;
                    var groupName = context.JobDetail.Key.Group;
                    await _jobServices.DeleteJob(jobKey.Name, groupName);
                   // Console.WriteLine($"\n Task {jobKey.Name} is completed \n");
                    break;
            }

            
            _taskEntityRepository.UpdateTask(task);
        }
        private void ReassignTaskToRandomUser(TaskEntity task, TaskEntityStatus status )
        {
            var previousUserId = task.AssignedUserId;
            var availableUsers = _userRepository.GetAvailableUsersExcept(task.AssignedUserId);

            if (availableUsers.Any())
            {
                var random = new Random();
                var randomUser = availableUsers[random.Next(availableUsers.Count)];

                task.AssignedUserId = randomUser.Id;
            }

            Console.WriteLine($"Task name: {task.Description}\n" +
               // $"Task {task.Description} - moved to status: {status.ToString()}\n" +
                $"Previous user id was: {previousUserId}" +
                $"\nAssigned user id is: {task.AssignedUserId}" +
                $"\nExecution time: {DateTime.Now} \n\n\n");
        }

    }
}
