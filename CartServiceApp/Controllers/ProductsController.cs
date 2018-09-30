using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DAL;
using ShoppingCart.DTO;

namespace CartServiceApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        /// <summary>
        /// readonly cart context member
        /// </summary>
        private readonly IProductRepository _productContext;
        /// <summary>
        /// cart controller dependency
        /// </summary>
        /// <param name="CartContext">the ICartContext</param>
        public ProductsController(IProductRepository productContext)
        {
            _productContext = productContext;
        }        
     
        [HttpGet]
        public IActionResult Get(string cartIdentifier)
        {
            var prods = new ProductDTO().CreateCartProducts( _productContext.All(),"");
            if (prods.Any())
                return Ok(prods);
            else
                return NotFound("No product");

        }
    }
}