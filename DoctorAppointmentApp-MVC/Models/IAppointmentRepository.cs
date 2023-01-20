namespace DoctorAppointmentApp_MVC.Models
{
    public interface IAppointmentRepository
    {
        ///CRUD
        ///
        List<Patient> GetPatients();

        Patient GetPatientByID(int patientID);

        void AddNewPatient(Patient patient);

        void DeletePatient(int patientId);

        void UpdatePatient(int patientId, string patientHistory);

        List<Doctor> GetDoctors();

        Doctor GetDoctorByID(int doctorId);

        List<Appointment> GetAllApointments();
        void NewAppointment(Appointment appointment);
    }
}
