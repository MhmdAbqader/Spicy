using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spice.Data;
using spice.Models;
using spice.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace spice.Areas.Customer.Controllers
{
    [Area("customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async  Task<IActionResult> Index()
        {
            //when_user_click_remember_me   so he doesn't need to login 

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var currentUser = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (currentUser != null)
            {
                List<ShoppingCart> shoppingCarts = await db.ShoppingCarts
                    .Where(x => x.ApplicationUserId == currentUser.Value).ToListAsync();
                HttpContext.Session.SetInt32("ShoppingCartCount", shoppingCarts.Count);
            }

            ViewData["date"] =DateTime.Now;
            List<string> names = new List<string> { "Mhmd", "abqader", "mhmd" };
            ViewData["names"]=names;

            IndexViewModel indexView = new IndexViewModel {
                 
                Category =await db.Categories.ToListAsync(),
                Coupons = await db.Coupons.Where(x => x.IsActive == true).ToListAsync(),
                MenuItem = await db.MenuItems.Include(x => x.Category).Include(x => x.SubCategory).ToListAsync() 
            }; 
            return View(indexView);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var menuItemSelected = await db.MenuItems.Include(x => x.Category)
                .Include(x => x.SubCategory).Where(x => x.Id == id).FirstOrDefaultAsync();

            var shoppingCart = new ShoppingCart {
                MenuItemId = id,
                menuItem = menuItemSelected
            };


            return View(shoppingCart);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(ShoppingCart shc)
        {
            if (ModelState.IsValid)
            {
               
                shc.Id = 0;
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var currentUser = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                shc.ApplicationUserId = currentUser.Value;

                var shoppingCartFromDb = await db.ShoppingCarts
                    .Where(x => x.ApplicationUserId == shc.ApplicationUserId && x.MenuItemId == shc.MenuItemId)
                    .FirstOrDefaultAsync();
                if (shoppingCartFromDb != null)
                {
                    shoppingCartFromDb.Count += shc.Count;
                }
                else
                {
                    db.ShoppingCarts.Add(shc);
                }
                await db.SaveChangesAsync();

                var count = db.ShoppingCarts.Where(x => x.ApplicationUserId == shc.ApplicationUserId).ToList().Count();
                HttpContext.Session.SetInt32("ShoppingCartCount", count);

                return RedirectToAction(nameof(Index));
            }
            else {
                var menuItemSelected = await db.MenuItems.Include(x => x.Category)
                 .Include(x => x.SubCategory).Where(x => x.Id == shc.MenuItemId).FirstOrDefaultAsync();

                var shoppingCart = new ShoppingCart
                {
                    MenuItemId = shc.MenuItemId,
                    menuItem = menuItemSelected
                };


                return View(shoppingCart);

            }

        }
    }
}
