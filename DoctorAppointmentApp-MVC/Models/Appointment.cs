namespace DoctorAppointmentApp_MVC.Models
{
    public class Appointment
    {

        public int AppointmentId { get; set; }
        public int PatientId { get; set; }

        public Patient _Patient { get; set; }// This property is going to connect the appointment class with Patient -Relation

        public int DoctorId { get; set; }

        public Doctor _Doctor { get; set; }// This property is going to connect the appointment class with Doctor -Relation

        public string ReasonForAppointment { get; set; }

        public string AppointmentDateTime { get; set; }
    }
}
