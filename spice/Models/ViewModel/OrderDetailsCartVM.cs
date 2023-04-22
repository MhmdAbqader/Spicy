using System.Collections.Generic;

namespace spice.Models.ViewModel
{
    public class OrderDetailsCartVM
    {
        public List<ShoppingCart> shoppingCartList { get; set; }
        public OrderHeader orderHeader { get; set; }
      
    }
}
