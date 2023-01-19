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
    }
}
