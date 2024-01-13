//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using MyWebApp.Data.Identity;


//public class UsersController : Controller
//{
//    private readonly UserManager<ApplicationIdentityUser> _userManager;

//    public UsersController(UserManager<ApplicationIdentityUser> userManager)
//    {
//        _userManager = userManager;
//    }

//    public async Task<IActionResult> Index()
//    {
//        var users = await _userManager.Users.Select(u => new AspUserShow
//        {
//            UserName = u.UserName,
//            Email = u.Email,
//        }).ToListAsync();

//        return View(users);
//    }
//}