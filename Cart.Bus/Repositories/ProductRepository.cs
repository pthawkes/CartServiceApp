using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DAL
{

    public class ProductsRepository: IProductRepository
    {
        private readonly ProductContext _context;

        public ProductsRepository(ProductContext context)
        {
            _context = context;

            if (_context.Products.Count() == 0)
            {
                _context.Products.AddRange(
                    new Product
                    {
                        Id = 1,
                        Name = "Learning ASP.NET Core",
                        Description = "A best-selling book covering the fundamentals of ASP.NET Core",
                         Price = 12.53M, Stock =3
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Learning EF Core",
                        Description = "A best-selling book covering the fundamentals of Entity Framework Core",
                        Price = 7.99M,
                        Stock = 4
                    },
                     new Product
                     {
                         Id = 3,
                         Name = "Learning AWS",
                         Description = "A best-selling book covering the fundamentals of Amazon Web Services",
                         Price = 7.99M,
                         Stock = 3
                     });
                _context.SaveChanges();
            }
        }

        public void Add(Product product)
        {
            if (Exists(product.Id)) { 
                Remove(product.Id);
                }
            _context.Add(product);
        }

        public List<Product> All()
        {
            return _context.Products.ToList();
        }

        public bool Exists(int id)
        {
            return _context.Products.Any(x => x.Id == id);
        }

        public Product Get(int id)
        {
            if (!Exists(id)) throw new ArgumentException($"product with Id: {id} does not exist");

            return _context.Products.First(x => x.Id == id);
        }

        public void Remove(int id)
        {
            if (!Exists(id)) throw new ArgumentException($"product with Id: {id} does not exist");

            _context.Products.ToList().RemoveAll(x => x.Id == id);
        }
    }

}
