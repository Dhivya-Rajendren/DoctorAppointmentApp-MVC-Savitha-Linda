namespace DoctorAppointmentApp_MVC.Models
{
    public interface IAppointmentRepository
    {
        ///CRUD
        ///
        List<Patient> GetPatients();

        Patient GetPatientByID(int patientID);
    }
}
