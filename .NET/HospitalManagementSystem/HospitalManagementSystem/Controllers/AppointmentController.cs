using ClosedXML.Excel;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HospitalManagementSystem.Controllers
{
    public class AppointmentController : Controller
    {
        private IConfiguration _configuration;

        public AppointmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public IActionResult AppointmentList()
        {
            string DbConnect = this._configuration.GetConnectionString("DbConnect");
            SqlConnection connection = new SqlConnection(DbConnect);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_APT_SelectAll";
            SqlDataReader reader = command.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            return View(table);
        }
        public IActionResult AppointmentDelete(int AppointmentID)
        {
            string DbConnect = this._configuration.GetConnectionString("DbConnect");
            SqlConnection connection = new SqlConnection(DbConnect);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_APT_Delete";

            command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = AppointmentID;

            command.ExecuteNonQuery();

            return RedirectToAction("AppointmentList");
        }
        [HttpGet]
        public IActionResult AppointmentAddEdit(int? AppointmentID)
        {
            AppointmentModel dm = new AppointmentModel();


            if (AppointmentID != null && AppointmentID > 0)
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("PR_APT_SelectByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = AppointmentID;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    dm.AppointmentID = Convert.ToInt32(reader["AppointmentID"]);
                    dm.DoctorID = Convert.ToInt32(reader["DoctorID"]);
                    dm.PatientID = Convert.ToInt32(reader["PatientID"]);
                    dm.AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                    dm.AppointmentStatus = reader["AppointmentStatus"].ToString();
                    dm.Description = reader["Description"].ToString();
                    dm.SpecialRemarks = reader["SpecialRemarks"].ToString();

                    // Safely read UserID in case the SP returns a conflicting column type/name
                    object userIdValue = reader["UserID"];
                    if (userIdValue != DBNull.Value && userIdValue is int)
                    {
                        dm.UserID = (int)userIdValue;
                    }
                    else
                    {
                        // Try alternative alias if the SP uses one (e.g., AppointmentUserID)
                        try
                        {
                            int ordinal = reader.GetOrdinal("AppointmentUserID");
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

            return View("AppointmentAddEdit", dm);
        }

        [HttpPost]
        public IActionResult AppointmentAddEdit(AppointmentModel dm)
        {
            if (ModelState.IsValid)
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;

                // Decide between update vs insert based on primary key
                if (dm.AppointmentID > 0)
                {
                    command.CommandText = "PR_APT_Update";
                    command.Parameters.AddWithValue("@AppointmentID", dm.AppointmentID);
                    command.Parameters.AddWithValue("@DoctorID", dm.DoctorID);
                    command.Parameters.AddWithValue("@PatientID", dm.PatientID);
                    command.Parameters.AddWithValue("@AppointmentDate", dm.AppointmentDate);
                    command.Parameters.AddWithValue("@AppointmentStatus", dm.AppointmentStatus);
                    command.Parameters.AddWithValue("@Description", dm.Description);
                    command.Parameters.AddWithValue("@SpecialRemarks", dm.SpecialRemarks);
                    command.Parameters.AddWithValue("@UserID", dm.UserID);
                }
                else
                {
                    command.CommandText = "PR_APT_Add";
                    command.Parameters.AddWithValue("@DoctorID", dm.DoctorID);
                    command.Parameters.AddWithValue("@PatientID", dm.PatientID);
                    command.Parameters.AddWithValue("@AppointmentDate", dm.AppointmentDate);
                    command.Parameters.AddWithValue("@AppointmentStatus", dm.AppointmentStatus);
                    command.Parameters.AddWithValue("@Description", dm.Description);
                    command.Parameters.AddWithValue("@SpecialRemarks", dm.SpecialRemarks);
                    command.Parameters.AddWithValue("@UserID", dm.UserID);
                }


                command.ExecuteNonQuery();

                return RedirectToAction("AppointmentList");
            }

            return View("AppointmentAddEdit", dm);
        }

        public IActionResult ExportToExcel()
        {
            string connectionString = _configuration.GetConnectionString("DbConnect");

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("PR_APT_SelectAll", connection))
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
