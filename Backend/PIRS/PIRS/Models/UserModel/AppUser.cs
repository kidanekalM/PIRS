using Microsoft.AspNetCore.Identity;

namespace PIRS.Models.UserModel
{
    public partial class AppUser:IdentityUser
    {
        // Company
        public string? Logo { get; set; }
        //Company
        public string? Formula { get; set; }
        // Company and Contractor 
        public string PaymentInfo { get; } = "CHASECK_TEST-DDPjhSKiRFaBHM5cy1nrtSGeuMP0HgFC";
        // Name
        public string? Name { get; set; }
        // For contractor 
        public AppUser? HiringCompany { get; set; } = null;
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
