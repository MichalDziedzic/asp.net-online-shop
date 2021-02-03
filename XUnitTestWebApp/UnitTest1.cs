using System;
using Xunit;
using Moq;
//using SportsStore.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebApp.Models;

namespace XUnitTestWebApp
{
    public class UnitTest1
    {
        
       
            [Fact]
            public void Index_Contains_All_Products()
            {
                // Przygotowanie  tworzenie imitacji repozytorium.
                Mock<IProductRepository> mock = new Mock<IProductRepository>();
                mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
            }.AsQueryable<Product>());

                // Przygotowanie  utworzenie kontrolera.
                AdminController controller = new AdminController(mock.Object);
                // Dzia�anie.
                Product[] result =
                    GetViewModel<IEnumerable<Product>>(controller.Index())?.ToArray();

                // Asercje.
                Assert.Equal(3, result.Length);
                Assert.Equal("P1", result[0].Name);
                Assert.Equal("P2", result[1].Name);
                Assert.Equal("P3", result[2].Name);
            }

            [Fact]
            public void Can_Filter_Products()
            {
                // Przygotowanie.
                // Utworzenie imitacji repozytorium.
                Mock<IProductRepository> mock = new Mock<IProductRepository>();
                mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductId = 1, Name = "P1", Category = "Cat1"},
                new Product {ProductId = 2, Name = "P2", Category = "Cat2"},
                new Product {ProductId = 3, Name = "P3", Category = "Cat1"},
                new Product {ProductId = 4, Name = "P4", Category = "Cat2"},
                new Product {ProductId = 5, Name = "P5", Category = "Cat3"}
            }).AsQueryable<Product>());

                // Przygotowanie  utworzenie kontrolera i ustawienie 3-elementowej strony.
                ProductController controller = new ProductController(mock.Object);

                // Dzia�anie.
                Product[] result = GetViewModel<IEnumerable<Product>>(controller.List("Cat2")).ToArray();

                // Asercje.
                Assert.Equal(2, result.Length);
                Assert.True(result[0].Name == "P2" && result[0].Category == "Cat2");
                Assert.True(result[1].Name == "P4" && result[1].Category == "Cat2");
            }

            [Theory]
            [InlineData(1, "P1")]
            [InlineData(4, "P4")]
            public void Can_Get_Products(int id, string expectedName)
            {
                // Przygotowanie.
                // Utworzenie imitacji repozytorium.
                Mock<IProductRepository> mock = new Mock<IProductRepository>();
                mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductId = 1, Name = "P1", Category = "Cat1"},
                new Product {ProductId = 2, Name = "P2", Category = "Cat2"},
                new Product {ProductId = 3, Name = "P3", Category = "Cat1"},
                new Product {ProductId = 4, Name = "P4", Category = "Cat2"},
                new Product {ProductId = 5, Name = "P5", Category = "Cat3"}
            }).AsQueryable<Product>());

                // Przygotowanie  utworzenie kontrolera i ustawienie 3-elementowej strony.
                ProductController controller = new ProductController(mock.Object);

                // Dziaanie.
                Product result = GetViewModel<Product>(controller.GetById(id));

                // Asercje.
                Assert.Equal(result.Name, expectedName);
            }

            private T GetViewModel<T>(IActionResult result) where T : class
            {
                return (result as ViewResult)?.ViewData.Model as T;
            }
        }
    

}


