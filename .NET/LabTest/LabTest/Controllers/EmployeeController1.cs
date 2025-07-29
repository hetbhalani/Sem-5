using LabTest.Models;
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
        [HttpGet]
        public IActionResult EmployeeAddEdit(int? EmployeeID)
        {
            EmployeeModel em = new EmployeeModel();

            if (EmployeeID != null && EmployeeID > 0)
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("PR_EMP_SelectByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    em.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                    em.FirstName = reader["FirstName"].ToString();
                    em.LastName = reader["LastName"].ToString();
                    em.Email = reader["Email"].ToString();
                    em.PhoneNumber = reader["PhoneNumber"].ToString();
                    em.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    em.Gender = reader["Gender"].ToString();
                    em.HireDate = Convert.ToDateTime(reader["HireDate"]);
                    em.JobTitle = reader["JobTitle"].ToString();
                    em.Department = reader["Department"].ToString();
                    em.Salary = Convert.ToInt32(reader["Salary"]);
                    em.IsActive = Convert.ToBoolean(reader["IsActive"]);
                }
            }

            return View("EmployeeAddEdit", em);
        }

        [HttpPost]
        public IActionResult EmployeeAddEdit(EmployeeModel em)
        {
            if (ModelState.IsValid)
            {
                string connectionString = _configuration.GetConnectionString("DbConnect");
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;

                if (em.EmployeeID > 0)
                {
                    // UPDATE operation
                    command.CommandText = "PR_EMP_UpdateEmployee";
                    command.Parameters.AddWithValue("@EmployeeID", em.EmployeeID);
                    command.Parameters.AddWithValue("@FirstName", em.FirstName);
                    command.Parameters.AddWithValue("@LastName", em.LastName);
                    command.Parameters.AddWithValue("@Email", em.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", em.PhoneNumber);
                    command.Parameters.AddWithValue("@DateOfBirth", em.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", em.Gender);
                    command.Parameters.AddWithValue("@HireDate", em.HireDate);
                    command.Parameters.AddWithValue("@JobTitle", em.JobTitle);
                    command.Parameters.AddWithValue("@Department", em.Department);
                    command.Parameters.AddWithValue("@Salary", em.Salary);
                    command.Parameters.AddWithValue("@IsActive", em.IsActive);
                    command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                }
                else
                {
                    // INSERT operation
                    command.CommandText = "PR_EMP_AddEmployee";
                    command.Parameters.AddWithValue("@FirstName", em.FirstName);
                    command.Parameters.AddWithValue("@LastName", em.LastName);
                    command.Parameters.AddWithValue("@Email", em.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", em.PhoneNumber);
                    command.Parameters.AddWithValue("@DateOfBirth", em.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", em.Gender);
                    command.Parameters.AddWithValue("@HireDate", em.HireDate);
                    command.Parameters.AddWithValue("@JobTitle", em.JobTitle);
                    command.Parameters.AddWithValue("@Department", em.Department);
                    command.Parameters.AddWithValue("@Salary", em.Salary);
                    command.Parameters.AddWithValue("@IsActive", em.IsActive);
                }

                command.ExecuteNonQuery();
                return RedirectToAction("SelectAllEmployee");
            }

            return View("EmployeeAddEdit", em);
        }
    }
}
