using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using spice.Data;
using spice.Models;
using spice.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoriesController : Controller
    {
        string yes = string.Empty;
        private readonly ApplicationDbContext db;

        public SubCategoriesController(ApplicationDbContext db)
        {
            this.db = db;
        }

        // GET: SubCategoriesController
        public ActionResult Index()
        {
            return View(db.SubCategories.Include(x=>x.Category).ToList());
        }

        // GET: SubCategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var mhmdibrahem = db.SubCategories.Include(m => m.Category).SingleOrDefault(x=>x.Id==id);
            if (mhmdibrahem == null)
                return NotFound();

            return View(mhmdibrahem);
        }

        // GET: SubCategoriesController/Create
        public ActionResult Create()
        {
            subandcatViewModel model = new subandcatViewModel()
            {
                CategoriesList = db.Categories.ToList(),
                SubCategory = new Models.SubCategory(),
                


            };  
            return View(model);
        }

        // POST: SubCategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(subandcatViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    

                    var sub2 = new SubCategory();

                   var sub = db.SubCategories.FirstOrDefault(x => x.Name == model.SubCategory.Name);
                    if (sub != null)
                    {
                        ViewBag.exist = "error , record is found";
                        subandcatViewModel modelvm = new subandcatViewModel()
                        {
                            CategoriesList = db.Categories.ToList(),
                            SubCategory = model.SubCategory                            
                        };
                        return View(modelvm);
                    }
                    else
                    {
                        sub2.Name = model.SubCategory.Name;
                        sub2.CategoryId = model.SubCategory.CategoryId;
                        db.SubCategories.Add(sub2);
                        db.SaveChanges();

                        return RedirectToAction(nameof(Index));
                    }
                }
                else {
                    subandcatViewModel modelvm = new subandcatViewModel()
                    {
                        CategoriesList = db.Categories.ToList(),
                        SubCategory = model.SubCategory,
                      
                        statusMsg=yes
                    };
                    return View(modelvm);
                }
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: SubCategoriesController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            { return NotFound(); }
            
            
            var x = db.SubCategories.Find(id);
            if(x == null)
            { return NotFound(); }

            subandcatViewModel model = new subandcatViewModel()
            {
                CategoriesList = db.Categories.ToList(),
                SubCategory =x
            };
            return View(model);
            
        }

        // POST: SubCategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, subandcatViewModel model)
        {
            
            
            try
            {
                if (ModelState.IsValid)
                {
                    var subcat = new SubCategory();
                    subcat = model.SubCategory;
                    db.SubCategories.Update(subcat);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Field Required");
                    subandcatViewModel modell = new subandcatViewModel()
                    {
                        CategoriesList = db.Categories.ToList(),
                    };
                    return View(modell);
                }
                  
            }
            catch
            {
                return View();
            }
        }

        // GET: SubCategoriesController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            { return NotFound(); }


            var x = db.SubCategories.Include(m=>m.Category).SingleOrDefault(m=>m.Id==id);
            if (x == null)
            { return NotFound(); }
            return View(x);
        }

        // POST: SubCategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SubCategory subcategory)
        {
          db.SubCategories.Remove(subcategory);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult getsubcategories(int id)
        {
            List<SubCategory> sublist = new List<SubCategory>();
            sublist = db.SubCategories.Where(x => x.CategoryId == id).ToList();
            return Json(new SelectList(sublist,"Id", "Name"));
        }
    }
}
