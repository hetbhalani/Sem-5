using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class UserModel
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        [StringLength(50, MinimumLength=2, ErrorMessage ="name must be 2 to 50 chars long")]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [StringLength(100,MinimumLength =8,ErrorMessage ="Password must be 8 chars long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Not in mail formate")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Phone number is required")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10,ErrorMessage ="not a valid phone number")]
        public string MobileNo { get; set; }

        
        public bool IsActive  { get; set; }
 
    }

}