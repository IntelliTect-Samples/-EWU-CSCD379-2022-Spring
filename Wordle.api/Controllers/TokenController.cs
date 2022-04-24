using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private JwtConfiguration _jwtConfiguration;
        private UserManager<AppUser> _authenticationHandler;
        private AppDbContext _db;

        public TokenController(JwtConfiguration jwtConfiguration,
            UserManager<AppUser> authenticationHandler,
            AppDbContext db)
        {
            _jwtConfiguration = jwtConfiguration;
            _authenticationHandler = authenticationHandler;
            _db = db;
        }

        [HttpPost("GetToken")]
        public async Task<IActionResult> GetToken([FromBody] UserLoginInfo userInfo)
        {
            if (string.IsNullOrWhiteSpace(userInfo.Email) ||
                !userInfo.Email.Contains("@") ||
                string.IsNullOrWhiteSpace(userInfo.Password))
            {
                return BadRequest();
            }

            var user = _db.Users.FirstOrDefault(u => u.NormalizedEmail == userInfo.Email.ToUpper());
            if (user == null)
            {
                return NotFound();
            }

            var result = await _authenticationHandler.CheckPasswordAsync(user, userInfo.Password);
            if (result)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Secret!));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                //Create a List of Claims, Keep claims name short    
                var permClaims = new List<Claim>();
                permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                permClaims.Add(new Claim("valid", "1"));
                permClaims.Add(new Claim("userid", user.Id));
                permClaims.Add(new Claim("username", user.UserName));

                //Create Security Token object by giving required parameters    
                var token = new JwtSecurityToken(_jwtConfiguration.Issuer, //Issure    
                                _jwtConfiguration.Issuer,  //Audience    
                                permClaims,
                                expires: DateTime.Now.AddDays(1),
                                signingCredentials: credentials);
                var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { data = jwt_token });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserInfo userInfo)
        {
            if (string.IsNullOrWhiteSpace(userInfo.Email) ||
                !userInfo.Email.Contains("@") ||
                string.IsNullOrWhiteSpace(userInfo.Password) ||
                string.IsNullOrWhiteSpace(userInfo.UserName))
            {
                return StatusCode(500, "UserName, Email, and Password are required");
            }
            // Make sure these don't already exist
            if (_db.Users.Any(f => f.NormalizedUserName == userInfo.NormalizedUserName))
            {
                return StatusCode(500, "Username already exists");
            }
            if (_db.Users.Any(f => f.NormalizedEmail == userInfo.NormalizedEmail))
            {
                return StatusCode(500, "Email already exists");
            }

            var user = new AppUser
            {
                UserName = userInfo.UserName,
                NormalizedUserName = userInfo.NormalizedUserName,
                Email = userInfo.Email,
                NormalizedEmail = userInfo.NormalizedEmail,
            };
            var result = await _authenticationHandler.CreateAsync(user, userInfo.Password);
            if (result.Succeeded)
            {
                return Ok(new { data = result });
            }
            else
            {
                return StatusCode(500, $"Create user failed: {string.Join(Environment.NewLine, result.Errors.Select(f=>f.Description))}");
            }
        }

        public class UserLoginInfo
        {
            public string Email { get; }
            public string Password { get; }

            public UserLoginInfo(string email, string password)
            {
                Email = email;
                Password = password;
            }
            public string NormalizedEmail => Email.ToUpper();
        }

        public class UserInfo : UserLoginInfo
        {
            public string UserName { get; }

            public UserInfo(string userName, string email, string password) : base(email, password)
            {
                UserName = userName;
            }
            public string NormalizedUserName => UserName.ToUpper();
        }

    }
}
