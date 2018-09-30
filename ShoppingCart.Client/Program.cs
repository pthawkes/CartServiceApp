using Newtonsoft.Json;
using ShoppingCart.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShoppingCart.Client
{
    class Program
    {
             
       
       static void Main(string[] args)
        {
            ProductClientFunctions();
            CartFunctions();
            Console.ReadKey();
        }
        static void CartFunctions()
        {
            var cartDTO = (new CartDTO() { cartIdentifier = Guid.NewGuid().ToString(), ProductId = 2, Quantity = 2 });
            CreateCart(cartDTO);
            RetrieveCart(cartDTO.cartIdentifier);

        }

        private static void RetrieveCart(string cartIdentifier)
        {
            CartClient cart = new CartClient();
            var cartDT = cart.RetrieveCartById("/api/cart/" + cartIdentifier);
        }

        private static void CreateCart(CartDTO cartDTO)
        {
            CartClient cart = new CartClient();
            if (cart.CreateAndAddProduct(cartDTO, "/api/cart/AddCartProduct").Result)
            {
                Console.WriteLine($"added cart item");
            }
            else
            {
                Console.WriteLine($"failed to add cart item");
            }
        }

        static void ProductClientFunctions()
        {
            ProductClient prods = new ProductClient();
            foreach (var item in prods.GetAllProducts())
            {
                ShowProduct(item);
            }

        }
        static void ShowProduct(ProductDTO product)
        {
            Console.WriteLine($"Name: {product.Name}\tPrice: " +
                $"{product.Price}\tDescription: {product.Description}");
        }


     
        

    }
}
