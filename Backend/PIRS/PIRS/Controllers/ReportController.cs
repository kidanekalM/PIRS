using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PIRS.Models.ReportModel;
using PIRS.Models.UserModel;
using System.Device.Location;
using System.Security.Permissions;

namespace PIRS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly HelperService helperService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReportController(UserManager<AppUser> userManager,IReportRepository reportRepository,IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _reportRepository = reportRepository;
            _webHostEnvironment = webHostEnvironment;
            helperService = new HelperService(webHostEnvironment,userManager);
        }

        [HttpPost]
        public async Task<ActionResult<ReportDto<ImageGallery>>> Create([FromForm] ReportDto<IFormFile> reportDto)
        {
            var report = await helperService.ToModel(reportDto);
            _reportRepository.Add(report);
            return helperService.ToDto(report);

        }

        [HttpPut]
        public async Task<ActionResult<ReportDto<ImageGallery>>> Update([FromForm]ReportDto<IFormFile> reportDto)
        {
            var newReport = await helperService.ToModel(reportDto);
            var oldReport = _reportRepository.GetById(reportDto.ReportId);
            if (oldReport == null)
                return NotFound();
            if(oldReport.pictures != null)
            foreach (var img in oldReport.pictures)
            {
                var AbsLocation = Path.Combine(_webHostEnvironment.WebRootPath, img.Image);
                System.IO.File.Delete(AbsLocation);
            }
            oldReport.Title = newReport.Title;
            oldReport.Description = newReport.Description;
            oldReport.User = newReport.User;
            oldReport.Company = newReport.Company;
            oldReport.Contractor = newReport.Contractor;
            oldReport.location = newReport.location;
            oldReport.awardAmount = newReport.awardAmount;
            oldReport.status = newReport.status;
            oldReport.DateTime = newReport.DateTime;
            oldReport.upvotes = newReport.upvotes;
            oldReport.pictures = newReport.pictures;

            _reportRepository.Update(oldReport);
            return helperService.ToDto(oldReport);
        }
        [HttpDelete]
        public ActionResult<ReportDto<ImageGallery>> Delete(int id)
        {
            Report report = _reportRepository.GetById(id);
            if(report == null)
                return NotFound();
            foreach(var img in report.pictures)
            {
                var AbsLocation = Path.Combine(_webHostEnvironment.WebRootPath, img.Image);
                System.IO.File.Delete(AbsLocation);
            }
            report = _reportRepository.Delete(report);
            return helperService.ToDto(report);
        }
        [HttpGet]
        public ActionResult<List<ReportDto<ImageGallery>>> GetAll() 
        {
            var reports = _reportRepository.GetAll();
            var reportsDto = new List<ReportDto<ImageGallery>>();
            if (reports == null)
                return NotFound();
            foreach (var item in reports)
            {
                var reportDto = helperService.ToDto(item);
                reportsDto.Add(reportDto);
            }
            return reportsDto;
        }
        [HttpGet("{id}",Name ="GetById")]
        [ActionName("GetById")]
        public ActionResult<ReportDto<ImageGallery>> GetById(int id)
        {
            var report = _reportRepository.GetById(id);
            if(report==null)
                return NotFound();
            return helperService.ToDto(report);
        }
        [HttpGet("GetByContractor/{ContractrId}",Name ="GetByContractor")]
        public ActionResult<List<ReportDto<ImageGallery>>> GetByContractor(int id)
        {
            List<ReportDto<ImageGallery>> reportDtos = new List<ReportDto<ImageGallery>>();
            var reports = _reportRepository.GetByContractor(id);
            if(reports == null)
                return NotFound();
            foreach(var item in reports)
            {
                reportDtos.Add( helperService.ToDto(item));
            }
            return reportDtos;
        }
        [HttpGet("GetByUser/{UserId}", Name = "GetByUser")]
        public ActionResult<List<ReportDto<ImageGallery>>> GetByUser(int id)
        {
            List<ReportDto<ImageGallery>> reportDtos = new List<ReportDto<ImageGallery>>();
            var reports = _reportRepository.GetByUser(id);
            if (reports == null)
                return NotFound();
            foreach (var item in reports)
            {
                reportDtos.Add(helperService.ToDto(item));
            }
            return reportDtos;
        }
        [HttpGet("GetByCompany/{CompanyId}", Name = "GetByCompany")]
        public ActionResult<List<ReportDto<ImageGallery>>> GetByCompnany(int id)
        {
            List<ReportDto<ImageGallery>> reportDtos = new List<ReportDto<ImageGallery>>();
            var reports = _reportRepository.GetByCompany(id);
            if (reports == null)
                return NotFound();
            foreach (var item in reports)
            {
                reportDtos.Add(helperService.ToDto(item));
            }
            return reportDtos;
        }
        /*//**/
        [HttpGet("GetByLocation/{Location}", Name = "GetByLocation")]
        public ActionResult<List<ReportDto<ImageGallery>>> GetByLocation(GeoCoordinate geoCoordinate)
        {
            List<ReportDto<ImageGallery>> reportDtos = new List<ReportDto<ImageGallery>>();
            var reports = _reportRepository.GetByLocation(geoCoordinate);
            if (reports == null)
                return NotFound();
            foreach (var item in reports)
            {
                reportDtos.Add(helperService.ToDto(item));
            }
            return reportDtos;
        }
        [HttpGet("Sort/{companyId}/{geoCoordinate}/{status}")]
        public ActionResult Sort(GeoCoordinate geoCoordinate=null,string companyId = null, ReportStatus status = 0)
        {
            var reports = _reportRepository.Sort(companyId, geoCoordinate, status);
            var reportDtos = new List<ReportDto<ImageGallery>>();
            foreach(Report r in reports)
            {
                reportDtos.Add(helperService.ToDto(r));
            }

            return Ok(reportDtos);
        }

    }

}
