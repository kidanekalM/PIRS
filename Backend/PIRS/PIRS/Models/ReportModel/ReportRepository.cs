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
            //return _context.Report.Where(r => r.Company.Id == id).ToList();
            throw new NotImplementedException(); 
        }

        public List<Report> GetByCompany(int id, string state)
        {
            //return _context.Report.Where(r => r.Company.Id == id && r.User.State == state).ToList();
            throw new NotImplementedException();

        }

        public List<Report> GetByContractor(int id)
        {
            //return _context.Report.Where(r => r.Contractor.Id == id).ToList();
            throw new NotImplementedException();

        }

        public Report GetById(int id)
        {
            return _context.Report.FirstOrDefault(r => r.ReportId == id);
        }

        public List<Report> GetByLocation(GeoCoordinate location)
        {
            var reports = _context.Report.ToList();
            var nearbyReports = new List<Report>();
            foreach (var report in reports)
            {
                var reportLocation = new GeoCoordinate(report.location.Latitude, report.location.Longitude);
                
                if (reportLocation.GetDistanceTo(location) < 1000)
                {
                    nearbyReports.Add(report);
                }
            }
            nearbyReports.Sort((a,b)=>location.GetDistanceTo(new GeoCoordinate(nt.Parse(a.location.Latitude),a.location.Longitude))-location.GetDistanceTo(new GeoCoordinate(b.location.Latitude, b.location.Longitude));
            return nearbyReports;
        }

        public List<Report> GetByUser(int id)
        {
            //return _context.Report.Where(r => r.User.Id == id).ToList();
            throw new NotImplementedException();
        }

        public Report Update(Report report)
        {
            _context.Report.Update(report);
            _context.SaveChanges();
            return report;
        }
    }
}
