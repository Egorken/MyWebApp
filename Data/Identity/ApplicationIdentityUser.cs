using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApp.Data.Identity
{
    public class ApplicationIdentityUser : IdentityUser
    {
        public long AplicationId { get; set; }
    }
}
