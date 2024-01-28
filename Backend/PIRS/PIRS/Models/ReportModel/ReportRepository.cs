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
        private readonly UserManager<AppUser> _userManager;
        private readonly HelperService helperService;
        public ReportRepository(PirsContext pirsContext ,UserManager<AppUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _context = pirsContext;
            helperService = new HelperService(webHostEnvironment, userManager);
        }

        public async void Add(Report report)
        {
            _context.Reports.Add(report);

            _context.SaveChanges();
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
        public List<Report> Sort(string? companyId, GeoCoordinate? geoCoordinate, ReportStatus? status)
        {
            if ((companyId != null) && (geoCoordinate != null) && (status.HasValue))
            {
                return _context.Reports.Where(r => (r.Company.Id == companyId) && (r.status == status)).OrderBy(r => r.location.GetDistanceTo(geoCoordinate)).ThenBy(r => r.upvotes.Count).ToList();
            }
            else if ((companyId != null) && (geoCoordinate != null))
            {
                return _context.Reports.Where(r => r.Company.Id == companyId).OrderBy(r => r.location.GetDistanceTo(geoCoordinate)).ThenBy(r => r.upvotes.Count).ToList();
            }
            else if ((companyId != null) && (status.HasValue))
            {
                return _context.Reports.Where(r => (r.Company.Id == companyId) && (r.status == status)).OrderBy(r => r.upvotes.Count).ToList();
            }
            else if ((geoCoordinate != null) && (status.HasValue))
            {
                return _context.Reports.Where(r => (r.status == status)).OrderBy(r => r.location.GetDistanceTo(geoCoordinate)).ThenBy(r => r.upvotes.Count).ToList();
            }
            else if (companyId != null)
            {
                return _context.Reports.Where(r => r.Company.Id == companyId).OrderBy(r => r.upvotes.Count).ToList();
            }
            else if (geoCoordinate != null)
            {
                return _context.Reports.OrderBy(r => r.location.GetDistanceTo(geoCoordinate)).ThenBy(r => r.upvotes.Count).ToList();
            }
            else if (status.HasValue)
            {
                return _context.Reports.Where(r => r.status == status).OrderBy(r => r.upvotes.Count).ToList();
            }
            else
            {
                return _context.Reports.OrderBy(r => r.upvotes.Count).ToList();
            }
        }

    }
}
