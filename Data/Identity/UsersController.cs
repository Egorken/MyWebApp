using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Data.Identity;
using Microsoft.EntityFrameworkCore;

public class UsersController : Controller
{
    private readonly UserManager<AspUserShow> _userManager;

    public UsersController(UserManager<AspUserShow> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var users = await GetUsersAsync();
        return View(users);
    }

    private async Task<List<AspUserShow>> GetUsersAsync()
    {
        return await _userManager.Users.Select(u => new AspUserShow
        {
            UserName = u.UserName,
            Email = u.Email,
        }).ToListAsync();
    }
}