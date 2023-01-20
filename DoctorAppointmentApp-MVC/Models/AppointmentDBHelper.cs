using System.Data.SqlClient;//provider

namespace DoctorAppointmentApp_MVC.Models
{
    public class AppointmentDBHelper : IAppointmentRepository
    {

        SqlConnection con;
        SqlCommand com;
    //    SqlDataReader reader;

        string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DoctorAppointmentDB;Integrated Security=True;";

        public void AddNewPatient(Patient patient)
        {
            con = new SqlConnection(conString);

            con.Open();
            //DML - insert , update and delete
            string cmdText = "insert into tbl_patients values('" + patient.PatientName + "','" + patient.Email + "'," + patient.Contact + ",'" + patient.PatientHistory + "',' ')";
            com = new SqlCommand(cmdText,con);
            com.ExecuteNonQuery();// automatically committed.
            con.Close();
        }

        public void DeletePatient(int patientId)
        {
            con = new SqlConnection(conString);

            con.Open();
            //DML - insert , update and delete
            string cmdText = "Delete From tbl_patients where patientId="+patientId;
            com = new SqlCommand(cmdText, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public List<Appointment> GetAllApointments()
        {
            con = new SqlConnection(conString);
            con.Open();
            com = new SqlCommand("Select * from tbl_appointments", con);
          SqlDataReader  reader = com.ExecuteReader();//Reading the data from the com object.
            List<Appointment> appointments = new List<Appointment>();
            while(reader.Read())
            {
                Appointment appointment = new Appointment();
                appointment.AppointmentId = reader.GetInt32(0);
                appointment.PatientId = reader.GetInt32(1);
                appointment.DoctorId = reader.GetInt32(2);
                appointment._Patient = GetPatients().Find(p => p.PatientId == reader.GetInt32(1));
                appointment._Doctor = GetDoctors().Find(d => d.DoctorId == reader.GetInt32(2));
                appointment.ReasonForAppointment = reader.GetString(3);
                appointment.AppointmentDateTime = reader.GetString(4);
                appointments.Add(appointment);
            }
            reader.Close();
            con.Close();
            return appointments;

        }

        public Doctor GetDoctorByID(int doctorId)
        {
            Doctor doctor = GetDoctors().Find(d => d.DoctorId == doctorId);
            return doctor;
        }

        public List<Doctor> GetDoctors()
        {
            con = new SqlConnection(conString);
            con.Open();
            com = new SqlCommand("Select * from tbl_doctors", con);
           SqlDataReader reader = com.ExecuteReader();//Reading the data from the com object.
            List<Doctor> doctors = new List<Doctor>();
            while (reader.Read())
            {
                Doctor  doctor = new Doctor();
                doctor.DoctorId = reader.GetInt32(0);
                doctor.DoctorName = reader.GetString(1);
                doctor.Email = reader.GetString(2);
                doctor.Contact = reader.GetInt64(3);
                doctor.Specialization = reader.GetString(4);
                doctor.DoctorImg = reader.GetString(5);
                doctors.Add(doctor);
            }
            reader.Close();
            con.Close();
            return doctors;
        }
    

        public Patient GetPatientByID(int patientID)
        {
            Patient patient = GetPatients().Find(p => p.PatientId == patientID);
            return patient;
           
        }

        public List<Patient> GetPatients()
        {
            con = new SqlConnection(conString);
            con.Open();
            com = new SqlCommand("Select * from tbl_patients", con);
         SqlDataReader   reader = com.ExecuteReader();//Reading the data from the com object.
            List<Patient> patients = new List<Patient>();
            while (reader.Read())
            {
                Patient patient = new Patient();
                patient.PatientId = reader.GetInt32(0);
                patient.PatientName = reader.GetString(1);
                patient.Email = reader.GetString(2);
                patient.Contact = reader.GetInt64(3);
                patient.PatientHistory = reader.GetString(4);
                patient.PatientImg = reader.GetString(5);
                patients.Add(patient);
            }
            reader.Close();
            con.Close();
            return patients;
           }

        public void NewAppointment(Appointment appointment)
        {
            con = new SqlConnection(conString);

            con.Open();
            //DML - insert , update and delete
            string cmdText = "insert into tbl_appointments values(" + appointment.PatientId + "," + appointment.DoctorId + ",'" + appointment.ReasonForAppointment + "'," + appointment.AppointmentDateTime + ")"; ;
            com = new SqlCommand(cmdText, con);
            com.ExecuteNonQuery();// automatically committed.
            con.Close();
        }

        public void UpdatePatient(int patientId, string patientHistory)
        {
            con = new SqlConnection(conString);

            con.Open();
            //DML - insert , update and delete
            string cmdText = "update tbl_patients set patientHistory='"+patientHistory+"'  where patientId=" + patientId;
            com = new SqlCommand(cmdText, con);
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
