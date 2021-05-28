﻿using Store_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Store_Shared.Dto;




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

        public IEnumerable<ProductModel> Get()
        {
            IEnumerable<ProductModel> products = null;

            //Call HTTP GET
            var responseTask = _client.GetAsync("Product");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<ProductModel>>();
                readTask.Wait();

                products = readTask.Result;



            }
            else //web api sent error response 
            {
                //log response status here..

                products = Enumerable.Empty<ProductModel>();
            }
            return products;
        }

        //public   System.Drawing.ICmage LoadBase64(string base64)
        //{
        //    var img = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64String)));
        //}

        public IEnumerable<ProductModel> GetByCategory(string idCategory)
        {
            IEnumerable<ProductModel> products = new List<ProductModel>();
            var responseTask = _client.GetAsync($"Product/Category/{idCategory}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IEnumerable<ProductModel>>();
                readTask.Wait();

                products = readTask.Result;
                return products;
            }
            else
            {
                return products;
            }
        }

        public ProductModel Get(string id)
        {
            ProductModel product = null;
            var responseTask = _client.GetAsync($"Product/{id}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ProductModel>();
                readTask.Wait();

                product = readTask.Result;
                return product;
            }
            else
            {
                return product;
            }
        }


        public async Task<bool> AddProduct(Product product)
        {
            if (product == null) return false;

            var productJson = JsonSerializer.Serialize(product);
            var requestC = new StringContent(productJson, Encoding.UTF8, "application/Json");
            var request = await _client.PostAsync("/product/Add", requestC);
                return true;
        }
    }
}
