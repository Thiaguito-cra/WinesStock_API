using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace WinesStock_API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserServices _userService;

        public AuthenticationController(IConfiguration config, IUserServices userService)
        {
            _config = config;
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserForAuth authenticationRequestBody)
        {

            var user = _userService.AuthenticateUser(authenticationRequestBody);

            if (user is null)
                return Unauthorized();

            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);


            var claimsForToken = new List<Claim>
            {
                new Claim("sub", user.Id.ToString()),
                new Claim("name", user.Username)
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _config["Authentication:Issuer"],
                _config["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                credentials);

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }
    }
}
