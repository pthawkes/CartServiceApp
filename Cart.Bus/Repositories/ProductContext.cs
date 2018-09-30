using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.DAL
{
    public class ProductContext : DbContext,IProductContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
           : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}

