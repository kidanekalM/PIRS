using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PIRS.Models;
using PIRS.Models.UserModel;

namespace PIRS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly PirsContext _context;
        public UserController(PirsContext pirsContext,UserManager<AppUser>  userManager) 
        {
            _userManager = userManager;
            _context = pirsContext;
        }
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostUser(AppUser user)
        {
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                // Handle the error here
                return BadRequest(result.Errors);
            }
        }

        [HttpGet]
        public ActionResult<List<AppUser>> GetUsers()
        {
            return _userManager.Users.ToList();
        }

    }
}
