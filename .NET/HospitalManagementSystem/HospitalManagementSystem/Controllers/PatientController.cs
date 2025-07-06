using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult PatientAddEdit()
        {
            return View();
        }
        public IActionResult PatientList()
        {
            return View();
        }
    }
}
