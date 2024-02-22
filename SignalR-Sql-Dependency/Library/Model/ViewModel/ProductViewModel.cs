using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.ViewModel
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Products = new List<Product>(); 
        }
        public List<Product> Products { get; set;}
    }
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
