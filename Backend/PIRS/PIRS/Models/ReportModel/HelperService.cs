using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PIRS.Models.UserModel;

namespace PIRS.Models.ReportModel
{
    [NonController]
    public class HelperService
    {
        /*
        * saves images in local file storage wwwroot/images/report
         */
        public readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<AppUser> _userManager;
        public HelperService(IWebHostEnvironment webHostEnvironment, UserManager<AppUser> userManager)
        {
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }
        public List<ImageGallery> SaveImages(List<IFormFile> images)
        {
            var savedPictures = new List<ImageGallery>();
            string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Report");
            foreach (var img in images)
            {
                var fileName = Guid.NewGuid().ToString() + "_" + img.FileName;
                var uniqueCFileName = Path.Combine(uploadFolder, fileName);
                img.CopyTo(new FileStream(uniqueCFileName, FileMode.Create));
                var productGallary = new ImageGallery();
                productGallary.Image = Path.Combine("Images", "Report", fileName);
                savedPictures.Add(productGallary);
            }
            return savedPictures;
        }
        public List<FileStream> GetImages(List<ImageGallery> images)
        {
            var savedImages = new List<FileStream>();
            if(images != null)
            foreach (var img in images)
            {
                var file = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Report", img.Image);
                var stream = new FileStream(file, FileMode.Open);
                savedImages.Add(stream);
            }
            return savedImages;
        }

        public ReportDto<FileStream> ToDto(Report report)
        {
            var reportDto = new ReportDto<FileStream>()
            {
                ReportId = report.ReportId,
                Title = report.Title,
                Description = report.Description,
                CompanyId = report.Company != null ? report.Company.Id : null,
                UserId = report.User != null ? report.User.Id : null,
                ContractorId = report.Contractor != null ? report.Contractor.Id : null,
                location = report.location,
                awardAmount = report.awardAmount,
                status = ReportStatus.newReport,
                upvotes = report.upvotes,
                DateTime = report.DateTime,
                pictures = GetImages(report.pictures)

            };
            return reportDto;
        }
        public async Task<Report> ToModel(ReportDto<IFormFile> reportDto)
        {
            var report = new Report()
            {
                ReportId = reportDto.ReportId,
                Title = reportDto.Title,
                Description = reportDto.Description,
                Company = await _userManager.FindByIdAsync(reportDto.CompanyId),
                User = await _userManager.FindByIdAsync(reportDto.UserId),
                Contractor = await _userManager.FindByIdAsync(reportDto.ContractorId),
                location = reportDto.location,
                awardAmount = reportDto.awardAmount,
                status = ReportStatus.newReport,
                upvotes = reportDto.upvotes,
                DateTime = DateTime.Now,
                pictures = SaveImages(reportDto.pictures)
            };
            return report;
        }

    }
}
