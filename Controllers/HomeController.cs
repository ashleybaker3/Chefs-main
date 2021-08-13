using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Chefs.Models;

namespace Chefs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static ChefsContext db;

        public HomeController(ILogger<HomeController> logger, ChefsContext context)
        {
            _logger = logger;
            db = context;
        }


        public IActionResult Index()
        {
            List<Chef> AllChefs = db.Chefs.Include(chef => chef.CreatedDishes).ToList();
            return View(AllChefs);
        }

        public IActionResult Dishes()
        {
            List<Dish> AllDishes = db.Dishes.Include(dish=> dish.Creator).ToList();
            return View("Dishes", AllDishes);
        }

        [HttpGet("addchef")]
        public IActionResult AddChef()
        {
            return View("AddChef");
        }

        [HttpPost("createchef")]
        public IActionResult CreateChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                if(newChef.DateOfBirth>DateTime.Today)
                {
                    ModelState.AddModelError("DateOfBirth", "Invalid Date of Birth");
                    return View("AddChef");
                }
                if(newChef.CalculateAge() < 18)
                {
                    ModelState.AddModelError("DateOfBirth","Must be at least 18 years old");
                    return View("AddChef");
                }
                db.Chefs.Add(newChef);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddChef");
        }

        [HttpGet("adddish")]
        public IActionResult AddDish()
        {
            List<Chef> AllChefs = db.Chefs.ToList();
            ViewBag.AllChefs = AllChefs;
            return View("AddDish");
        }

        [HttpPost("createdish")]
        public IActionResult CreateDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                db.Dishes.Add(newDish);
                db.SaveChanges();
                return RedirectToAction("Dishes");
            }
            List<Chef> AllChefs = db.Chefs.ToList();
            ViewBag.AllChefs = AllChefs;
            return View("AddDish");
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
