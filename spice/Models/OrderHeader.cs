using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spice.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public double OrderTotalOrginal { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "(0:c)")]
        public double OrderTotalAfterDiscount { get; set; }

        [Required]
        [Display(Name = "PickUp Time")]
        public DateTime PickUpTime { get; set; }

        [NotMapped]
        [Required]
        public DateTime PickUpDate { get; set; }

        [Display(Name = "coupon code")]
        public string CouponCode { get; set; }
        public string CouponCodeDiscount { get; set; }
        public string Status { get; set; }

        public string PaymentStatus { get; set; }
        public string Comments { get; set; }

        [Display(Name = "PickUp Name")]
        public string PickUpName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string TransactionId { get; set; }
    }
}
