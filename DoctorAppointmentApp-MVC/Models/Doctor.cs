namespace DoctorAppointmentApp_MVC.Models
{
    public class Doctor
    {

     
        public int DoctorId { get; set; }

        public string DoctorName { get; set; }

        public string Email { get; set; }

        public long Contact { get; set; }

        public string Specialization { get; set; }
        public string DoctorImg { get; set; }
    }
}
