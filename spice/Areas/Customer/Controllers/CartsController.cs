using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spice.Data;
using spice.Models;
using spice.Models.ViewModel;
using spice.Utility;
using Stripe;
//using Stripe; //paymnet
using System;
using System.Linq;
using System.Security.Claims;

namespace spice.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext db;

        public CartsController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            OrderDetailsCartVM orderDetailsCartVM = new OrderDetailsCartVM()
            {
                orderHeader = new Models.OrderHeader(),
            };

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var currentUser = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var shoppingcart = db.ShoppingCarts.Where(x => x.ApplicationUserId == currentUser.Value).ToList();
            orderDetailsCartVM.orderHeader.OrderTotalAfterDiscount = 0;

            if (shoppingcart != null)
            {
                orderDetailsCartVM.shoppingCartList = shoppingcart;
            }

            foreach (var item in orderDetailsCartVM.shoppingCartList)
            {
                item.menuItem = db.MenuItems.FirstOrDefault(x => x.Id == item.MenuItemId);
                orderDetailsCartVM.orderHeader.OrderTotalAfterDiscount += item.menuItem.Price * item.Count;

                orderDetailsCartVM.orderHeader.OrderTotalAfterDiscount = Math.Round(orderDetailsCartVM.orderHeader.OrderTotalAfterDiscount, 2);


                if (item.menuItem.Description.Length > 100)
                { item.menuItem.Description = item.menuItem.Description.Substring(0, 99); }
            }
            orderDetailsCartVM.orderHeader.OrderTotalOrginal = orderDetailsCartVM.orderHeader.OrderTotalAfterDiscount;

            if (HttpContext.Session.GetString(SD.CouponCode) != null) {
                orderDetailsCartVM.orderHeader.CouponCode = HttpContext.Session.GetString(SD.CouponCode);
                var couponDB = db.Coupons.FirstOrDefault(x => x.Name.ToLower() == orderDetailsCartVM.orderHeader.CouponCode.ToLower());
                                               
                   orderDetailsCartVM.orderHeader.OrderTotalAfterDiscount= SD.Discount(couponDB, orderDetailsCartVM.orderHeader.OrderTotalOrginal);
            }
          
            return View(orderDetailsCartVM);
        }

        
        public IActionResult ApplyCoupon(OrderDetailsCartVM orderDetailsCartVM) {

            if (orderDetailsCartVM.orderHeader.CouponCode == null)
            {
                orderDetailsCartVM.orderHeader.CouponCode = string.Empty;
            }
            HttpContext.Session.SetString(SD.CouponCode,orderDetailsCartVM.orderHeader.CouponCode);

            return RedirectToAction("Index");
        }
        public IActionResult RemoveCoupon(OrderDetailsCartVM orderDetailsCartVM)
        {

           
            if(HttpContext.Session.GetString(SD.CouponCode)!= null)
                HttpContext.Session.SetString(SD.CouponCode, string.Empty);

            return RedirectToAction("Index");
        }

        public IActionResult Plus(int CardId)
        {
            var shoppingCart = db.ShoppingCarts.FirstOrDefault(x => x.Id == CardId);

            shoppingCart.Count += 1;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Minus(int CardId)
        {
            var shoppingCart = db.ShoppingCarts.FirstOrDefault(x => x.Id == CardId);

            if (shoppingCart.Count > 1) {
                shoppingCart.Count -= 1;
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int CardId)
        {
            var shoppingCart = db.ShoppingCarts.FirstOrDefault(x => x.Id == CardId);

            db.ShoppingCarts.Remove(shoppingCart);
            db.SaveChanges();

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var currentUser = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            int MinusSession = db.ShoppingCarts
                .Where(x => x.ApplicationUserId == currentUser.Value).ToList().Count;
             
            HttpContext.Session.SetInt32("ShoppingCartCount", MinusSession);
            return RedirectToAction(nameof(Index));
        }

        //Summary ..............................................

        public IActionResult Summary()
        {
            OrderDetailsCartVM orderDetailsCartVM = new OrderDetailsCartVM()
            {
                orderHeader = new Models.OrderHeader(),
            };

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var currentUser = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var UserInfo = db.applicationUsers.Find(currentUser.Value);

            orderDetailsCartVM.orderHeader.PickUpName = UserInfo.Name;
            orderDetailsCartVM.orderHeader.PhoneNumber = UserInfo.PhoneNumber;
            orderDetailsCartVM.orderHeader.PickUpTime = DateTime.Now;
            var shoppingcart = db.ShoppingCarts.Where(x => x.ApplicationUserId == currentUser.Value).ToList();
            
            
            orderDetailsCartVM.orderHeader.OrderTotalAfterDiscount = 0;

            if (shoppingcart != null)
            {
                orderDetailsCartVM.shoppingCartList = shoppingcart;
            }

            foreach (var item in orderDetailsCartVM.shoppingCartList)
            {
                item.menuItem = db.MenuItems.FirstOrDefault(x => x.Id == item.MenuItemId);
                orderDetailsCartVM.orderHeader.OrderTotalAfterDiscount += item.menuItem.Price * item.Count;

                orderDetailsCartVM.orderHeader.OrderTotalAfterDiscount = Math.Round(orderDetailsCartVM.orderHeader.OrderTotalAfterDiscount, 2);              
            }
            orderDetailsCartVM.orderHeader.OrderTotalOrginal = orderDetailsCartVM.orderHeader.OrderTotalAfterDiscount;

            if (HttpContext.Session.GetString(SD.CouponCode) != null)
            {
                orderDetailsCartVM.orderHeader.CouponCode = HttpContext.Session.GetString(SD.CouponCode);
                var couponDB = db.Coupons.FirstOrDefault(x => x.Name.ToLower() == orderDetailsCartVM.orderHeader.CouponCode.ToLower());

                orderDetailsCartVM.orderHeader.OrderTotalAfterDiscount = SD.Discount(couponDB, orderDetailsCartVM.orderHeader.OrderTotalOrginal);
            }

            return View(orderDetailsCartVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public IActionResult SummaryPost(OrderDetailsCartVM v , string StripeToken) {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var currentUser = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            v.shoppingCartList = db.ShoppingCarts.Where(x=>x.ApplicationUserId == currentUser.Value).ToList();

            OrderHeader oh = new OrderHeader();
            oh.PaymentStatus = SD.PaymentStatusPending;
            oh.OrderDate = DateTime.Now;
            oh.UserId = currentUser.Value;
            oh.PickUpName = v.orderHeader.PickUpName;
            oh.PhoneNumber = v.orderHeader.PhoneNumber;
            oh.Status = SD.PaymentStatusPending;
            oh.PickUpTime = Convert.ToDateTime(v.orderHeader.PickUpDate.ToShortDateString()
                + " " + v.orderHeader.PickUpTime.ToShortTimeString());
            
            oh.Comments = v.orderHeader.Comments;            
            


            db.OrderHeaders.Add(oh);
            db.SaveChanges();


           


            foreach (var item in v.shoppingCartList)
            {
                item.menuItem = db.MenuItems.FirstOrDefault(x => x.Id == item.MenuItemId);

                OrderDetail orderDetail = new OrderDetail
                {
                    OrderId = oh.Id,
                    MenuItemId = item.MenuItemId,
                    Count = item.Count,
                    Name=item.menuItem.Name,
                    Description = item.menuItem.Description,
                    Price = item.menuItem.Price
                };
                oh.OrderTotalAfterDiscount += item.menuItem.Price * item.Count;
                oh.OrderTotalOrginal = oh.OrderTotalAfterDiscount;

                db.OrderDetails.Add(orderDetail);
            }


            if (HttpContext.Session.GetString(SD.CouponCode) != null)
            {
                oh.CouponCode = HttpContext.Session.GetString(SD.CouponCode);

               var couponDB = db.Coupons.FirstOrDefault(x => x.Name.ToLower() == v.orderHeader.CouponCode.ToLower());

                oh.OrderTotalAfterDiscount = SD.Discount(couponDB, oh.OrderTotalOrginal);               
            }
            else
            {
                oh.OrderTotalAfterDiscount = v.orderHeader.OrderTotalOrginal;
            }

            db.ShoppingCarts.RemoveRange(v.shoppingCartList);
            HttpContext.Session.SetInt32("ShoppingCartCount",0);

            db.SaveChanges();

            //stripe is a namespace related to stripe.net package so we must call it 
            var option = new ChargeCreateOptions { 
            Amount = Convert.ToInt32(oh.OrderTotalAfterDiscount * 100),
            Currency = "usd",
            Description = "Order ID :"  + oh.Id, 
            Source = StripeToken,
            };

            var service = new ChargeService();
            Charge charge = service.Create(option);

            if (charge.BalanceTransactionId == null)
            {
                oh.PaymentStatus = SD.PaymentStatusRejected;
            }
            else
            { 
                oh.TransactionId= charge.BalanceTransactionId;
            }
            if (charge.Status.ToLower() == "succeeded") {
                oh.PaymentStatus = SD.PaymentStatusApproved;
                oh.Status = SD.StatusSubmitted;
            }

            else {
                oh.PaymentStatus = SD.PaymentStatusRejected;                
            }

            db.SaveChanges();
            return RedirectToAction(nameof(Index),"Home");
        }

    }
}
