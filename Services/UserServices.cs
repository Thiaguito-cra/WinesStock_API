using Common.Models;
using Data.Entities;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices : IUserServices
    {
        public readonly IUserDBRepository _userDbRepository;
        public UserServices(IUserDBRepository userDBRepository)
        {
            _userDbRepository = userDBRepository;
        }

        public void AddUser(UserDTO createUserDTO)
        {
            if (_userDbRepository.GetUsers().All(user => user.Username != createUserDTO.Username))
            {
                _userDbRepository.AddUser(
                    new User
                    {
                        Id = _userDbRepository.GetUsers().Max(x => x.Id) + 1,
                        Username = createUserDTO.Username,
                        Password = createUserDTO.Password
                    }
                    );
            }
        }
            public User? AuthenticateUser(UserForAuth authRequestBody)
            {
                User? userToReturn = _userDbRepository.Get(authRequestBody.Username);
                if (userToReturn is not null && userToReturn.Password == authRequestBody.Password)
                    return userToReturn;
                return null;
            }
        }
    }
}
