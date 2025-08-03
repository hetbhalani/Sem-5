using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HospitalManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        private IConfiguration _configuration;

        public PatientController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult PatientAddEdit(int? PatientID)
        {
            PatientModel pm = new PatientModel();

            if (PatientID != null && PatientID > 0)
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("PR_PAT_SelectByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PatientID", SqlDbType.Int).Value = PatientID;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    pm.PatientID = Convert.ToInt32(reader["PatientID"]);
                    pm.Name = reader["Name"].ToString();
                    pm.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    pm.Gender = reader["Gender"].ToString();
                    pm.Email = reader["Email"].ToString();
                    pm.Phone = reader["Phone"].ToString();
                    pm.Address = reader["Address"].ToString();
                    pm.City = reader["City"].ToString();
                    pm.State = reader["State"].ToString();
                    pm.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    pm.UserID = Convert.ToInt32(reader["UserID"]);
                }
            }

            return View("PatientAddEdit", pm);
        }

        [HttpPost]
        public IActionResult PatientAddEdit(PatientModel pm)
        {
            if (ModelState.IsValid)
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;

                if (pm.PatientID > 0)
                {
                    command.CommandText = "PR_PAT_Update";
                    command.Parameters.AddWithValue("@PatientID", pm.PatientID);
                    command.Parameters.AddWithValue("@Name", pm.Name);
                    command.Parameters.AddWithValue("@DateOfBirth", pm.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", pm.Gender);
                    command.Parameters.AddWithValue("@Email", pm.Email);
                    command.Parameters.AddWithValue("@Phone", pm.Phone);
                    command.Parameters.AddWithValue("@Address", pm.Address);
                    command.Parameters.AddWithValue("@City", pm.City);
                    command.Parameters.AddWithValue("@State", pm.State);
                    command.Parameters.AddWithValue("@IsActive", pm.IsActive);
                    command.Parameters.AddWithValue("@UserID", pm.UserID);
                }
                else
                {
                    command.CommandText = "PR_PAT_Add";
                    command.Parameters.AddWithValue("@Name", pm.Name);
                    command.Parameters.AddWithValue("@DateOfBirth", pm.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", pm.Gender);
                    command.Parameters.AddWithValue("@Email", pm.Email);
                    command.Parameters.AddWithValue("@Phone", pm.Phone);
                    command.Parameters.AddWithValue("@Address", pm.Address);
                    command.Parameters.AddWithValue("@City", pm.City);
                    command.Parameters.AddWithValue("@State", pm.State);
                    command.Parameters.AddWithValue("@IsActive", pm.IsActive);
                    command.Parameters.AddWithValue("@UserID", pm.UserID);
                }

                command.ExecuteNonQuery();

                return RedirectToAction("PatientList");
            }

            return View("PatientAddEdit", pm);
        }

        public IActionResult PatientDelete(int PatientID)
        {
            string DbConnect = this._configuration.GetConnectionString("DbConnect");
            SqlConnection connection = new SqlConnection(DbConnect);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_PAT_Delete";

            command.Parameters.Add("@PatientID", SqlDbType.Int).Value = PatientID;
            command.ExecuteNonQuery();

            return RedirectToAction("PatientList");
        }

        public IActionResult PatientList()
        {
            string DbConnect = this._configuration.GetConnectionString("DbConnect");
            SqlConnection connection = new SqlConnection(DbConnect);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_PAT_SelectAll";
            SqlDataReader reader = command.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            return View(table);
        }
    }
}
