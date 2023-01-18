using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentApp_MVC.Controllers
{
    public class MedicineController : Controller
    {
        public IActionResult Index()
        {
            return View();//cshtml (CSharp +Html)
        }
    }
}
