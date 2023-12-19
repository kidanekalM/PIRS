namespace PIRS.Models.ReportModel
{
    public class ReportRepository : IReportRepository
    {
        void IReportRepository.Add(Report report)
        {
            
        }

        Report IReportRepository.Delete(Report report)
        {
            throw new NotImplementedException();
        }

        List<Report> IReportRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        List<Report> IReportRepository.GetByCompany(int id)
        {
            throw new NotImplementedException();
        }

        List<Report> IReportRepository.GetByContractor(int id)
        {
            throw new NotImplementedException();
        }

        Report IReportRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        List<Report> IReportRepository.GetByUser(int id)
        {
            throw new NotImplementedException();
        }

        Report IReportRepository.Update(Report report)
        {
            throw new NotImplementedException();
        }
    }
}
