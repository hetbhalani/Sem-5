namespace HospitalManagementSystem.Models
{
    public class DoctorModel
    {
        public int DoctorID {  get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Qualification { get; set; }

        public string Specialization { get; set; }

        public bool IsActive { get; set; }

        public int UserID { get; set; }

    }
}
