﻿using Challenge13Kiosco.Data;
using Challenge13Kiosco.Interfaces;
using Challenge13Kiosco.Models;
using Challenge13Kiosco.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge13Kiosco.Controllers
{
    public class HomeController : Controller
    {

        //private readonly ILogger<HomeController> _logger;
        private readonly UnitOfWork _unitOfWork;
        public HomeController(KioscoContext context )
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public IActionResult Index()
        {
            
            
            
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