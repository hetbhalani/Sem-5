using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HospitalManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult DepartmentAddEdit(int? DepartmentID)
        {
            DepartmentModel dm = new DepartmentModel();

            // Load users for dropdown
            LoadUsers();

            if (DepartmentID != null && DepartmentID > 0)
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("PR_DEPT_SelectByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    dm.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                    dm.DepartmentName = reader["DepartmentName"].ToString();
                    dm.Description = reader["Description"].ToString();
                    dm.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    dm.UserID = Convert.ToInt32(reader["UserID"]);
                }
            }

            return View("DepartmentAddEdit", dm);
        }

        [HttpPost]
        public IActionResult DepartmentAddEdit(DepartmentModel dm)
        {
            if (ModelState.IsValid)
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;

                if (dm.DepartmentID > 0)
                {
                    command.CommandText = "PR_DEPT_UpdateDepartment";
                    command.Parameters.AddWithValue("@DepartmentID", dm.DepartmentID);
                    command.Parameters.AddWithValue("@DepartmentName", dm.DepartmentName);
                    command.Parameters.AddWithValue("@Description", dm.Description);
                    command.Parameters.AddWithValue("@IsActive", dm.IsActive);
                    command.Parameters.AddWithValue("@UserID", dm.UserID);
                }
                else
                {
                    command.CommandText = "PR_DEPT_AddDepartment";
                    command.Parameters.AddWithValue("@DepartmentName", dm.DepartmentName);
                    command.Parameters.AddWithValue("@Description", dm.Description);
                    command.Parameters.AddWithValue("@IsActive", dm.IsActive);
                    command.Parameters.AddWithValue("@UserID", dm.UserID);
                }

                command.ExecuteNonQuery();

                return RedirectToAction("DepartmentList");
            }

            LoadUsers(); // Reload users for dropdown if validation fails
            return View("DepartmentAddEdit", dm);
        }

        public IActionResult DepartmentList()
        {
            string DbConnect = this._configuration.GetConnectionString("DbConnect");
            SqlConnection connection = new SqlConnection(DbConnect);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_DEPT_SelectAll";

            SqlDataReader reader = command.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            return View(table);
        }

        public IActionResult DepartmentDelete(int DepartmentID){
            string DbConnect = this._configuration.GetConnectionString("DbConnect");
            SqlConnection connection = new SqlConnection(DbConnect);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_DEPT_DeleteDepartment";

            command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;

            command.ExecuteNonQuery();

            return RedirectToAction("DepartmentList");
        }

        private void LoadUsers()
        {
            string connectionString = _configuration.GetConnectionString("DbConnect");
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("PR_USR_SelectAll", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            List<UserModel> users = new List<UserModel>();

            while (reader.Read())
            {
                users.Add(new UserModel
                {
                    UserID = Convert.ToInt32(reader["UserID"]),
                    UserName = reader["UserName"].ToString()
                });
            }

            ViewBag.Users = users;
        }
    }
}
