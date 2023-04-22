using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace spice.Models.ViewModel
{
    public class MenuItemViewModel
    {

        public MenuItem menuItem { get; set; }
      //  [Required]
        public IFormFile File { get; set; } 
        public IEnumerable<Category> categoriesList { get; set; }
        public IEnumerable<SubCategory> subCategoriesList { get; set; }
    }
}
