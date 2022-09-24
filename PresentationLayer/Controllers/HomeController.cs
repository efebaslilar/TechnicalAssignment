﻿using BusinessLayer.Abstracts;
using EntityLayer.EntityModels;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Diagnostics;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productservice;

        public HomeController(ILogger<HomeController> logger, IProductService productservice)
        {
            _logger = logger;
            _productservice = productservice;
        }

        public IActionResult Index()
        {
           var product = _productservice.GetAll(x=> x.IsDeleted==false);
            return View(product);
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