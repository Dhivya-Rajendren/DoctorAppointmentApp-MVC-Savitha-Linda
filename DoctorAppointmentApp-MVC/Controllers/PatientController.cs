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



        [HttpGet]
        public IActionResult UpdatePatient(int patientId)
        {
            return View(repo.GetPatientByID(patientId));
        }

        [HttpPost]
        public IActionResult UpdatePatient(Patient patient)
        {
            repo.UpdatePatient(patient.PatientId,patient.PatientHistory);
            return RedirectToAction("Index");
        }


        public IActionResult GetPatient(int patientId)
        {
            return View(repo.GetPatientByID(patientId));
        }

        [HttpGet]
        public IActionResult AddNewPatient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewPatient(Patient patient)
        {
            repo.AddNewPatient(patient);
            return RedirectToAction("Index");
        }

        public IActionResult DeletePatient(int patientId)
        {
            repo.DeletePatient(patientId);
            return RedirectToAction("Index");
        }
    }
}
