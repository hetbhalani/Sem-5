using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HospitalManagementSystem.Controllers
{
    public class DoctorDeptController : Controller
    {
        private IConfiguration _configuration;

        public DoctorDeptController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult DocDeptAddEdit()
        {
            return View();
        }

        public IActionResult DocDeptList()
        {
            string DbConnect = this._configuration.GetConnectionString("DbConnect");
            SqlConnection connection = new SqlConnection(DbConnect);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_DOCDEPT_SelectAll";
            SqlDataReader reader = command.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            return View(table);
        }
        public IActionResult ExportToExcel()
        {
            string connectionString = _configuration.GetConnectionString("DbConnect");

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("PR_DOCDEPT_SelectAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }

            using (XLWorkbook wb = new())
            {
                wb.Worksheets.Add(dt, "Users");
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream.ToArray(),
                                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                                "Users.xlsx");
                }
            }
        }
    }
}
