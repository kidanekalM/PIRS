using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PIRS.Models.ReportModel;
using PIRS.Models.UserModel;

namespace PIRS.Controllers
{
    public class ContractorController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly HelperService helperService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ContractorController(UserManager<AppUser> userManager, IUserRepository userRepository, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<ActionResult<AppUser>> Create([FromForm] AppUser reportDto)
        {
            return reportDto;

        }
    }
}