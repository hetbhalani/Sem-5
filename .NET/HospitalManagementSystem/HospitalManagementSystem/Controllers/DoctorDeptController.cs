﻿using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HospitalManagementSystem.Controllers
{
    public class DoctorDeptController : Controller
    {
        private IConfiguration _configuration;

        public DoctorDeptController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult DocDeptAddEdit()
        {
            return View();
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
    }
}
