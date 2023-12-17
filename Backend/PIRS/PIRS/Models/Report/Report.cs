using System.Reflection;

namespace PIRS.Models.Report
{
    public class Report
    {
        int ReportId {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        User User { get; set; }
        Company Company { get; set; }
        string location { get; set; }
        float awardAmount { get; set; }
        string status { get; set; }
        DateTime DateTime { get; set; }
        List<ReportUpvote> upvotes { get; set; }
    }
}
