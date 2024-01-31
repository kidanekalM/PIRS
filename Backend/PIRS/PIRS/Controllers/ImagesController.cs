using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PIRS.Models.ReportModel;
using PIRS.Models.UserModel;
using static System.Net.Mime.MediaTypeNames;

namespace PIRS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public ImagesController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult GetImage(string id)
        {
            var pathToFile = Path.Combine(webHostEnvironment.WebRootPath, "Images");
            pathToFile = Path.Combine(pathToFile, id);
            var stream = System.IO.File.OpenRead(pathToFile);
            return File(stream, "image/"+id.Substring(id.IndexOf(".")));
        }

        // Additional actions for other image operations...
    }
}
