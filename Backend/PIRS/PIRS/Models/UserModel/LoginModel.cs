using System.Security.Claims;

namespace PIRS.Models.UserModel
{
    public class LoginModel
    {
        public ClaimsIdentity? Username { get; internal set; }
    }
}