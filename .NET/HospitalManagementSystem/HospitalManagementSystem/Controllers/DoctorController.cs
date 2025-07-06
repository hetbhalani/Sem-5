using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult DoctorAddEdit()
        {
            return View();
        }
        public IActionResult DoctorList()
        {
            return View();
        }
    }
}
