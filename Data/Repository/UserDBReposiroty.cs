using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserHardCodedDBRepository : IUserHardCodedDBRepository
    {

        private List<User> users = new List<User>()
        {
            new User
            {
                Id = 1,
                Username = "admin",
                Password = "admin"
            },
            new User
            {
                Id = 2,
                Username = "Carlos",
                Password = "Carlos123456789"
            },
            new User
            {
                Id = 3,
                Username = "Carlos2",
                Password = "Carlos123456789"
            }
        };
        public List<User> GetUsers()
        {
            return users;
        }
        public void AddUser(User user)
        {
            users.Add(user);
        }
    }
}
