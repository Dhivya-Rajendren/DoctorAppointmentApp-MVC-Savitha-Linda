using DoctorAppointmentApp_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentApp_MVC.Controllers
{
    public class DoctorController : Controller
    {
        List<Doctor> doctors = new List<Doctor>();
        public DoctorController()
        {
          doctors  = new List<Doctor>();
            Doctor doctor = new Doctor();
            doctor.DoctorId = 1;
            doctor.DoctorName = "Dr.Reddy";
            doctor.Email = "reddy_cardio@gmail.com";
            doctor.Specialization = "Cardio";
            doctor.Contact = 7845128956;
            doctor.DoctorImg = "/images/DoctorM1.png";
            doctors.Add(doctor);

            doctor = new Doctor();
            doctor.DoctorId = 2;
            doctor.DoctorName = "Dr.Priya";
            doctor.Email = "Priya_GY@gmail.com";
            doctor.Specialization = "GY";
            doctor.Contact = 7845328956;
            doctor.DoctorImg = "/images/DoctorF.png";

            doctors.Add(doctor);
        }
        //Action method
        public IActionResult Index()
        {
            return View(doctors);// List of objects.
        }

        public IActionResult GetDoctor(int doctorId)
        {
            Doctor doctor = doctors.Find(d=>d.DoctorId==doctorId);
             return View(doctor);

        }
      
    }
}
