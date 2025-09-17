using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SimpleForm.Models;
using System.Data;

namespace SimpleForm.Controllers
{
    public class StudentController : Controller
    {
        #region Config
        private readonly IConfiguration _configuration;
        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region List Students
        public IActionResult StudentList()
        {
            string connectionString = _configuration.GetConnectionString("DbConnect");
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand("PR_Student_SELECTALL", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);

            return View(table);
        }
        #endregion

        #region Edit Student
        [HttpGet]
        public IActionResult AddEditStudent(int? enrollmentNo)
        {
            StudentModel model = new StudentModel();

            if (enrollmentNo != null)  // Edit Mode
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                SqlCommand command = new SqlCommand("PR_STUDENT_SELECTBYID", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EnrollmentNo", enrollmentNo);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    model.Enrollment = Convert.ToInt32(reader["Enrollment"]);
                    model.Name = reader["Name"].ToString();
                    model.MobileNo = reader["MobileNo"].ToString();
                    model.Address = reader["Address"].ToString();
                    model.Email = reader["Email"].ToString();
                    model.Gender = reader["Gender"].ToString() == "Male";
                    model.PlayingCricket = Convert.ToBoolean(reader["PlayingCricket"]);
                    model.Password = reader["Password"].ToString();
                    model.ConfirmPassword = reader["ConfirmPassword"].ToString();
                    model.Percentage12th = Convert.ToSingle(reader["Percentage12th"]);
                    model.LiveinRajkot = Convert.ToBoolean(reader["LiveinRajkot"]);
                }
            }

            return View(model);
        }
        #endregion

        #region Add Student
        [HttpPost]
        public IActionResult AddEditStudent(StudentModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string connectionString = _configuration.GetConnectionString("DbConnect");
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand command;

            if (model.Enrollment == 0)
            {
                command = new SqlCommand("PR_Student_INSERT", sqlConnection);
            }
            else
            {
                command = new SqlCommand("PR_Student_UPDATE", sqlConnection);
                command.Parameters.AddWithValue("@EnrollmentNo", model.Enrollment);
            }

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", model.Name);
            command.Parameters.AddWithValue("@MobileNo", model.MobileNo);
            command.Parameters.AddWithValue("@Address", model.Address);
            command.Parameters.AddWithValue("@Email", model.Email);
            command.Parameters.AddWithValue("@Gender", model.Gender ? "Male" : "Female");
            command.Parameters.AddWithValue("@PlayingCricket", model.PlayingCricket);
            command.Parameters.AddWithValue("@Password", model.Password);
            command.Parameters.AddWithValue("@ConfirmPassword", model.ConfirmPassword);
            command.Parameters.AddWithValue("@Percentage12th", model.Percentage12th);
            command.Parameters.AddWithValue("@LiveInRajkot", model.LiveinRajkot);

            command.ExecuteNonQuery();

            return RedirectToAction("StudentList");
        }
        #endregion

        #region Delete Student
        public IActionResult DeleteStudent(int enrollmentNo)
        {
            string connectionString = _configuration.GetConnectionString("DbConnect");
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand("PR_Student_DELETE", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EnrollmentNo", enrollmentNo);
            command.ExecuteNonQuery();

            return RedirectToAction("StudentList");
        }
        #endregion
    }
}