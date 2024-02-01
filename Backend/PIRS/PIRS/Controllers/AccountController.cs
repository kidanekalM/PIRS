using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using PIRS.Models.UserModel;
using Microsoft.AspNetCore.Identity;

namespace PIRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(IConfiguration configuration, SignInManager<AppUser> signInManager,UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp(AppUser user, string password)
        {
            if((user == null) || (string.IsNullOrEmpty(password)) || (!ModelState.IsValid))
            {
                return BadRequest();
            }
            userManager.CreateAsync()
            return Ok(); // User successfully signed up, return 200 OK status code
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string email,string password)
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
            //var token = GenerateJwtToken(claims);

            // Return the token to the client
            //return Ok(new { Token = token });
        }
        /*
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
        }*/
    }
}