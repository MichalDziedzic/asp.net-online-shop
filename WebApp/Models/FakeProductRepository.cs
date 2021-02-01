using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product {Name= "the sims2",Description="blabla",Price=10},
            new Product {Name= "the sims3",Description="asdsadadsa",Price=15},
            new Product {Name= "the sims4",Description="tewsttstes",Price=20}

        }.AsQueryable<Product>();
    }
}

/*
 * 
 
b. tworzymy Klasę FakeProductRepository, która implementuje Interfejs IProductRepository i
zwraca kilka przykładowych produktów
 * 
 */