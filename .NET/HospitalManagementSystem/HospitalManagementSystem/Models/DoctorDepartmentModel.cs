using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class DoctorDepartmentModel
    {
        [Key]
        public int DoctorDepartmentID { get; set; }

        [Required]
        [ForeignKey("DoctorModel")]
        [Display(Name = "Doctor")]
        public int DoctorID { get; set; }

        [Required]
        [ForeignKey("DepartmentModel")]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        [Required]
        [ForeignKey("UserModel")]
        [Display(Name = "Created By User")]
        public int UserID { get; set; }
    }
}
