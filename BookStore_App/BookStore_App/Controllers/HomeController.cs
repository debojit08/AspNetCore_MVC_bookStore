using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            /*ViewBag.title = "hello";*/
            return View();
        }

        public ViewResult aboutus()
        {
            return View();
        }
        public ViewResult contactus()
        {
            return View();
        }
    }
}
