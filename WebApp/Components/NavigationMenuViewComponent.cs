﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Components 
{

   
        public class NavigationMenuViewComponent : ViewComponent
        {
            private readonly IProductRepository _productRepository;

            public NavigationMenuViewComponent(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public IViewComponentResult Invoke()
            {
                ViewBag.SelectedCategory = RouteData?.Values["category"];
                return View(_productRepository.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
            }
        }

    

}

