using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace spice.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string Name { get; set; }
        [Required]
        public string CouponType { get; set; }
        public enum ECouponType {Percent=0,Dollar=1}

        [Required]
        public double Discount { get; set; }
        public double MinimumAmount { get; set; }
        public byte[] Picture { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
    }
}
