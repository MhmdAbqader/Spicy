using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spice.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Count = 1;
        }
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; } 
        public int MenuItemId { get; set; }
        [NotMapped]
        [ForeignKey(nameof(MenuItemId))]
        public virtual MenuItem menuItem { get; set; }


        [Range(1,int.MaxValue , ErrorMessage ="please Enter Value >= 1")]
        public int Count { get; set; }
    }
}
