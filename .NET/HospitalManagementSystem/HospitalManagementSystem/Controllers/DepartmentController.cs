using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult DepartmentAddEdit()
        {
            return View();
        }
        public IActionResult DepartmentList()
        {
            return View();
        }
    }
}
