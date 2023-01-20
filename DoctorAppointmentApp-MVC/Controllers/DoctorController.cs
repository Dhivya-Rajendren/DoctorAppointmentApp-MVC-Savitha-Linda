using DoctorAppointmentApp_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentApp_MVC.Controllers
{
    public class DoctorController : Controller
    {
        AppointmentDBHelper repo = new AppointmentDBHelper();
        //Action method
        public IActionResult Index()
        {
            return View(repo.GetDoctors());// List of objects.
        }

        public IActionResult GetDoctor(int doctorId)
        {
           
             return View(repo.GetDoctorByID(doctorId));

        }
      
    }
}
