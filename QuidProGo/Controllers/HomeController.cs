using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuidProGo.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using QuidProGo.Repositories;

namespace QuidProGo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public HomeController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public IActionResult Index()
        {
            var userProfileId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var userProfile = _userProfileRepository.GetById(userProfileId);
            if (userProfile.UserTypeId == 1)
            {
                return RedirectToAction("Index", "Attorney");
            }
            else
            {
                return View(userProfile);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}