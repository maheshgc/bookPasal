using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookPasal.Data;
using BookPasal.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookPasal.Controllers
{
    public class BikeController : Controller
    {
        private BikePasalDbContext db;

        public BikeController(BikePasalDbContext _db)
        {
            db = _db;
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create([FromForm] Bike bike)
        {
            if (ModelState.IsValid)   // it will check whether our form is valid or not
            {
                db.Bikes.Add(bike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bike); 
        }

         public IActionResult Index()
        {
            // select * from bikes 
            List<Bike> bikes = db.Bikes.ToList();  // ORM EF Core
            return View(bikes);
        }
         
        public IActionResult Details(int id)
        {
            Bike bike = db.Bikes.Find(id);
            return View(bike);
        }

        public IActionResult Edit(int id)
        {
            Bike bike = db.Bikes.Find(id);
            return View(bike);
        }

        [HttpPost]
        public IActionResult Edit(Bike bike)
        {
            if (ModelState.IsValid)
            {
                db.Bikes.Update(bike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bike);
        }
    }
}
