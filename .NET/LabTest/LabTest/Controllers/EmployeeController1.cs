using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace LabTest.Controllers
{
    public class EmployeeController1 : Controller
    {
        private IConfiguration _configuration;

        public EmployeeController1(IConfiguration configuration) { 
            _configuration = configuration;
        }
        public IActionResult SelectAllEmployee()
        {
            String DbConnect = this._configuration.GetConnectionString("DbConnect");
            SqlConnection connection = new SqlConnection(DbConnect);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_EMP_SelectAll";

            SqlDataReader reader = command.ExecuteReader();

            DataTable tbl = new DataTable();
            tbl.Load(reader);


            return View(tbl);
        }

        public IActionResult DeleteEmployee(int EmpId)
        {
            string DbConnect = this._configuration.GetConnectionString("DbConnect");
            SqlConnection connection = new SqlConnection(DbConnect);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_EMP_Delete";

            command.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = EmpId;

            command.ExecuteNonQuery();

            return RedirectToAction("SelectAllEmployee");
        }
    }
}
