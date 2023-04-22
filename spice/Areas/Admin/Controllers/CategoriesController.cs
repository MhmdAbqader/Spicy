using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spice.Data;
using spice.Models;

namespace spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext db;

        public CategoriesController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await db.Categories.ToListAsync();
            return View(categories);
        }
        [HttpGet]
        public     IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category) {

            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else {
              // ModelState.AddModelError("", " this field is required");
                return View(category);
            }

          
        }


        [HttpGet]
        public  IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var category= db.Categories.Find(id);
            if(category is null)
                return BadRequest();    

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Update(category);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            else {
                ModelState.AddModelError("", "complete the form");
                return View(category);
            }
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var category = db.Categories.Find(id);
            if (category is null)
                return BadRequest();

            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var category = db.Categories.Find(id);
            if (category is null)
                return BadRequest();

            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(Category category)
        {
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        //this my great Code 
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult ConfirmDelete(int? id)
        //{
        //    if (id == null)
        //        return NotFound();

        //    var category = db.Categories.Find(id);
        //    if (category is null)
        //        return BadRequest();

        //    else { 
        //        db.Categories.Remove(category);
        //        db.SaveChanges();
        //        }
        //    return RedirectToAction(nameof(Index));
            
        //}
    }
}
