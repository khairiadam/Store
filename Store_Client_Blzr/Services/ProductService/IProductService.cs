using Store_Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store_Client_Blzr.Services.ProductService
{
    public interface IProductService
    {
        event Action OnChange;
        List<Product> Products { get; set; }
        Task<List<Product>> GetAll();
        Task LoadProducts(string categoryUrl = null);
        Task<Product> GetProduct(int id);
    }
}
