using System.ComponentModel.DataAnnotations;

namespace SimpleForm.Models
{
    public class StudentModel
    {
        public int Enrollment { get; set; }

        public string Name { get; set; }

        public string MobileNo { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public bool Gender { get; set; }

        public bool PlayingCricket { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        public float Percentage12th { get; set; }

        public bool LiveinRajkot { get; set; }
    }
}