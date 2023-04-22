using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace spice.Models.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<MenuItem> MenuItem { get; set; }
        public IEnumerable<Coupon> Coupons { get; set; }

    }
}
