using spice.Models;
using System;

namespace spice.Utility
{
    public static class SD
    {
        public const string ManagerRoleUser = "Manager";
        public const string KitchenRoleUser = "Kitchen";
        public const string ForntDescRoleUser = "Fornt Desc";
        public const string CustomerRoleUser = "Customer";

        public const string CouponCode = "CouponCode";

        public const string StatusSubmitted = "Submitted";
        public const string StatusInProcess = "Begin prepared";
        public const string StatusReady = "Ready for PickUp";
        public const string StatusCompleted = "Completed";
        public const string StatusCancelled = "Cancelled";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusRejected = "Rejected";

        public static double Discount(Coupon c, double orginalTotal) {

            if (c == null)
            {
                return orginalTotal;
            }
            else
            {
                if (c.MinimumAmount > orginalTotal) 
                {
                    return orginalTotal;
                }
                else {

                    //mine
                    if (c.CouponType == "Dollar")
                    {
                        return Math.Round((orginalTotal - c.Discount), 2);
                    }
                    //not work
                    //if (int.Parse(c.CouponType) == (int) Coupon.ECouponType.Dollar)
                    //{
                    //    return Math.Round((orginalTotal - c.Discount), 2);
                    //}

                    else
                        return Math.Round((orginalTotal - (orginalTotal * (c.Discount/100))), 2);

                }
            
            }

           
        }
    }
}
