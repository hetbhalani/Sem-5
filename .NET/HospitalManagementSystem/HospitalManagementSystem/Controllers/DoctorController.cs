using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Hospital_Management_System.Controllers
{
    public class DoctorController : Controller
    {
        private IConfiguration _configuration;

        public DoctorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult DoctorList()
        {
            string DbConnect = this._configuration.GetConnectionString("DbConnect");
            SqlConnection connection = new SqlConnection(DbConnect);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_DOC_SelectAll";
            SqlDataReader reader = command.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            return View(table);
        }

        public IActionResult DoctorDelete(int DoctorId)
        {
            String DbConnect = this._configuration.GetConnectionString("DbConnect");
            SqlConnection connection = new SqlConnection(DbConnect);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_DOC_DeleteDoctor";

            command.Parameters.Add("@DoctorID",SqlDbType.Int).Value = DoctorId;
            command.ExecuteNonQuery();

            return RedirectToAction("DoctorList");
        }

        [HttpGet]
        public IActionResult DoctorAddEdit(int? DoctorID)
        {
            DoctorModel dm = new DoctorModel();


            if (DoctorID != null && DoctorID > 0)
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("PR_DOC_SelectByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = DoctorID;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    dm.DoctorID = Convert.ToInt32(reader["DoctorID"]);
                    dm.Name = reader["Name"].ToString();
                    dm.Phone = reader["Phone"].ToString();
                    dm.Email = reader["Email"].ToString();
                    dm.Qualification = reader["Qualification"].ToString();
                    dm.Specialization = reader["Specialization"].ToString();
                    dm.IsActive = Convert.ToBoolean(reader["IsActive"]);
                }
            }

            return View("DoctorAddEdit", dm);
        }

        [HttpPost]
        public IActionResult DoctorAddEdit(DoctorModel dm)
        {
            if (ModelState.IsValid)
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;

                if (dm.DoctorID > 0)
                {
                    command.CommandText = "PR_DOC_UpdateDoctor";
                    command.Parameters.AddWithValue("@DoctorID", dm.DoctorID);
                }
                else
                {
                    command.CommandText = "PR_DOC_AddDoctor";
                    command.Parameters.AddWithValue("@Name", dm.Name);
                    command.Parameters.AddWithValue("@Phone", dm.Phone);
                    command.Parameters.AddWithValue("@Email", dm.Email);
                    command.Parameters.AddWithValue("@Qualification", dm.Qualification);
                    command.Parameters.AddWithValue("@Specialization", dm.Specialization);
                    command.Parameters.AddWithValue("@IsActive", dm.IsActive);
                }

                if (dm.DoctorID == 0)
                {
                    command.Parameters.AddWithValue("@Modified", DateTime.Now);
                }

                command.ExecuteNonQuery();

                return RedirectToAction("DoctorList");
            }

            return View("DoctorAddEdit",dm);
        }

    }
}