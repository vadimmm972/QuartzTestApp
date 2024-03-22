using QuartzTestApp.TaskExecution.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTestApp.TaskExecution.Repository
{
    public class TaskEntityRepository
    {
        private List<TaskEntity> TaskEntitys { get; set; }
        private  UserRepository _userRepository;

        public TaskEntityRepository()
        {
            if (TaskEntitys != null)
            {
                TaskEntitys = new List<TaskEntity>();
            }
        }

        public void InsertTask(TaskEntity task)
        {
            //if (TaskEntitys == null )
            //{
            //    TaskEntitys = new List<TaskEntity>();
            //}
            StatisUsersTasksRepository.TaskEntities.Add(task);
        }

        public TaskEntity GetTaskById(Guid id)
        {
            //return TaskEntitys.FirstOrDefault(t => t.Id == id);
            return StatisUsersTasksRepository.TaskEntities.FirstOrDefault(t => t.Id == id);
        }

        public void UpdateTask(TaskEntity updatedTask)
        {
            var existingTask = StatisUsersTasksRepository.TaskEntities.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (existingTask != null)
            {
                existingTask.Description = updatedTask.Description;
                existingTask.AssignedUserId = updatedTask.AssignedUserId;
                existingTask.Status = updatedTask.Status;
            }
        }

        private int Counter = 0;
        public void CreateTask()
        {
            if (_userRepository != null)
            {
                _userRepository = new UserRepository();
            }
            var id = Guid.NewGuid();
            //TaskEntitys = new List<TaskEntity>();
            var avalibleUser = _userRepository.GetUsers().FirstOrDefault();
            TaskEntity entity = new TaskEntity()
            {
                Id = id,
                Description = "Test " + Counter,
               // AssignedUserId = avalibleUser.Id,
                Status = TaskEntityStatus.Waiting
            };

            StatisUsersTasksRepository.TaskEntities.Add(entity);
            Counter++;
        }

    }
}
