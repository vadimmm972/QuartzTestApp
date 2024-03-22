using QuartzTestApp.TaskExecution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTestApp.TaskExecution.Repository
{
    public class UserRepository
    {
        private List<User> Users { get; set; }

        public UserRepository()
        {
            CreateUsers();
        }

        private void CreateUsers()
        {
            if (Users == null)
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
        }

        public List<User> GetUsers()
        {
            CreateUsers();
            return Users;
        }
        public void InsertUser(User user)
        {
            // Users.Add(user);
            StatisUsersTasksRepository.Users.Add(user);
        }

        public User GetUser(Guid id)
        {
            return StatisUsersTasksRepository.Users.FirstOrDefault(u => u.Id == id);
            //return Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAvailableUsersExcept(Guid assignedUserId)
        {
            return StatisUsersTasksRepository.Users.Where(u => u.Id != assignedUserId).ToList();
            //return Users.Where(u => u.Id != assignedUserId).ToList();
        }
    }
}
