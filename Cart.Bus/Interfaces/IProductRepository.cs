using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.DAL
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product Get(int id);
        void Remove(int id);
        bool Exists(int id);
        List<Product> All();
    }
}
