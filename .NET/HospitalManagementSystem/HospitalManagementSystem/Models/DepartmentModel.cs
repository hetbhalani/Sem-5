using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class DepartmentModel
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [StringLength(100, ErrorMessage = "Department name can't exceed 100 characters")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [StringLength(250, ErrorMessage = "Description can't exceed 250 characters")]
        [Display(Name = "Description")]
        public string? Description { get; set; } 

        [Required]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        [Required]
        [ForeignKey("UserModel")]
        [Display(Name = "Created By User")]
        public int UserID { get; set; }
    }
}
