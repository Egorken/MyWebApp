using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using MyWebApp.Data.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MyWebApp.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EditModel(UserManager<ApplicationIdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Id { get; set; }

        [BindProperty]
        public List<string> SelectedRoles { get; set; }

        public SelectList RolesList { get; set; }

        public async Task OnGetAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user != null)
            {
                UserName = user.UserName;
                Email = user.Email;
                Id = user.Id;

                // Получить список всех ролей
                var roles = await _roleManager.Roles.ToListAsync();

                // Инициализировать список ролей для dropdown
                RolesList = new SelectList(roles, nameof(IdentityRole.Name), nameof(IdentityRole.Name));

                // Получить список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);

                // Установить выбранные роли пользователя
                SelectedRoles = userRoles.ToList();
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
                    // Установить роли пользователя
                    var userRoles = await _userManager.GetRolesAsync(user);
                    await _userManager.RemoveFromRolesAsync(user, userRoles);
                    await _userManager.AddToRolesAsync(user, SelectedRoles);

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