﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "hello";
        }
    }
}