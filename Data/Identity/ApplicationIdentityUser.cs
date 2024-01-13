using Microsoft.AspNetCore.Identity;

namespace MyWebApp.Data.Identity
{
    public class ApplicationIdentityUser : IdentityUser
    {
        public long AplicationId { get; set; }
    }
}
