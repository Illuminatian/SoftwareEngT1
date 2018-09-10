using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftwareEngT1.Models;

namespace SoftwareEngT1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ScheduleContext _context;

        public HomeController(ScheduleContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Scheduler()
        {
            ViewData["Message"] = "The Scheduler Page";
            var model = new List<Schedule>();

            using(var db = _context)
            {
                foreach(var schedule in db.Schedules)
                {
                    var toAdd = new Schedule();
                    toAdd.AppointmentTime = schedule.AppointmentTime;
                    toAdd.AppointmentDate = schedule.AppointmentDate;

                    toAdd.AppointmentType = schedule.AppointmentType;
                    toAdd.FirstName = schedule.FirstName;
                    toAdd.LastName = schedule.LastName;
                    toAdd.PhoneNumber = schedule.PhoneNumber;
                    toAdd.EmailAddress = schedule.EmailAddress;

                    model.Add(toAdd);
                }
            }

            return View(model);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
