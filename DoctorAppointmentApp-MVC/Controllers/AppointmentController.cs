using DoctorAppointmentApp_MVC.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        [HttpPost]
        public IActionResult MakeAppointment(Appointment appointment)
        {
            repo.NewAppointment(appointment);
            return RedirectToAction("Index");
        }
    }
}
