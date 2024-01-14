using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Data.Identity;
using System.Threading.Tasks;

namespace MyWebApp.Pages.GamesCatalog
{
    [Authorize(Roles = "Admin, Editor, Client")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Games> Games { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Games = await _context.Games.ToListAsync();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int gameId)
        {
            var game = await _context.Games.FindAsync(gameId);

            if (game != null && game.QuantityAvailable > 0)
            {

                game.QuantityAvailable--;

                if (game.QuantityAvailable == 0) // Если QuantityAvailable стало 0, установите Avalible в false
                {
                    game.Avalible = false;
                }


                await _context.SaveChangesAsync();

                Games = await _context.Games.ToListAsync();

                return Page();
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
    }
}