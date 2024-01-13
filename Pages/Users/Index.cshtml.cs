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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AspUserShow> AspUserShow { get; set; } = new List<AspUserShow>();

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                AspUserShow = await _context.AspUserShow.ToListAsync();
                return Page();
            }
            catch (Exception ex)
            {
                // Обработка ошибок (вывод в лог, отображение пользователю и т. д.)
                ModelState.AddModelError(string.Empty, "An error occurred while retrieving user data.");
                return Page();
            }
        }
    }
}