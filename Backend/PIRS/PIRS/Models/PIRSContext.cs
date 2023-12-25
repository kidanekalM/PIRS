using Microsoft.EntityFrameworkCore;
using PIRS.Models.ReportModel;

namespace PIRS.Models
{
    public class PirsContext : DbContext
    {
        public PirsContext(DbContextOptions<PirsContext> options):base(options)
        {

        }
        public DbSet<ImageGallery> ImageGallery { get; set; }
        public DbSet<Report> Report { get; set; }
    }
}
