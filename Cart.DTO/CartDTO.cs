using ShoppingCart.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.DTO
{
   public class CartDTO
    {
        /// <summary>
        /// product identifier
        /// </summary>
        [Required]
        public String cartIdentifier { get; set; }
        /// <summary>
        /// Product Name    
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Description of Product      
        /// </summary>       
        public int Quantity { get; set; }
     
    }
}
