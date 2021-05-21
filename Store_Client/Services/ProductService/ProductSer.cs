using Store_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Store_Client.Services.ProductService
{
    public class ProductSer : IProductSer
    {
         HttpClient _client;

        public ProductSer(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:4000/api/");
        }

        public async Task<IEnumerable<Product>> Get()
        {
            IEnumerable<Product> products = null;

            //HTTP GET
            var responseTask = _client.GetAsync("Product");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Product>>();
                readTask.Wait();

                products = readTask.Result;
            }
            else //web api sent error response 
            {
                //log response status here..

                products = Enumerable.Empty<Product>();
            }
            return products;
        }

        public async Task<Product> Get(string id)
        {
            Product product = null;
            var responseTask = _client.GetAsync($"Product/{id}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Product>();
                readTask.Wait();

                product = readTask.Result;
                return product;
            }
            else
            {
                return product;
            }
        }
    }
}
