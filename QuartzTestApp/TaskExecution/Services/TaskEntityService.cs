using QuartzTestApp.Jobs;
using QuartzTestApp.TaskExecution.Jobs;
using QuartzTestApp.TaskExecution.Models;
using QuartzTestApp.TaskExecution.Repository;


namespace QuartzTestApp.TaskExecution.Services
{
    public class TaskEntityService
    {
        private readonly TaskEntityRepository _taskEntityRepository;
        private readonly UserRepository _userRepository;
        private readonly CustomJobService _jobServices;
        private int Counter = 0;
        public TaskEntityService()
        {
            _taskEntityRepository = new TaskEntityRepository();
            _userRepository = new UserRepository();
            _jobServices = new CustomJobService();
        }
        public async Task AddNewTask()
        {
            var id = Guid.NewGuid();
            var avalibleUser = _userRepository.GetUsers().FirstOrDefault();
            TaskEntity entity = new TaskEntity() 
            {
                Id = id,
                Description = "Test " + Counter,
               // AssignedUserId = avalibleUser.Id,
                Status = TaskEntityStatus.Waiting
            };
            StatisUsersTasksRepository.TaskEntities.Add(entity);
           // _taskEntityRepository.InsertTask(entity);
           // _taskEntityRepository.CreateTask();
           // Console.WriteLine($"Task created: ");
            await _jobServices.AddJob(entity.Id, $"NewTask_{entity.Id}", avalibleUser?.Name, entity.Description);
            Console.WriteLine($"\t\t\tJob Added\n\n");
            Counter++;

        }
    }
}
