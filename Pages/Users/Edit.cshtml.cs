using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebApp.Data.Identity;

namespace MyWebApp.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;

        public EditModel(UserManager<ApplicationIdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Id { get; set; }

        public async Task OnGetAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user != null)
            {
                UserName = user.UserName;
                Email = user.Email;
                Id = user.Id;
            }
            else
            {
                // Обработка ошибки, если пользователя не удалось найти
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByIdAsync(Id.ToString());

            if (user != null)
            {
                user.UserName = UserName;
                user.Email = Email;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    // Обработка ошибки при обновлении пользователя
                }
            }
            else
            {
                // Обработка ошибки, если пользователя не удалось найти
            }

            return Page();
        }
    }
}