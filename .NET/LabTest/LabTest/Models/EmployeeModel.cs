namespace LabTest.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public bool IsActive {get; set;}
    }
}
