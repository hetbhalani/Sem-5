using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class DoctorDeptController : Controller
    {
        public IActionResult DocDeptAddEdit()
        {
            return View();
        }

        public IActionResult DocDeptList()
        {
            return View();
        }
    }
}
