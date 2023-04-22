using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spice.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="SubCategory")]
        public string Name { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
