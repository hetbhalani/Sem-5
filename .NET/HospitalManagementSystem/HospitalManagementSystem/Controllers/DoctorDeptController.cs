using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class DoctorDeptController : Controller
    {
        private IConfiguration _configuration;

        public DoctorDeptController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult DocDeptAddEdit(int? DoctorDepartmentID)
        {
            DoctorDepartmentModel dm = new DoctorDepartmentModel();

            if (DoctorDepartmentID != null && DoctorDepartmentID > 0)
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("PR_DOCDEPT_SelectByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@DoctorDepartmentID", SqlDbType.Int).Value = DoctorDepartmentID;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    dm.DoctorDepartmentID = Convert.ToInt32(reader["DoctorDepartmentID"]);
                    dm.DoctorID = Convert.ToInt32(reader["DoctorID"]);
                    dm.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);

                    object userIdValue = reader["UserID"]; // guard against type/alias mismatches
                    if (userIdValue != DBNull.Value && userIdValue is int)
                    {
                        dm.UserID = (int)userIdValue;
                    }
                    else
                    {
                        try
                        {
                            int ordinal = reader.GetOrdinal("DoctorDepartmentUserID");
                            if (!reader.IsDBNull(ordinal))
                            {
                                dm.UserID = reader.GetInt32(ordinal);
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            // ignore if alias not present
                        }
                    }
                }
            }

            return View("DocDeptAddEdit", dm);
        }

        [HttpPost]
        public IActionResult DocDeptAddEdit(DoctorDepartmentModel dm)
        {
            if (ModelState.IsValid)
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;

                if (dm.DoctorDepartmentID > 0)
                {
                    command.CommandText = "PR_DOCDEPT_Update";
                    command.Parameters.AddWithValue("@DoctorDepartmentID", dm.DoctorDepartmentID);
                    command.Parameters.AddWithValue("@DoctorID", dm.DoctorID);
                    command.Parameters.AddWithValue("@DepartmentID", dm.DepartmentID);
                    command.Parameters.AddWithValue("@UserID", dm.UserID);
                }
                else
                {
                    command.CommandText = "PR_DOCDEPT_Add";
                    command.Parameters.AddWithValue("@DoctorID", dm.DoctorID);
                    command.Parameters.AddWithValue("@DepartmentID", dm.DepartmentID);
                    command.Parameters.AddWithValue("@UserID", dm.UserID);
                }

                command.ExecuteNonQuery();
                return RedirectToAction("DocDeptList");
            }

            return View("DocDeptAddEdit", dm);
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

        public IActionResult DocDeptDelete(int DoctorDepartmentID)
        {
            string DbConnect = this._configuration.GetConnectionString("DbConnect");
            SqlConnection connection = new SqlConnection(DbConnect);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_DOCDEPT_Delete";
            command.Parameters.Add("@DoctorDepartmentID", SqlDbType.Int).Value = DoctorDepartmentID;
            command.ExecuteNonQuery();

            return RedirectToAction("DocDeptList");
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
