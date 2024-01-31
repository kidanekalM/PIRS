using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace PIRS.Models
{
    public class PirsContext : IdentityDbContext<UserModel.AppUser>
    {
        public PirsContext(DbContextOptions<PirsContext> options):base(options)
        {

        }
        public int CompanyId { get; set; }  
    }
}
