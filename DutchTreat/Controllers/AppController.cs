using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            //throw new InvalidOperationException("Bad things happened");

            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            //throw new InvalidOperationException("ups");
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // send the email
            }
            else
            {
                // show the errors
            }
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            ViewBag.Title = "About Us";

            return View();
        }
    }
}
