﻿using Microsoft.AspNetCore.Mvc;

namespace Group5_MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}