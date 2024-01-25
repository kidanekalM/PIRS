
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace PIRS.Models
{
    public class PirsContext : IdentityDbContext<UserModel.AppUser>
    {
        public PirsContext(DbContextOptions<PirsContext> options):base(options)
        {

        }
       public DbSet<TransactionModel.Transaction>? Transactions { get; set; }

    }
}
