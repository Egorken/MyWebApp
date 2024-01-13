using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyWebApp.Data;
using MyWebApp.Data.Identity;

namespace MyWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationIdentityUser> userManager;

        public IndexModel(
            ILogger<IndexModel> logger,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationIdentityUser> userManager
            )
        {
            _logger = logger;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public void OnGet()
        {

        }

        //public async Task OnPostNewRole(RoleModel model)
        //{
        //    string roleName = model.RoleName.Trim();
        //    if (!string.IsNullOrEmpty(roleName))
        //    {
        //        if (!await roleManager.RoleExistsAsync(roleName))
        //        {
        //            try
        //            {
        //                // Создание уникального значения для ConcurrencyStamp
        //                var concurrencyStamp = Guid.NewGuid().ToString();

        //                // Создание роли с уникальным значением ConcurrencyStamp
        //                var role = new IdentityRole
        //                {
        //                    Name = roleName,
        //                    NormalizedName = roleName,
        //                    ConcurrencyStamp = concurrencyStamp
        //                };

        //                // Создание роли в базе данных
        //                await roleManager.CreateAsync(role);

        //                _logger.LogInformation($"New role '{roleName}' created successfully.");
        //            }
        //            catch (Exception ex)
        //            {
        //                _logger.LogError($"Failed to create new role '{roleName}': {ex.Message}");
        //            }
        //        }
        //        else
        //        {
        //            _logger.LogWarning($"Role '{roleName}' already exists.");
        //        }
        //    }
        //}

        //public async Task OnPostAddRole(RoleModel model)
        //{
        //    string roleName = model.RoleName.Trim();
        //    if (!string.IsNullOrEmpty(roleName))
        //    {
        //        var usr = await userManager.GetUserAsync(User);

        //        if (usr != null)
        //        {
        //            try
        //            {
        //                var result = await userManager.AddToRoleAsync(usr, roleName);

        //                if (result.Succeeded)
        //                {
        //                    TempData["Message"] = $"Role '{roleName}' added to the user successfully.";
        //                    _logger.LogInformation($"Role '{roleName}' added to the user '{usr.UserName}' successfully.");
        //                }
        //                else
        //                {
        //                    TempData["ErrorMessage"] = $"Failed to add role '{roleName}' to the user: {string.Join(", ", result.Errors)}";
        //                    _logger.LogError($"Failed to add role '{roleName}' to the user '{usr.UserName}': {string.Join(", ", result.Errors)}");
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                TempData["ErrorMessage"] = $"An error occurred while adding role '{roleName}' to the user.";
        //                _logger.LogError($"An error occurred while adding role '{roleName}' to the user '{usr.UserName}': {ex.Message}");
        //            }
        //        }
        //        else
        //        {
        //            TempData["ErrorMessage"] = "User not found.";
        //            _logger.LogWarning("User not found.");
        //        }
        //    }
        //    else
        //    {
        //        TempData["ErrorMessage"] = "Role name is null or empty.";
        //        _logger.LogWarning("Role name is null or empty.");
        //    }
        //}

        //public async Task OnPostRemoveRole(RoleModel model)
        //{
        //    string roleName = model.RoleName.Trim();
        //    if (!string.IsNullOrEmpty(roleName))
        //    {
        //        var usr = await userManager.GetUserAsync(User);

        //        if (usr != null)
        //        {
        //            try
        //            {
        //                await userManager.RemoveFromRoleAsync(usr, roleName);

        //                _logger.LogInformation($"Role '{roleName}' removed from the user '{usr.UserName}' successfully.");
        //            }
        //            catch (Exception ex)
        //            {
        //                _logger.LogError($"Failed to remove role '{roleName}' from the user '{usr.UserName}': {ex.Message}");
        //            }
        //        }
        //        else
        //        {
        //            _logger.LogWarning("User not found.");
        //        }
        //    }
        //    else
        //    {
        //        _logger.LogWarning("Role name is null or empty.");
        //    }
        //}
    }
}
