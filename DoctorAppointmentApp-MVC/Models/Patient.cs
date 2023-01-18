namespace DoctorAppointmentApp_MVC.Models
{
    public class Patient
    {

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public long Contact { get; set; }

        public string Email { get; set; }

        public string PatientHistory { get; set; }

        public string PatientImg { get; set; }
    }
}
