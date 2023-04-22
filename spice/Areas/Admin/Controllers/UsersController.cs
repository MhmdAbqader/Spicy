using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spice.Data;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace spice.Areas.Admin.Controllers
{
    [Authorize(Roles = spice.Utility.SD.ManagerRoleUser)]
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext db;

        public UsersController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string UserId = claim.Value;
            var users = await db.applicationUsers.Where(x=>x.Id != UserId).ToListAsync();
            return View(users);
        }
        public async Task<IActionResult> LockUnLock(string? id) {

            if (id == null)
                return NotFound($"No  ID ");

            var user = await db.applicationUsers.FindAsync(id);

            if(user == null)
                return NotFound($"No User with Id = {id}");

            if (user.LockoutEnd == null || user.LockoutEnd < DateTime.Now)
            {
                user.LockoutEnd = DateTime.Now.AddYears(10);
            }
            else {
                user.LockoutEnd = DateTime.Now;
            }
            await db.SaveChangesAsync();


            return RedirectToAction("Index");
        }
    }
}
