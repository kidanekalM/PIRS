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
        Report GetById(int id);
        List<Report> GetAll();
        List<Report> GetByUser(int id);
        List<Report> GetByCompany(int id);
        List<Report> GetByContractor(int id);
        List<Report> GetAllNear(GeoCoordinate location,double distance);
    }
}
