using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store_Shared.Models;

namespace Store_Client_Blzr.Services.ProductService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        event Action OnChange;
        Task<List<Product>> GetAll();
        Task LoadProducts(string categoryUrl = null);
        Task<Product> GetProduct(int id);
    }
}