using Microsoft.AspNetCore.Mvc;
using PIRS.Models;
using PIRS.Models.ReportModel;

namespace PIRS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly PirsContext pirsContext;
        public ReportController(PirsContext pirsContext)
        {
            this.pirsContext = pirsContext;
        }

        [HttpPost]
        public ActionResult<Report> Create(Report report)
        {
            pirsContext.Report.Add(report);
            // Manage Pics
            pirsContext.SaveChanges();
            return report;

        }
        [HttpPut]
        public IActionResult Update(Report report)
        {
            report = pirsContext.Report.Find(report.ReportId);
            pirsContext.Report.Update(report);
            //Manage Pics
            pirsContext.SaveChanges();
            return NotFound();
        }
        [HttpDelete]
        public ActionResult<Report> Delete(int id)
        {
            Report report = pirsContext.Report.Find(id);
            pirsContext.Report.Remove(report);
            pirsContext.SaveChanges();
            return report;
        }
        [HttpGet]
        public ActionResult<List<Report>> GetAll() 
        {
            return pirsContext.Report.ToList<Report>();
        }
        [HttpGet("GetByContractor/{ContractrId}",Name ="GetByContractor")]
        public ActionResult<List<Report>> GetByContractor(int id)
        {
            return pirsContext.Report.Where<Report>(r => r.Contractor.Id == id).ToList<Report>();
        }
        [HttpGet("{id}",Name ="GetById")]
        [ActionName("GetById")]
        public ActionResult<Report> GetById(int id)
        {
            return pirsContext.Report.FirstOrDefault<Report>(r=>r.ReportId==id);
        }
    }
}
