using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class AppointmentModel
    {
        [Key]
        public int AppointmentID { get; set; }

        [Required]
        [ForeignKey("DoctorModel")]
        [Display(Name = "Doctor")]
        public int DoctorID { get; set; }

        [Required]
        [ForeignKey("PatientModel")]
        [Display(Name = "Patient")]
        public int PatientID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(20)]
        [Display(Name = "Status")]
        public string AppointmentStatus { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(250)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Remarks are required")]
        [StringLength(100)]
        [Display(Name = "Special Remarks")]
        public string SpecialRemarks { get; set; }

        [Required]
        [ForeignKey("UserModel")]
        [Display(Name = "Created By User")]
        public int UserID { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        [Display(Name = "Total Consulted Amount")]
        public decimal? TotalConsultedAmount { get; set; }
    }
}
