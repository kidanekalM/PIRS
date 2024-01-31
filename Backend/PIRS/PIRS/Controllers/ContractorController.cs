namespace PIRS.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PIRS.Models.UserModel;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    [Route("[controller]")]
    [ApiController]
    public class ContractorController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ContractorController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppUser user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Agent");

                return CreatedAtAction(nameof(GetContractors), new { id = user.Id }, user);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public IActionResult GetContractors()
        {
            var users = _userManager.GetUsersInRoleAsync("Agent").Result.ToList();

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
        /*        [HttpDelete("{id}")]
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
                }*/
    }
}
