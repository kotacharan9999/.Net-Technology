
using Microsoft.AspNetCore.Mvc;
using Practical6.Models;
using System.Collections.Generic;
using System.Linq;

namespace Practical6.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Category = "Electronics",
                Price = 55000,
                Stock = 10,
                Description = "High performance laptop"
            },
            new Product
            {
                Id = 2,
                Name = "Headphones",
                Category = "Accessories",
                Price = 1500,
                Stock = 25,
                Description = "Wireless headphones"
            },
            new Product
            {
                Id = 3,
                Name = "Keyboard",
                Category = "Accessories",
                Price = 800,
                Stock = 30,
                Description = "USB keyboard"
            }
        };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            Product? product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}