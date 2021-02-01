using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        //a
        public readonly IProductRepository productRepository;
        
        //b
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        /*
         *W folderze Controllers dodajemy kontroler ProductController
                a. Dodajemy konstruktor, w który wstrzykujemy interfejs IProductRepository gdyz go nie widzi 
                b. Dodajemy metodę zwracającą listę produktów
 
         * 
         */
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult List() => View(productRepository.Products);

    }
}
