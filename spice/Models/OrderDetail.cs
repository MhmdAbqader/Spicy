using System.ComponentModel.DataAnnotations.Schema;

namespace spice.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual OrderHeader OrderHeader { get; set; }

        public int MenuItemId { get; set; }
        [ForeignKey(nameof(MenuItemId))]
        public virtual MenuItem MenuItem { get; set; }

        public int Count { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
