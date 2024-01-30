using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PIRS.Models.ReportModel;
using PIRS.Models.UserModel;
using static System.Net.Mime.MediaTypeNames;

namespace PIRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public ImagesController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("{id}")]
        public IActionResult GetImage(string name)
        {
            var pathToFile = Path.Combine(webHostEnvironment.WebRootPath, "Images", name); 
            var stream = System.IO.File.OpenRead(pathToFile);
            return File(stream, "application/octet-stream");
        }

        // Additional actions for other image operations...
    }
}
