using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTestApp.TaskExecution.Models
{
    public enum TaskEntityStatus
    {
        Waiting,
        InProgress,
        Completed
    }
    public class TaskEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid AssignedUserId { get; set; }
        public TaskEntityStatus Status { get; set; }
    }
}
