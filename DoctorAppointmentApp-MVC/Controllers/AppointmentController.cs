using DoctorAppointmentApp_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using DoctorAppointmentApp_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctorAppointmentApp_MVC.Controllers
{
    public class AppointmentController : Controller
    {

        AppointmentDBHelper repo = new AppointmentDBHelper();
        public IActionResult Index()
        {
            return View(repo.GetAllApointments());
        }


        public IActionResult MakeAppointment()
        {

            List<Patient> patients = repo.GetPatients();
            PatientDoctorViewModel viewModel = new PatientDoctorViewModel();
            viewModel.Patients = new List<string>();
            viewModel.PatientIds = new List<int>();
            foreach (var item in patients)
            {
                viewModel.Patients.Add(item.PatientName);
                viewModel.PatientIds.Add(item.PatientId);
            }
            List<Doctor> doctors = repo.GetDoctors();
            viewModel.Doctors = new List<string>();
            viewModel.DoctorIds = new List<int>();
            foreach (var item in doctors)
            {
                viewModel.Doctors.Add(item.DoctorName);
                viewModel.DoctorIds.Add(item.DoctorId);
            }

            List<SelectListItem> doctorItems = new List<SelectListItem>();

            //Drop down - Value - taking the id of the doctor and Text -displaying the name

            int i = 0;
          while(i<doctors.Count)
            {
                doctorItems.Add(new SelectListItem(viewModel.Doctors[i], viewModel.DoctorIds[i].ToString()));
                i++;
            }

            List<SelectListItem> patientItems = new List<SelectListItem>();
            i = 0;
            while(i<patients.Count)
            {
                patientItems.Add(new SelectListItem(viewModel.Patients[i], viewModel.PatientIds[i].ToString()));
                i++;
            }

            ViewBag.DDLDoctors = doctorItems;
            ViewBag.DDLPatients = patientItems;
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult MakeAppointment(Appointment appointment)
        {
            repo.NewAppointment(appointment);
            return RedirectToAction("Index");
        }
    }
}
