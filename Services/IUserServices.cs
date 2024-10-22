using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Data.Entities;

namespace Services
{
    public interface IUserServices
    {
        void AddUser(UserDTO createDTO);
        User? AuthenticateUser(UserForAuth authRequestBody);
    }
}
