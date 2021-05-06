using Store_Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Store_APP.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> Product(string Id);
        Task<Product> CreateProduct(Product model);
        Task<string> DeleteProduct(string Id);
        Task<string> UpdateProduct(string Id, Product model);
    }
}