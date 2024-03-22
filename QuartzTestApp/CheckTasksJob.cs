//using Quartz;
//using QuartzTestApp.TaskExecution.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace QuartzTestApp
//{
//    public class CheckTasksJob : IJob
//    {
//        private readonly List<TaskEntity> _tasks;
//        private readonly List<User> _users;
//        private readonly Random _random;

//        public CheckTasksJob(List<TaskEntity> tasks, List<User> users)
//        {
//            _tasks = tasks;
//            _users = users;
//            _random = new Random();
//        }
//        public Task Execute(IJobExecutionContext context)
//        {
//            foreach (var  task in _tasks)
//            {
//                if (task.Status == Status.Waiting)
//                {
//                    task.Status = Status.InProgress;
//                    Console.WriteLine($"Task {task.Id} moved to InProgress.");
//                }
//                else if (task.Status == Status.InProgress)
//                {
//                    task.Owner = GetRandomOwner(task.Owner);
//                }
//            }

//            return Task.CompletedTask;
//        }

//        private User GetRandomOwner(User previousOwner)
//        {
//            // Фільтруємо користувачів, виключаючи попереднього власника
//            var availableUsers = _users.Where(u => u != previousOwner).ToList();

//            // Генеруємо випадковий індекс з доступних користувачів
//            int index = _random.Next(availableUsers.Count);

//            // Повертаємо випадкового користувача
//            return availableUsers[index];
//        }

//        //public void ReassignTasks()
//        //{
//        //    foreach (var task in _tasks)
//        //    {
//        //        if (task.Status != Status.Completed)
//        //        {
//        //            var availableUsers = _users.Where(u => u != task.AssignedUser).ToList();
//        //            if (availableUsers.Count > 0)
//        //            {
//        //                var newUser = availableUsers[_random.Next(availableUsers.Count)];
//        //                task.AssignedUser = newUser;
//        //                if (task.State == TaskState.InProgress)
//        //                {
//        //                    task.State = TaskState.Waiting;
//        //                }
//        //                else
//        //                {
//        //                    task.State = TaskState.InProgress;
//        //                }
//        //            }
//        //            else if (task.State == TaskState.Waiting)
//        //            {
//        //                task.State = TaskState.Completed;
//        //            }
//        //        }
//        //    }
//        //}
//    }
//}
