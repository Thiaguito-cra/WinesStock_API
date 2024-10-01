using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IUserDBRepository
    {
        public List<User> GetUsers();
        void AddUser(User user);
    }
}
