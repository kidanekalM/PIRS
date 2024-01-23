using Microsoft.AspNetCore.Components.Routing;
using System.Device;
using System.Device.Location;

namespace PIRS.Models.ReportModel
{
    public interface IReportRepository
    {
        void Add(Report report);
        Report Update(Report report);
        Report Delete (Report report);
        List<Report> GetAll();
        Report GetById(int id);
        List<Report> GetByUser(int id);
        List<Report> GetByCompany(int id);
        List<Report> GetByCompany(int id,Report.ReportStatus status);
        List<Report> GetByContractor(int id);
        List<Report> GetByLocation(GeoCoordinate location);
        List<Report> GetByLocationAndCompany(GeoCoordinate location,int id);
    }
}
