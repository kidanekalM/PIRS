using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using PIRS.Models;
using PIRS.Models.ReportModel;
using PIRS.Models.UserModel;
using System.Device.Location;
using System.Runtime.InteropServices;

namespace PIRS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly HelperService helperService;
        public ReportController(UserManager<AppUser> userManager,IReportRepository reportRepository,IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _reportRepository = reportRepository;
            helperService = new HelperService(webHostEnvironment,userManager);
        }

        [HttpPost]
        public async Task<ActionResult<ReportDto<IFormFile>>> Create([FromForm] ReportDto<IFormFile> reportDto)
        {
            _reportRepository.Add(await helperService.ToModel(reportDto));
            return reportDto;

        }

        [HttpPut]
        public async Task<ActionResult<ReportDto<FileStream>>> Update([FromForm]ReportDto<IFormFile> reportDto)
        {
            var newReport = await helperService.ToModel(reportDto);
            var oldReport = _reportRepository.GetById(reportDto.ReportId);
            if (oldReport == null)
                return NotFound();
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
        public ActionResult<ReportDto<FileStream>> Delete(int id)
        {
            Report report = _reportRepository.GetById(id);
            report = _reportRepository.Delete(report);
            if(report == null)
                return NotFound();
            return helperService.ToDto(report);
        }
        [HttpGet]
        public ActionResult<List<ReportDto<FileStream>>> GetAll() 
        {
            var reports = _reportRepository.GetAll();
            var reportsDto = new List<ReportDto<FileStream>>();
            if (reports == null)
                return NotFound();
            foreach (var item in reports)
            {
                reportsDto.Add( helperService.ToDto(item));
            }
            return reportsDto;
        }
        [HttpGet("{id}",Name ="GetById")]
        [ActionName("GetById")]
        public ActionResult<ReportDto<FileStream>> GetById(int id)
        {
            var report = _reportRepository.GetById(id);
            if(report==null)
                return NotFound();
            return helperService.ToDto(report);
        }
        [HttpGet("GetByContractor/{ContractrId}",Name ="GetByContractor")]
        public ActionResult<List<ReportDto<FileStream>>> GetByContractor(int id)
        {
            List<ReportDto<FileStream>> reportDtos = new List<ReportDto<FileStream>>();
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
        public ActionResult<List<ReportDto<FileStream>>> GetByUser(int id)
        {
            List<ReportDto<FileStream>> reportDtos = new List<ReportDto<FileStream>>();
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
        public ActionResult<List<ReportDto<FileStream>>> GetByCompnany(int id)
        {
            List<ReportDto<FileStream>> reportDtos = new List<ReportDto<FileStream>>();
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
        public ActionResult<List<ReportDto<FileStream>>> GetByLocation(GeoCoordinate geoCoordinate)
        {
            List<ReportDto<FileStream>> reportDtos = new List<ReportDto<FileStream>>();
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
        public IActionResult Sort(string companyId, GeoCoordinate geoCoordinate, ReportStatus status)
        {
            var reports = _reportRepository.Sort(companyId, geoCoordinate, status);

            return Ok(reports);
        }

    }

}
