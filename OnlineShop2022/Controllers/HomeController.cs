﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShop2022.Data;
using OnlineShop2022.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop2022.Controllers
{
    [Authorize(Roles = "Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }
       

        public async Task<IActionResult> Index()
        {
            var products = await _db.Products.ToListAsync();
        
            //only displays 3 most recent products on page
            return View(_db.Products.OrderByDescending(d => d.Id).Take(3));
            //return View(products);

           
        }


     
        public async Task<IActionResult> Products(string id)
        {
            var products = await _db.Products.ToListAsync();
            return View(products);
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




        public async Task<IActionResult> ProductDetail(int? id)
        {

            var productModel = await _db.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }
    }
}
