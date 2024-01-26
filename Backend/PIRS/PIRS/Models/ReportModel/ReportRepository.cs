using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PIRS.Controllers;
using PIRS.Models.UserModel;
using System.Device.Location;

namespace PIRS.Models.ReportModel
{
    public class ReportRepository : IReportRepository
    {
        private readonly PirsContext _context;
        private readonly IReportRepository _reportRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly HelperService helperService;
        public ReportRepository(PirsContext pirsContext ,UserManager<AppUser> userManager, IReportRepository reportRepository, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _context = pirsContext;
            _reportRepository = reportRepository;
            helperService = new HelperService(webHostEnvironment, userManager);
        }

        public async void Add(Report report)
        {
            _pirsContext.Reports.Add(report);

            _pirsContext.SaveChanges();
        }

        public Report Delete(Report report)
        {
            _context.Reports.Remove(report);
            _context.SaveChanges();
            return report;
        }

        public List<Report> GetAll()
        {
            return _context.Reports.ToList();
        }

        public List<Report> GetByCompany(int id)
        {
            return _context.Reports.Where(r => r.Company.Id.Equals(id.ToString())).ToList(); 
        }

        public List<Report> GetByCompany(int id, ReportStatus status)
        {
            return _context.Reports.Where(r => r.Company.Id.Equals(id.ToString() ) && r.status == status).ToList();
           
        }

        public List<Report> GetByContractor(int id)
        {
            return _context.Reports.Where(r => r.Contractor.Id.Equals(id.ToString() ) ).ToList();
        }

        public Report GetById(int id)
        {
            return _context.Reports.FirstOrDefault(r => r.ReportId == id);
        }

        public List<Report> GetByLocation(GeoCoordinate location)
        {
            var reports = _context.Reports.ToList();
            reports.Sort((a,b)=>(int)location.GetDistanceTo(new GeoCoordinate(a.location.Latitude, a.location.Longitude))-(int)location.GetDistanceTo(new GeoCoordinate(b.location.Latitude,b.location.Longitude))); 
            return reports;
        }
        public List<Report> GetByLocationAndCompany(GeoCoordinate location,int id)
        {
            var reports = _context.Reports.Where<Report>(r=>r.Company.Id.Equals(id.ToString()) ).ToList();
            reports.Sort((a, b) => (int)location.GetDistanceTo(a.location) - (int)location.GetDistanceTo(b.location));
            return reports;    
        }
        public List<Report> GetByUser(int id)
        {
            return _context.Reports.Where(r => r.User.Id.Equals( id.ToString() ) ).ToList();
        }

        public Report Update(Report report)
        {
            _context.Reports.Update(report);
            _context.SaveChanges();
            return report;
        }
        //sorts on all parameters compnay, dateTime, Upvotes, location, status 
        public List<Report> Sort(string? companyId, GeoCoordinate? geoCoordinate, ReportStatus? status)
        {
            if ((companyId != null) && (geoCoordinate!=null) && (status.HasValue))
            {
                _context.Reports.Where(r => (r.Company.Id == companyId) && (r.status == status)).ToList().Sort();
            }
        }

    }
}
