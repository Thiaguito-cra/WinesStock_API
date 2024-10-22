using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WineInventory.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        public readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
                return BadRequest("The body request is null");
            
            _userServices.AddUser(userDTO);
            return Created("Location", "Resource");
        }
    }
}