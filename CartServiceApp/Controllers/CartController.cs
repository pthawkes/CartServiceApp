using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DAL;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DTO;


namespace CartService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        /// <summary>
        /// readonly cart context member
        /// </summary>
        private readonly ICartContext _CartContext;
        /// <summary>
        /// cart controller dependency
        /// </summary>
        /// <param name="CartContext">the ICartContext</param>
        public CartController(ICartContext CartContext)
        {
            _CartContext = CartContext;
        }

        /// <summary>
        /// Get a cart object using its identifier
        /// </summary>
        /// <param name="cartIdentifier">the cart identifier</param>
        /// <returns>a list of products in the cart id specified</returns>
        [HttpGet("{cartIdentifier}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductDTO>))]
        [ProducesResponseType(404)]
        public IActionResult Get(string cartIdentifier)
        {
            var prods = _CartContext.GetCart(cartIdentifier);
            if (prods!=null &&prods.Any())
                return Ok(new ProductDTO().CreateCartProducts(prods, cartIdentifier));
            else
                return NotFound();

        }
        /// <summary>
        /// Add a product to a cart
        /// </summary>
        /// <param name="cartPoduct">the cart data transfert object</param>
        /// <returns>returns an HTTP status code</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Route("api/Cart/AddCartProduct")]
        public IActionResult AddCartProduct([FromBody] CartDTO cartPoduct)
        {

            _CartContext.AddProduct(cartPoduct.cartIdentifier, cartPoduct.ProductId, cartPoduct.Quantity);
            return Ok();

        }
        /// <summary>
        /// Removes a product item from a cart
        /// </summary>
        /// <param name="cartPoduct">the cart DTO</param>
        /// <returns>returns an HTTP status code</returns>
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult RemoveCartProduct([FromBody] CartDTO cartPoduct)
        {
            try
            {
                _CartContext.RemoveProduct(cartPoduct.cartIdentifier, cartPoduct.ProductId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Clear the cart of all its products
        /// </summary>
        /// <param name="cartIdentifier">the identifier of the cart</param>
        /// <returns>returns an HTTP status code</returns>
        [Route("api/cart/clear/{id}")]
        [HttpPost]
        public IActionResult Clear(string cartIdentifier)
        {
            _CartContext.ClearCart(cartIdentifier);
            return Ok();

        }


    }
}
