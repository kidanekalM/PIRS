using Microsoft.AspNetCore.Mvc;
using PIRS.Models.ReportModel;

namespace PIRS.Controllers
{
    public class ReportController : Controller
    {
        public Report Index()
        {
            Report report = new Report();
            report.Title = "Here";
            report.Description = "Is";
            return report;
        }
        // add
        // edit
        // delete,
        // getall
        // getbycontractorId
        // get by id
        // get by company id
        // get by contractor id
        // get by user id
    }
}
