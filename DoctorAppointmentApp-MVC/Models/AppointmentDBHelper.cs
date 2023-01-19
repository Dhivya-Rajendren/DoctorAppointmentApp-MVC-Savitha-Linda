using System.Data.SqlClient;//provider

namespace DoctorAppointmentApp_MVC.Models
{
    public class AppointmentDBHelper : IAppointmentRepository
    {

        SqlConnection con;
        SqlCommand com;
        SqlDataReader reader;

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
            reader = com.ExecuteReader();//Reading the data from the com object.
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
    }
}
