using Microsoft.AspNetCore.Mvc;
using System.Device.Location;

namespace PIRS.Models.ReportModel
{
    public class ReportRepository : IReportRepository
    {
        private readonly PirsContext _context;
        public ReportRepository(PirsContext context)
        {
            _context = context;
        }

        public void Add(Report report)
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
            return _context.Reports.Where(r => r.Company.Id == id.ToString()).ToList(); 
        }

        public List<Report> GetByCompany(int id, Report.ReportStatus status)
        {
            //return _context.Report.Where(r => r.Company.Id == id && r.User.State == state).ToList();
            throw new NotImplementedException();
        }

        public List<Report> GetByContractor(int id)
        {
            return _context.Reports.Where(r => r.Contractor.Id == id.ToString()).ToList();
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
            var reports = _context.Reports.Where<Report>(r=>r.Company.Id == id.ToString()).ToList();
            reports.Sort((a, b) => (int)location.GetDistanceTo(a.location) - (int)location.GetDistanceTo(b.location));
            return reports;    
        }
        public List<Report> GetByUser(int id)
        {
            return _context.Reports.Where(r => r.User.Id == id.ToString()).ToList();
        }

        public Report Update(Report report)
        {
            _context.Reports.Update(report);
            _context.SaveChanges();
            return report;
        }
    }
}
