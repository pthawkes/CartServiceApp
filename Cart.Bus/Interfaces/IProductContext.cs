using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.DAL
{
    public interface IProductContext

    {
       DbSet<Product> Products { get; set; }
    }

}
