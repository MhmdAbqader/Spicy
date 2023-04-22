using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spice.Data;
using spice.Models;
using spice.Models.ViewModel;

namespace spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuItemsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment hosting;

        public MenuItemsController(ApplicationDbContext db, IWebHostEnvironment hosting)
        {
            this.db = db;
            this.hosting = hosting;
        }
        public IActionResult Index()
        {
            return View(db.MenuItems.Include(x=>x.Category).Include(x=>x.SubCategory).ToList());
        }
        public IActionResult Create()
        { 
            MenuItemViewModel menuvm = new MenuItemViewModel() { 
            menuItem=new MenuItem(),
            categoriesList=db.Categories.ToList(),
           // subCategoriesList=db.SubCategories.ToList()
            };
            return View(menuvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MenuItemViewModel model) {
            if (ModelState.IsValid) {

                //default img
                string filename = "355585.png";
                if (model.File != null)
                {

                    string upload = Path.Combine(hosting.WebRootPath, "Images");
                    filename = model.File.FileName;
                    string FullPath = Path.Combine(upload, filename);
                    model.File.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var menuitem = new MenuItem { 
                Name=model.menuItem.Name,
                Price=model.menuItem.Price,     
                Spicyness=model.menuItem.Spicyness, 
                Description=model.menuItem.Description,
                Image=filename,
                CategoryId=model.menuItem.CategoryId,
                SubcategoryId=model.menuItem.SubcategoryId,
                };
                db.MenuItems.Add(menuitem);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
        //------------------------------------------------------------

        [HttpGet]
        public IActionResult Edit(int id) {
            var menuvm = db.MenuItems.FirstOrDefault(x => x.Id == id);
            var vm = new MenuItemViewModel {
                menuItem = menuvm,
                categoriesList = db.Categories.ToList(),
              subCategoriesList=db.SubCategories.Where(x=>x.CategoryId==menuvm.CategoryId).ToList(),
            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MenuItemViewModel model) {
            var menuItem = db.MenuItems.Find(id);

            if (ModelState.IsValid)
            {

                //  string filename =DateTime.Now.ToFileTime().ToString() +Path.GetExtension( model.menuItem.Image);
                string filename = model.menuItem.Image;
                if (model.File != null)
                {
                    // الصورة القديمة كدا هتقعد على السيرفر ومش هتتمسح خالص..لازم تضيف خطوة خالد السعداني علشان تتمسح
                    string upload = Path.Combine(hosting.WebRootPath, "Images");
                    filename = model.File.FileName;
                    string FullPath = Path.Combine(upload, filename);
                    model.File.CopyTo(new FileStream(FullPath, FileMode.Create));
                }



                menuItem.Name = model.menuItem.Name;
                menuItem.Price = model.menuItem.Price;
                menuItem.Spicyness = model.menuItem.Spicyness;
                menuItem.Description = model.menuItem.Description;
                menuItem.Image = filename;
                menuItem.CategoryId = model.menuItem.CategoryId;
                menuItem.SubcategoryId = model.menuItem.SubcategoryId;
                
                db.SaveChanges();

            }
            else
            {
                ModelState.AddModelError("", "Must fill all Fields");
                var vm = new MenuItemViewModel
                {
                    menuItem = menuItem,
                    categoriesList = db.Categories.ToList(),
                    subCategoriesList = db.SubCategories.Where(x => x.CategoryId == menuItem.CategoryId).ToList(),
                };

                return View(vm);
            }

            return RedirectToAction(nameof(Index));
        }


        //------------------------------------------------------------
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound($"No result with id = {id}");

            var menuitem = db.MenuItems.Include(x => x.Category).Include(x => x.SubCategory).SingleOrDefault(x=>x.Id==id);
            if (menuitem == null)
                return BadRequest();

        return View(menuitem);
        }


        //------------------------------------------------------------
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound($"No result with id = Empty");

            var menuitem = db.MenuItems.Include(x => x.Category).Include(x => x.SubCategory).SingleOrDefault(x => x.Id == id);
            if (menuitem == null)
                return BadRequest();

            return View(menuitem);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            var m = db.MenuItems.SingleOrDefault(x=>x.Id==id);
            db.MenuItems.Remove(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete(MenuItem m)
        //{
        //    db.MenuItems.Remove(m);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
