using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ShoppingCart.Client
{
    public class CartBase
    {
        public HttpClient httpClient;

        private const string baseAddress = "http://localhost:55445";
        public CartBase()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);         
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


    }
    
}
