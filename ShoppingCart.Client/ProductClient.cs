using Newtonsoft.Json;
using ShoppingCart.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Client
{
    public class ProductClient : CartBase
    {
        public ProductClient() { }
        public List<ProductDTO> GetAllProducts()
        {

           return  GetAllProductsAsync("/api/products").Result;

        }


        async Task<List<ProductDTO>> GetAllProductsAsync(string path)
        {
            List<ProductDTO> products = null;

            var response = await httpClient.GetAsync(path);
            string res = "";
            using (HttpContent content = response.Content)
            {
                if (response.IsSuccessStatusCode)
                {
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                    products =  JsonConvert.DeserializeObject<List<ProductDTO>>(res);
                }
            }
            return products;
        }
    }
}
