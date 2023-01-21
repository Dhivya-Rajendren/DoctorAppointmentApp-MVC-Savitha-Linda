using DoctorAppointmentApp_MVC.Models;

namespace DoctorAppointmentApp_MVC.ViewModels
{
    public class PatientDoctorViewModel
    {
        public List<string> Patients { get; set; }

        public List<string> Doctors { get; set; }

        public Appointment Appointment { get; set; }

        public List<int> PatientIds { get; set; }

        public List<int> DoctorIds { get; set; }
    }
}
