using ClosedXML.Excel;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HospitalManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult UserList()
        {
            string DbConnect = this._configuration.GetConnectionString("DbConnect");
            SqlConnection connection = new SqlConnection(DbConnect);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_USR_SelectAll";

            SqlDataReader reader = command.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            return View(table);
        }

        public IActionResult UserDelete(int UserID)
        {
            string DbConnect = this._configuration.GetConnectionString("DbConnect");
            SqlConnection connection = new SqlConnection(DbConnect);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_USR_DeleteUser";

            command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;

            command.ExecuteNonQuery();

            return RedirectToAction("UserList");
        }

        [HttpGet]
        public IActionResult UserAddEdit(int? UserId)
        {
            UserModel um = new UserModel();

            if (UserId != null && UserId > 0)
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("PR_USR_SelectByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserId;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    um.UserID = Convert.ToInt32(reader["UserID"]);
                    um.UserName = reader["UserName"].ToString();
                    um.Password = reader["Password"].ToString();
                    um.Email = reader["Email"].ToString();
                    um.MobileNo = reader["MobileNo"].ToString();
                    um.IsActive = Convert.ToBoolean(reader["IsActive"]);
                }
            }

            return View("UserAddEdit", um);
        }

        [HttpPost]
        public IActionResult UserAddEdit(UserModel um)
        {
            if (ModelState.IsValid)
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;

                if (um.UserID > 0)
                {
                    command.CommandText = "PR_USR_UpdateUser";
                    command.Parameters.AddWithValue("@UserID", um.UserID);
                    command.Parameters.AddWithValue("@UserName", um.UserName);
                    command.Parameters.AddWithValue("@Password", um.Password);
                    command.Parameters.AddWithValue("@Email", um.Email);
                    command.Parameters.AddWithValue("@MobileNo", um.MobileNo);
                    command.Parameters.AddWithValue("@IsActive", um.IsActive);
                    command.Parameters.AddWithValue("@Modified", DateTime.Now);
                }
                else
                {
                    command.CommandText = "PR_USR_AddUser";
                    command.Parameters.AddWithValue("@UserName", um.UserName);
                    command.Parameters.AddWithValue("@Password", um.Password);
                    command.Parameters.AddWithValue("@Email", um.Email);
                    command.Parameters.AddWithValue("@MobileNo", um.MobileNo);
                    command.Parameters.AddWithValue("@IsActive", um.IsActive);
                    command.Parameters.AddWithValue("@Modified", DateTime.Now);
                }
                command.ExecuteNonQuery();
                return RedirectToAction("UserList");
            }
            return View("UserAddEdit", um);
        }
        public IActionResult ExportToExcel()
        {
            string connectionString = _configuration.GetConnectionString("DbConnect");

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("PR_USR_SelectAll", connection))
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
