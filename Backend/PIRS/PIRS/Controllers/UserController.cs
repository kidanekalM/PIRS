using Microsoft.AspNetCore.Authorization;
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
    private readonly IWebHostEnvironment webHostEnvironment;

    public UserController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        this.webHostEnvironment = webHostEnvironment;
    }
    [HttpPost]
    public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var imageUrl = "/Images/" + fileName; 

            return Ok(imageUrl);
        }

        
        return BadRequest("Please select a file.");
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> EditImage(string id, [FromForm] IFormFile file)
    {
        var existingImagePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", id);

        if (file != null && file.Length > 0)
        {
            var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var newFilePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", newFileName);

            using (var stream = new FileStream(newFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            
            System.IO.File.Delete(existingImagePath);

            return Ok(); 
        }

        
        return BadRequest("Please select a file.");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteImage(string id)
    {
        var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", id);

        
        System.IO.File.Delete(imagePath);

        

        return Ok(); 
    }
    [HttpPost]
    public async Task<IActionResult> Create(AppUser user, string roleName)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var role = await _roleManager.FindByNameAsync(roleName);

        if (role != null && (roleName == "User" || roleName == "Contractor"))
        {
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                if (!await _userManager.IsInRoleAsync(user, roleName))
                    await _userManager.AddToRoleAsync(user, roleName);

                return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
            }
        }

        ModelState.AddModelError(string.Empty, "Invalid role or role does not exist");
        return BadRequest(ModelState);
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _userManager.GetUsersInRoleAsync("User").Result.ToList();

        return Ok(users);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, AppUser updatedUser)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingUser = await _userManager.FindByIdAsync(id);

        if (existingUser == null)
            return NotFound();

        var userRoles = await _userManager.GetRolesAsync(existingUser);

        if (!userRoles.Contains("Customer"))
            return Forbid(); // Return 403 Forbidden if the user does not have the "Customer" role

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

        var userRoles = await _userManager.GetRolesAsync(existingUser);

        if (!userRoles.Contains("Customer"))
            return Forbid(); // Return 403 Forbidden if the user does not have the "Customer" role

        var result = await _userManager.DeleteAsync(existingUser);

        if (result.Succeeded)
            return Ok(existingUser);

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