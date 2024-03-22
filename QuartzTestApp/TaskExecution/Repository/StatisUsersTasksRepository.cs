using QuartzTestApp.TaskExecution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTestApp.TaskExecution.Repository
{
    public static class StatisUsersTasksRepository
    {
        public static List<User> Users { get; set; }
        public static List<TaskEntity> TaskEntities = new List<TaskEntity>();

        public static void FillUsers()
        {
            Users =
[
    new User
    {
        Id = Guid.NewGuid(),
        Name = "Ivan"
    },
    new User
    {
        Id = Guid.NewGuid(),
        Name = "Taras"
    },
    new User
    {
        Id = Guid.NewGuid(),
        Name = "Stepan"
    },
];
        }

        public static void FillTasks()
        {

        }
    }
}
