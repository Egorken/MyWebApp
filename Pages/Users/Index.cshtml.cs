using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public IndexModel(UserManager<ApplicationIdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IList<AspUserShow> AspUserShow { get; set; } = new List<AspUserShow>();

        public async Task OnGetAsync()
        {
            AspUserShow = await _userManager.Users
                .Join(
                    _context.UserRoles,
                    u => u.Id,
                    ur => ur.UserId,
                    (user, userRole) => new { User = user, UserRole = userRole }
                )
                .Join(
                    _context.Roles,
                    ur => ur.UserRole.RoleId,
                    role => role.Id,
                    (ur, role) => new AspUserShow
                    {
                        Id = ur.User.Id,
                        UserName = ur.User.UserName,
                        Email = ur.User.Email,
                        RoleName = role.Name
                    }
                )
                .ToListAsync();
        }
    }
}

