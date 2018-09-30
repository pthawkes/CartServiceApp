using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShoppingCart.DTO;

namespace ShoppingCart.Client
{
    public class CartClient:CartBase
    {
        public CartClient()
        {
        }

       
       public async Task<bool> CreateAndAddProduct(CartDTO cartDTO,string path)
        {

            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(cartDTO));

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(path, httpContent);
           
            using (HttpContent content = response.Content)
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
      public  async Task<CartDTO> RetrieveCartById(string path)
        {
           CartDTO cart = null;

            var response = await httpClient.GetAsync(path);
            string res = "";
            using (HttpContent content = response.Content)
            {
                if (response.IsSuccessStatusCode)
                {
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                    cart = JsonConvert.DeserializeObject<CartDTO>(res);
                }
            }
            return cart;
        }
        
    }
}