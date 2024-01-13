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
            // ��������� ��������� ���� (this.UserRoleViewModel.SelectedRole)
            // �� ������ ������������ ��������� ���� ��� ���������� ��������������� ��������.
            // ��������, ���������� ���� � ������������.

            // �������� �� ������ �������� ��� ���������� ������ ��������

            return RedirectToPage("/Index");
        }
    }
}
