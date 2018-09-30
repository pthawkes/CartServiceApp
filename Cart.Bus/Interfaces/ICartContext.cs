using System.Collections.Generic;

namespace ShoppingCart.DAL
{
    public interface ICartContext
    {
        void AddProduct(string cartIdentifier, int productId, int quantity);
        void RemoveProduct(string cartIdentifier, int productId);
        void ClearCart(string cartIdentifier);
        List<Product> GetCart(string cartIdentifier);
    }
}