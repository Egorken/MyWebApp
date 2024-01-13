using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebApp.Data.Identity;

namespace MyWebApp.Pages.Users
{
    public class UserRolesModel: PageModel
    {
        [BindProperty]
        public UserRolesViewModel UserRoleViewModel { get; set; }

        public void OnGet()
        {
            UserRoleViewModel = new UserRolesViewModel
            {
                AvailableRoles = new List<string> { "Admin", "Editor", "Client" }
            };
        }

        public IActionResult OnPost()
        {
            // Обработка выбранной роли (this.UserRoleViewModel.SelectedRole)
            // Вы можете использовать выбранную роль для выполнения соответствующих действий.
            // Например, применение роли к пользователю.

            // Редирект на другую страницу или выполнение других действий

            return RedirectToPage("/Index");
        }
    }
}
