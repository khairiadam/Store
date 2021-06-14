using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Store_Shared.Models;

namespace Store_Client_Blzr.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public event Action OnChange;

        public List<Product> Products { get; set; } = new();

        public async Task LoadProducts(string categoryId = null)
        {
            if (categoryId == null)
                Products = await _http.GetFromJsonAsync<List<Product>>("Product");
            else
                Products = await _http.GetFromJsonAsync<List<Product>>($"Product/Category/{categoryId}");
            OnChange.Invoke();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _http.GetFromJsonAsync<Product>($"api/Product/{id}");
        }

        public async Task<List<Product>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<Product>>("Product");
        }
    }
}