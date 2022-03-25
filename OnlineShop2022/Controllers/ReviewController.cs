using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop2022.Data;
using OnlineShop2022.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop2022.Controllers
{
    [Authorize(Roles = "Customer")]
    public class ReviewController : Controller
    {
        private readonly AppDbContext _db;
        
        public ReviewController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Create(string data)
        {
            ViewBag.product = data;
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> Create(ReviewModel r, int id)
        {


            if (ModelState.IsValid)
            {
                
                await _db.Reviews.AddAsync(r);
                await _db.SaveChangesAsync();


                return Redirect("../Home/productdetail/" + r.ProductId); //Redirect?
            }
            else
            {
                return NotFound();
            }
        }
    }
}
