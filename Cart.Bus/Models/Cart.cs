using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.DAL
{
    public class Cart : ICartContext
    {

        private static Dictionary<string, List<Product>> _carts;

        private Dictionary<string, List<Product>> Carts
            => _carts ?? (_carts = new Dictionary<string, List<Product>>(StringComparer.InvariantCultureIgnoreCase));

        private readonly IProductContext _productContext;

        public Cart(IProductContext productContext)
        {
            _productContext = productContext;
        }
        /// <summary>
        /// add a an item to cart with the idetifier provided
        /// </summary>
        /// <param name="cartIdentifier">the cart identifier</param>
        /// <param name="productId">the prduct Id to add</param>
        /// <param name="quantity">the quantity to add</param>
        public void AddProduct(string cartIdentifier, int productId, int quantity)
        {
            var availableProduct = this._productContext.Products.FirstOrDefault(x => x.Id == productId);
            if (quantity > availableProduct?.Stock)
                return;

            if (this.Carts.ContainsKey(cartIdentifier))
            {
                var existingProduct = this.Carts[cartIdentifier].FirstOrDefault(x => x.Id == productId);

                if (existingProduct != null)
                {
                    this.Carts[cartIdentifier].Remove(existingProduct);
                    quantity += existingProduct.Stock;
                }
                if (availableProduct == null) return;
                Product cartProduct = CreateCartProduct(availableProduct, quantity);
                this.Carts[cartIdentifier].Add(cartProduct);
            }
            else
            {
                Product cartProduct = CreateCartProduct(availableProduct, quantity);
                this.Carts.Add(cartIdentifier, new List<Product> { cartProduct });
            }
        }


        /// <summary>
        /// Remove a product from a cart
        /// </summary>
        /// <param name="cartIdentifier"></param>
        /// <param name="productId"></param>
        public void RemoveProduct(string cartIdentifier, int productId)
        {

            if (this.Carts.ContainsKey(cartIdentifier))
            {
                var existingProduct = this.Carts[cartIdentifier].FirstOrDefault(x => x.Id == productId);

                if (existingProduct != null)
                {
                    this.Carts[cartIdentifier].Remove(existingProduct);
                }
                else
                {
                    throw new ArgumentException(string.Format("Product({0}) does not exist in cart.", productId));
                }
            }else
                throw new ArgumentException(string.Format("Cart does not exist: {0}", cartIdentifier));

        }

        /// <summary>
        /// remove the cart from the dictionary of carts
        /// </summary>
        /// <param name="cartIdentifier"></param>
        public void ClearCart(string cartIdentifier)
        {
            this.Carts.Remove(cartIdentifier);
        }
        /// <summary>
        /// create a card product
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        private Product CreateCartProduct(Product product, int quantity)
        {

            Product cartProduct = new Product
            {
                Stock = quantity,
                Description = product.Description,
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
            return cartProduct;
        }
        /// <summary>
        /// returns a list of products a cart will has
        /// </summary>
        /// <param name="cartIdentifier"></param>
        /// <returns></returns>
        public List<Product> GetCart(string cartIdentifier)
        {
            return !this.Carts.ContainsKey(cartIdentifier) ? null : this.Carts[cartIdentifier];
        }

    }

}

