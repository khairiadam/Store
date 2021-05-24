using Microsoft.AspNetCore.Http;
using Store_Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Store_APP.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Get(string Id);
        Task<IEnumerable<Product>> GetByCategory(string CategoryId);
        Task<Product> Post(Product model, List<IFormFile> image);
        Task Delete(string Id);
        Task Update(Product model);

    }
}