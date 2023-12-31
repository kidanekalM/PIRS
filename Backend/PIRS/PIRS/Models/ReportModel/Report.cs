﻿using System.Reflection;
using PIRS.Models.UserModel;
using PIRS.Models.CompanyModel;
using PIRS.Models.ContractorModel;
using System.Device.Location;

namespace PIRS.Models.ReportModel
{
    public class Report
    {
        public enum reportStatus
        {
            newReport,
            inProgress,
            Submitted,
            Finished
        }
        public int ReportId {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public Company Company { get; set; }
        public Contractor Contractor { get; set; }
        public Location location { get; set; }
        public double awardAmount { get; set; }
        public reportStatus status { get; set; } = reportStatus.newReport;
        public DateTime DateTime { get; set; }
        public List<ReportUpvote> upvotes { get; set; }
        public List<ImageGallery> pictures { get; set; }
    }
}
