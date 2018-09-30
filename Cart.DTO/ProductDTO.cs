using ShoppingCart.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.DTO
{
    /// <summary>
    /// Product Data transfer object class
    /// </summary>
    public class ProductDTO
    {
        public string CartIdentifier { get; set; }
        /// <summary>
        /// product identifier
        /// </summary>
        [Required]
        public int Identifier { get; set; }
        /// <summary>
        /// Product Name    
        /// </summary>       
        public string Name { get; set; }
        /// <summary>
        /// Description of Product      
        /// </summary>       
        public string Description { get; set; }
        /// <summary>
        /// Price of Product
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity in Stock
        /// </summary>
        public int Stock { get; set; }
        /// <summary>
        /// Creates the data transfer object to 
        /// </summary>
        /// <param name="products"></param>
        /// <param name="cartIdentifier"></param>
        /// <returns></returns>
        public IEnumerable<ProductDTO> CreateCartProducts(IEnumerable<Product> products, string cartIdentifier)
        {
            var productsDTO = new List<ProductDTO>();

            foreach (var item in products)
            {
                productsDTO.Add(new ProductDTO() { CartIdentifier = cartIdentifier, Description = item.Description, Identifier = item.Id, Name = item.Name, Price = item.Price, Stock = item.Stock });
            }

          
            return productsDTO;
        }
    }
}
