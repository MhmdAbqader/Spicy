using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace spice.Models.ViewModel
{
    public class subandcatViewModel
    {
        public int id { get; set; }
        public IEnumerable<Category> CategoriesList { get; set; }

        public SubCategory SubCategory { get; set; }

       
        public string statusMsg { get; set; }   
    }
}
