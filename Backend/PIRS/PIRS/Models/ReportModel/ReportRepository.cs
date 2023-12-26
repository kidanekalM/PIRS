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
            _context.Report.Add(report);
            _context.SaveChanges();
        }

        public Report Delete(Report report)
        {
            _context.Report.Remove(report);
            _context.SaveChanges();
            return report;
        }

        public List<Report> GetAll()
        {
            return _context.Report.ToList();
        }

        public List<Report> GetByCompany(int id)
        {
            return _context.Report.Where(r => r.Company.Id == id).ToList(); 
        }

        public List<Report> GetByCompany(int id, Report.reportStatus status)
        {
            //return _context.Report.Where(r => r.Company.Id == id && r.User.State == state).ToList();
            throw new NotImplementedException();
        }

        public List<Report> GetByContractor(int id)
        {
            return _context.Report.Where(r => r.Contractor.Id == id).ToList();
        }

        public Report GetById(int id)
        {
            return _context.Report.FirstOrDefault(r => r.ReportId == id);
        }

        public List<Report> GetByLocation(GeoCoordinate location)
        {
            var reports = _context.Report.ToList();
            reports.Sort((a,b)=>(int)location.GetDistanceTo(new GeoCoordinate(a.location.Latitude, a.location.Longitude))-(int)location.GetDistanceTo(new GeoCoordinate(b.location.Latitude,b.location.Longitude))); 
            return reports;
        }
        public List<Report> GetByLocationAndCompany(GeoCoordinate location,int id)
        {
            var reports = _context.Report.Where<Report>(r=>r.Company.Id == id).ToList();
            reports.Sort((a, b) => (int)location.GetDistanceTo(a.location) - (int)location.GetDistanceTo(b.location));
            return reports;    
        }
        public List<Report> GetByUser(int id)
        {
            return _context.Report.Where(r => r.User.Id == id).ToList();
        }

        public Report Update(Report report)
        {
            _context.Report.Update(report);
            _context.SaveChanges();
            return report;
        }
    }
}
