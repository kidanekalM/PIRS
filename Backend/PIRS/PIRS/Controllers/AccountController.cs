using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using PIRS.Models.UserModel;


namespace PIRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp(UserModel userModel)
        {
            // Perform any necessary validation checks
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Generate a unique user ID (you can use a library like Guid.NewGuid() or your own logic)
            // userModel.Id = Guid.NewGuid().ToString();

            // Save the user to the database or perform any other necessary actions
            // ...

            return Ok(); // User successfully signed up, return 200 OK status code
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            // Perform any necessary validation checks
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Authenticate the user (e.g., check credentials against the database)
            // ...

            // Create claims for the authenticated user
            var claims = new[]
            {
              //  new Claim(ClaimTypes.NameIdentifier,loginModel.Username),
                new Claim(ClaimTypes.Role, "comp"),
                // Add any other necessary claims
            };

            // Generate a JWT token
            var token = GenerateJwtToken(claims);

            // Return the token to the client
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(Claim[] claims)
        {
            var jwtSecret = _configuration["JwtSettings:Secret"];
            var jwtIssuer = _configuration["JwtSettings:Issuer"];
            var jwtAudience = _configuration["JwtSettings:Audience"];
            var jwtExpiryMinutes = Convert.ToInt32(_configuration["JwtSettings:ExpiryMinutes"]);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.UtcNow.AddMinutes(jwtExpiryMinutes);

            var token = new JwtSecurityToken(
                jwtIssuer,
                jwtAudience,
                claims,
                expires: expiry,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}