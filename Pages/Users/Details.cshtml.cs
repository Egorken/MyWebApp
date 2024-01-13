using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data.Identity;

namespace MyWebApp.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public AspUserShow AspUserShow { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Преобразуйте id в строку
            var aspusershow = await _context.AspUserShow.FirstOrDefaultAsync(m => m.Id.ToString() == id.ToString());
            if (aspusershow == null)
            {
                return NotFound();
            }
            else
            {
                AspUserShow = aspusershow;
            }
            return Page();
        }
    }
}
