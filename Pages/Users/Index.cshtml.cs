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

        public IndexModel(UserManager<ApplicationIdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IList<AspUserShow> AspUserShow { get; set; } = new List<AspUserShow>();

        public async Task OnGetAsync()
        {
            AspUserShow = await _userManager.Users
                .Select(u => new AspUserShow
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                })
                .ToListAsync();
        }
    }
}

