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
        public string? PaymentInfo { get; set; }
        // Name
        public string? Name { get; set; }
        // For contractor 
      //  public User? HiringCompany { get; set; }
        // Rating for Contractor
        //public RatingModel.Rating Rating { get; set; }

    }
}
