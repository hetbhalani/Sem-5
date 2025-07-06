using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult AppointmentAddEdit()
        {
            return View();
        }
        public IActionResult AppointmentList()
        {
            return View();
        }
    }
}
