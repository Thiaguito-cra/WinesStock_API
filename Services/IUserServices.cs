using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Services
{
    public interface IUserServices
    {
        void AddUser(UserDTO createDTO);
    }
}
