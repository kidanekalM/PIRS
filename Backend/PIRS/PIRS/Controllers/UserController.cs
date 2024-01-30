using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PIRS.Models.UserModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AppUser), 201)]
    [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
    /*    public async Task<IActionResult> Create(AppUser user, string roleName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                if (await _roleManager.RoleExistsAsync(roleName))
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }

                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }*/
    public async Task<IActionResult> Create(AppUser user, string roleName)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingRole = await _roleManager.FindByNameAsync(roleName);

        if (existingRole == null)
        {
            return BadRequest("Invalid role name");
        }

        var result = await _userManager.CreateAsync(user);

        if (result.Succeeded)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return BadRequest(ModelState);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AppUser), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetUser([FromRoute] string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, AppUser updatedUser)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingUser = await _userManager.FindByIdAsync(id);

        if (existingUser == null)
            return NotFound();

        existingUser.UserName = updatedUser.UserName;
        existingUser.Email = updatedUser.Email;
        existingUser.PhoneNumber = updatedUser.PhoneNumber;

        var result = await _userManager.UpdateAsync(existingUser);

        if (result.Succeeded)
            return Ok(existingUser);

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return BadRequest(ModelState);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var existingUser = await _userManager.FindByIdAsync(id);

        if (existingUser == null)
            return NotFound();

        var result = await _userManager.DeleteAsync(existingUser);

        if (result.Succeeded)
            return NoContent();

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return BadRequest(ModelState);
    }
    [HttpGet("users-with-roles")]
    public IActionResult GetUsersWithRoles(string roleName)
    {
        var role = _roleManager.FindByNameAsync(roleName).Result;

        if (role == null)
            return NotFound();

        var usersInRole = _userManager.GetUsersInRoleAsync(role.Name).Result;

        var usersWithRoles = new List<UserWithRoles>();

        foreach (var user in usersInRole)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            var userWithRoles = new UserWithRoles
            {
                User = user,
                Roles = roles.ToList()
            };

            usersWithRoles.Add(userWithRoles);
        }

        return Ok(usersWithRoles);
    }
    public class UserWithRoles
    {
        public AppUser User { get; set; }
        public List<string> Roles { get; set; }
    }
}