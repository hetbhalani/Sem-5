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

            if(UserId != null && UserId > 0)
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

            return View("UserAddEdit",um);
        }

        [HttpPost]
        public IActionResult UserAddEdit(UserModel um)
        {
            if (ModelState.IsValid)
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure
                };

                if (um.UserID > 0)
                {
                    // Edit case — use update SP
                    command.CommandText = "PR_USR_UpdateUser";
                    command.Parameters.AddWithValue("@UserID", um.UserID);
                }
                else
                {
                    // Add case — use insert SP
                    command.CommandText = "PR_USR_AddUser";
                    command.Parameters.AddWithValue("@Created", DateTime.Now); // Only needed for insert
                    command.Parameters.AddWithValue("@Modified", DateTime.Now); // Needed here
                }

                // Common Parameters
                command.Parameters.AddWithValue("@UserName", um.UserName);
                command.Parameters.AddWithValue("@Password", um.Password);
                command.Parameters.AddWithValue("@Email", um.Email);
                command.Parameters.AddWithValue("@MobileNo", um.MobileNo);
                command.Parameters.AddWithValue("@IsActive", um.IsActive);

                if (um.UserID == 0)
                {
                    command.Parameters.AddWithValue("@Modified", DateTime.Now); // Only add if inserting
                }

            }

            return View("UserAddEdit", um);
        }


    }
}
