using DoctorAppointmentApp_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentApp_MVC.Controllers
{
    public class PatientController : Controller
    {
        AppointmentDBHelper repo = new AppointmentDBHelper();
        public IActionResult Index()
        {

            return View(repo.GetPatients());
        }


        public IActionResult GetPatient(int patientId)
        {
            return View(repo.GetPatientByID(patientId));
        }
    }
}
