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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AspUserShow AspUserShow { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspusershow = await _context.AspUserShow.FirstOrDefaultAsync(m => m.UserId == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspusershow = await _context.AspUserShow.FindAsync(id);
            if (aspusershow != null)
            {
                AspUserShow = aspusershow;
                _context.AspUserShow.Remove(AspUserShow);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
