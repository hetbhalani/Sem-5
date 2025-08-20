using Microsoft.AspNetCore.Mvc;
using testLab.Models;


namespace testLab.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserAddEdit(UserModel um)
        {
            ViewBag.Name = um.Name;
            ViewBag.Email = um.Email;

            return View();
        }

        //

        public IActionResult UserAddEdit()
        {
            return View();
        }
    }
}
