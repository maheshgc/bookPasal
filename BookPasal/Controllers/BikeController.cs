using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookPasal.Data;
using BookPasal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookPasal.Controllers
{    
    public class BikeController : Controller
    {
        private BikePasalDbContext db;
        private IWebHostEnvironment env;
        public BikeController(BikePasalDbContext _db,
            IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bike bike)
        {
            if (ModelState.IsValid)   // it will check whether our form is valid or not
            {
                if (bike.BikeImage != null)
                {
                    string rootPath = env.WebRootPath;                    // get the root directory i.e. /wwwroot/
                    string uniqueName = Guid.NewGuid().ToString();

                    string fileName = uniqueName + bike.BikeImage.FileName;      // file uploaded name
                    string uploadPath = rootPath + "/Images/" + fileName;       // creating upload path
                    bike.ImageName = fileName;                                 // assing file name to bike>imagename                                                                                    
                    using (var filestream = new FileStream(uploadPath, FileMode.Create))
                    {
                        await bike.BikeImage.CopyToAsync(filestream);
                    }
                }
                db.Add(bike);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bike); 
        }

         public async Task<IActionResult> Index()
        {
            // select * from bikes 
            List<Bike> bikes = await db.Bikes.ToListAsync();  // ORM EF Core
            return View(bikes);
        }
         
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await db.Bikes.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await db.Bikes.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }
            return View(bike);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Bike bike)
        {
            if (ModelState.IsValid)
            {
                db.Update(bike);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bike);
        }

        public IActionResult Delete(int id)
        {
            // where bikeid = id
            Bike bike = db.Bikes.Find(id);
            db.Bikes.Remove(bike);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}